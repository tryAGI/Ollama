using System.Text;

namespace Ollama;

/// <summary>
/// 
/// </summary>
public partial class Chat
{
	/// <summary>
	/// 
	/// </summary>
	public List<ChatMessage> History { get; set; } = new();
	
	/// <inheritdoc cref="ChatRequest.Tools"/>
	public List<ToolDefinition> Tools { get; } = new();
	
	/// <summary>
	/// 
	/// </summary>
	public Dictionary<string, Func<string, CancellationToken, Task<string>>> Calls { get; } = new();

	/// <summary>
	/// 
	/// </summary>
	public IOllamaClient Client { get; }
	
	/// <inheritdoc cref="ChatRequest.Model"/>
	public string Model { get; set; }
	
	/// <summary>
	/// 
	/// </summary>
	public bool AutoCallTools { get; set; } = true;
	
	/// <inheritdoc cref="ChatRequest.Format"/>
	public OneOf<ChatRequestFormatEnum?, object>? Format { get; set; }
	
	/// <inheritdoc cref="ChatRequest.Options"/>
	public ModelOptions? Options { get; set; }
	
	/// <inheritdoc cref="ChatRequest.KeepAlive"/>
	public OneOf<string, double?>? KeepAlive { get; set; }

	/// <summary>
	/// 
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="systemMessage"></param>
	/// <param name="format">
	/// The format to return a response in. Currently the only accepted value is json.<br/>
	/// Enable JSON mode by setting the format parameter to json. This will structure the response as valid JSON.<br/>
	/// Note: it's important to instruct the model to use JSON in the prompt. Otherwise, the model may generate large amounts whitespace.
	/// </param>
	/// <param name="options">
	/// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
	/// </param>
	/// <param name="keepAlive">
	/// How long (in minutes) to keep the model loaded in memory.<br/>
	/// - If set to a positive duration (e.g. 20), the model will stay loaded for the provided duration.<br/>
	/// - If set to a negative duration (e.g. -1), the model will stay loaded indefinitely.<br/>
	/// - If set to 0, the model will be unloaded immediately once finished.<br/>
	/// - If not set, the model will stay loaded for 5 minutes by default
	/// </param>
	/// <exception cref="ArgumentNullException"></exception>
	public Chat(
		IOllamaClient client,
		string model,
		string? systemMessage = null,
		OneOf<ChatRequestFormatEnum?, object>? format = default,
		ModelOptions? options = default,
		OneOf<string, double?>? keepAlive = default)
	{
		Client = client ?? throw new ArgumentNullException(nameof(client));
		Model = model ?? throw new ArgumentNullException(nameof(model));
		
		Format = format;
		Options = options;
		KeepAlive = keepAlive;
		
		if (systemMessage != null)
		{
			History.Add(new ChatMessage
			{
				Role = ChatMessageRole.System,
				Content = systemMessage,
			});
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="tools"></param>
	/// <param name="calls"></param>
	public void AddToolService(
		IList<ToolDefinition> tools,
		IReadOnlyDictionary<string, Func<string, CancellationToken, Task<string>>> calls)
	{
		tools = tools ?? throw new ArgumentNullException(nameof(tools));
		calls = calls ?? throw new ArgumentNullException(nameof(calls));
		
		Tools.AddRange(tools);
		foreach (var call in calls)
		{
			Calls.Add(call.Key, call.Value);
		}
	}

	/// <summary>
	/// Sends a message in a given role(User by default) to the currently selected model
	/// </summary>
	/// <param name="role">The role in which the message should be sent</param>
	/// <param name="message">The message to send</param>
	/// <param name="imagesAsBase64">Base64 encoded images to send to the model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task<ChatMessage> SendAsync(
		string? message = null,
		ChatMessageRole role = ChatMessageRole.User,
		IEnumerable<string>? imagesAsBase64 = null,
		CancellationToken cancellationToken = default)
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

		var answer = await Client.ChatAsync(
			model: Model,
			messages: History,
			format: Format,
			options: Options,
			keepAlive: KeepAlive,
			tools: Tools.Count == 0 ? null : Tools,
			cancellationToken: cancellationToken).ConfigureAwait(false);
		if (answer.Message == null)
		{
			throw new InvalidOperationException("Response message was null.");
		}
		
		var answerMessage = answer.Message.ToChatMessage();
		History.Add(answerMessage);

		if (AutoCallTools && answer.Message.ToolCalls?.Count > 0)
		{
			foreach (var call in answer.Message.ToolCalls)
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

			return await SendAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
		}
		
		return answerMessage;
	}

	/// <summary>
	/// Sends a message and invokes a callback for each streamed response chunk while preserving chat history.
	/// </summary>
	/// <param name="message">The message to send</param>
	/// <param name="onResponseChunk">Callback invoked for each non-empty streamed response chunk</param>
	/// <param name="role">The role in which the message should be sent</param>
	/// <param name="imagesAsBase64">Base64 encoded images to send to the model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task<ChatMessage> SendAsync(
		string? message,
		Action<bool, string?> onResponseChunk,
		ChatMessageRole role = ChatMessageRole.User,
		IEnumerable<string>? imagesAsBase64 = null,
		CancellationToken cancellationToken = default)
	{
		onResponseChunk = onResponseChunk ?? throw new ArgumentNullException(nameof(onResponseChunk));

		var isFirstChunk = true;
		await foreach (var update in SendAsStreamAsync(
			message: message,
			role: role,
			imagesAsBase64: imagesAsBase64,
			cancellationToken: cancellationToken).ConfigureAwait(false))
		{
			if (update.Message?.Content is not { Length: > 0 } content)
			{
				continue;
			}

			onResponseChunk(isFirstChunk, content);
			isFirstChunk = false;
		}

		return History[^1];
	}
	
	/// <summary>
	/// 
	/// </summary>
	public string PrintMessages()
	{
		return PrintMessages(History);
	}
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="messages"></param>
	public static string PrintMessages(List<ChatMessage> messages)
	{
		messages = messages ?? throw new ArgumentNullException(nameof(messages));
		
		var builder = new StringBuilder();
		foreach (var message in messages)
		{
			builder.AppendLine($"> {message.Role}:");
			if (!string.IsNullOrWhiteSpace(message.Content))
			{
				builder.AppendLine(message.Content);
			}
			if (message.ToolCalls?.Count > 0)
			{
				builder.AppendLine("Tool calls:");
				
				foreach (var call in message.ToolCalls)
				{
					var argumentsAsJson = call.Function?.Arguments == null
						? string.Empty
						: call.Function.Arguments.AsJson();
					builder.AppendLine($"{call.Function?.Name}({argumentsAsJson})");
				}
			}
		}
		
		return builder.ToString();
	}
}
