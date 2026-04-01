using System.Runtime.CompilerServices;
using System.Text;

namespace Ollama;

public partial class Chat
{
	/// <summary>
	/// Sends a message and yields streamed response updates while preserving chat history.
	/// </summary>
	/// <param name="message">The message to send</param>
	/// <param name="role">The role in which the message should be sent</param>
	/// <param name="imagesAsBase64">Base64 encoded images to send to the model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async IAsyncEnumerable<ChatStreamEvent> SendAsStreamAsync(
		string? message = null,
		ChatMessageRole role = ChatMessageRole.User,
		IEnumerable<string>? imagesAsBase64 = null,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		if (message != null)
		{
			History.Add(new ChatMessage
			{
				Content = message,
				Role = role,
				Images = imagesAsBase64?.ToList() ?? [],
			});
		}

		var responseRole = ChatMessageRole.Assistant;
		IList<ToolCall>? toolCalls = null;
		IList<string>? images = null;
		var responseContent = new StringBuilder();

		await foreach (var update in Client.ChatAsStreamAsync(
			model: Model,
			messages: History,
			format: Format,
			options: Options,
			keepAlive: KeepAlive,
			tools: Tools.Count == 0 ? null : Tools,
			cancellationToken: cancellationToken).ConfigureAwait(false))
		{
			if (ChatMessageRoleExtensions.ToEnum(update.Message?.Role ?? string.Empty) is { } streamedRole)
			{
				responseRole = streamedRole;
			}

			if (update.Message?.ToolCalls is { Count: > 0 } streamedToolCalls)
			{
				toolCalls = streamedToolCalls;
			}

			if (update.Message?.Images is { Count: > 0 } streamedImages)
			{
				images = streamedImages;
			}

			if (update.Message?.Content is { Length: > 0 } content)
			{
				responseContent.Append(content);
			}

			yield return update;
		}

		var answerMessage = new ChatMessage
		{
			Role = responseRole,
			Content = responseContent.ToString(),
			Images = images,
			ToolCalls = toolCalls,
		};
		History.Add(answerMessage);

		if (!AutoCallTools)
		{
			yield break;
		}

		var pendingToolCalls = answerMessage.ToolCalls?.ToList();
		if (pendingToolCalls is not { Count: > 0 })
		{
			yield break;
		}

		foreach (var call in pendingToolCalls)
		{
			string funcName = call.Function?.Name ?? string.Empty;
			if (string.IsNullOrEmpty(funcName)) continue;
			if (!Calls.TryGetValue(funcName, out var func)) continue;
			var argumentsAsJson = call.Function?.Arguments == null
				? string.Empty
				: call.Function.Arguments.AsJson();
			var json = await func(argumentsAsJson, cancellationToken).ConfigureAwait(false);
			History.Add(json.AsToolMessage());
		}

		await foreach (var update in SendAsStreamAsync(
			cancellationToken: cancellationToken).ConfigureAwait(false))
		{
			yield return update;
		}
	}
}
