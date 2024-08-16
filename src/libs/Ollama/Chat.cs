using System.Text;

namespace Ollama;

/// <summary>
/// 
/// </summary>
public class Chat
{
	/// <summary>
	/// 
	/// </summary>
	public List<Message> History { get; set; } = new();
	
	/// <summary>
	/// 
	/// </summary>
	public List<Tool> Tools { get; } = new();
	
	/// <summary>
	/// 
	/// </summary>
	public Dictionary<string, Func<string, CancellationToken, Task<string>>> Calls { get; } = new();

	/// <summary>
	/// 
	/// </summary>
	public OllamaApiClient Client { get; }
	
	/// <summary>
	/// 
	/// </summary>
	public string Model { get; set; }
	
	/// <summary>
	/// 
	/// </summary>
	public bool AutoCallTools { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="systemMessage"></param>
	/// <exception cref="ArgumentNullException"></exception>
	public Chat(
		OllamaApiClient client,
		string model,
		string? systemMessage = null)
	{
		Client = client ?? throw new ArgumentNullException(nameof(client));
		Model = model ?? throw new ArgumentNullException(nameof(model));
		
		if (systemMessage != null)
		{
			History.Add(new Message
			{
				Role = MessageRole.System,
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
		IList<Tool> tools,
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
	public async Task<Message> SendAsync(
		string? message = null,
		MessageRole role = MessageRole.User,
		IEnumerable<string>? imagesAsBase64 = null,
		CancellationToken cancellationToken = default)
	{
		if (message != null)
		{
			History.Add(new Message
			{
				Content = message,
				Role = role,
				Images = imagesAsBase64?.ToList() ?? [],
			});
		}

		var request = new GenerateChatCompletionRequest
		{
			Messages = History,
			Model = Model,
			Stream = false,
			Tools = Tools.Count == 0 ? null : Tools,
		};

		var answer = await Client.Chat.GenerateChatCompletionAsync(request, cancellationToken).WaitAsync().ConfigureAwait(false);
		if (answer.Message == null)
		{
			throw new InvalidOperationException("Response message was null.");
		}
		
		History.Add(answer.Message);

		if (AutoCallTools && answer.Message.ToolCalls?.Count > 0)
		{
			foreach (var call in answer.Message.ToolCalls)
			{
				var func = Calls[call.Function?.Name ?? string.Empty];

				var json = await func(
					call.Function?.Arguments.AsJson() ?? string.Empty,
					cancellationToken).ConfigureAwait(false);
				History.Add(json.AsToolMessage());
			}

			return await SendAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
		}
		
		return answer.Message;
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
	public static string PrintMessages(List<Message> messages)
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
					builder.AppendLine($"{call.Function?.Name}({call.Function?.Arguments.AsJson()})");
				}
			}
		}
		
		return builder.ToString();
	}
}