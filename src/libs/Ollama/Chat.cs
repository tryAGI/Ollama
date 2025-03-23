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
	
	/// <inheritdoc cref="GenerateChatCompletionRequest.Tools"/>
	public List<Tool> Tools { get; } = new();
	
	/// <summary>
	/// 
	/// </summary>
	public Dictionary<string, Func<string, CancellationToken, Task<string>>> Calls { get; } = new();

	/// <summary>
	/// 
	/// </summary>
	public IOllamaApiClient Client { get; }
	
	/// <inheritdoc cref="GenerateChatCompletionRequest.Model"/>
	public string Model { get; set; }
	
	/// <summary>
	/// 
	/// </summary>
	public bool AutoCallTools { get; set; } = true;
	
	/// <inheritdoc cref="GenerateChatCompletionRequest.Format"/>
	public ResponseFormat? ResponseFormat { get; set; }
	
	/// <inheritdoc cref="GenerateChatCompletionRequest.Options"/>
	public RequestOptions? RequestOptions { get; set; }
	
	/// <inheritdoc cref="GenerateChatCompletionRequest.KeepAlive"/>
	public int? KeepAlive { get; set; }

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
		IOllamaApiClient client,
		string model,
		string? systemMessage = null,
		ResponseFormat? format = default,
		RequestOptions? options = default,
		int? keepAlive = default)
	{
		Client = client ?? throw new ArgumentNullException(nameof(client));
		Model = model ?? throw new ArgumentNullException(nameof(model));
		
		ResponseFormat = format;
		RequestOptions = options;
		KeepAlive = keepAlive;
		
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

		var answer = await Client.Chat.GenerateChatCompletionAsync(
			model: Model,
			messages: History,
			format: ResponseFormat,
			options: RequestOptions,
			stream: false,
			keepAlive: KeepAlive,
			tools: Tools.Count == 0 ? null : Tools,
			cancellationToken: cancellationToken).WaitAsync().ConfigureAwait(false);
		if (answer.Message == null)
		{
			throw new InvalidOperationException("Response message was null.");
		}
		
		History.Add(answer.Message);

		if (AutoCallTools && answer.Message.ToolCalls?.Count > 0)
		{
			foreach (var call in answer.Message.ToolCalls)
			{
				string funcName = call.Function?.Name ?? string.Empty;
				if (string.IsNullOrEmpty(funcName)) continue;
				if (!Calls.TryGetValue(funcName, out var func)) continue;
				var json = await func(call.Function?.Arguments.AsJson() ?? string.Empty, cancellationToken).ConfigureAwait(false);
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