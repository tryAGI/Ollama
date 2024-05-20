namespace Ollama;

/// <summary>
/// 
/// </summary>
public class Chat
{
	/// <summary>
	/// 
	/// </summary>
	public IList<Message> History { get; } = new List<Message>();

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
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <exception cref="ArgumentNullException"></exception>
	public Chat(OllamaApiClient client, string model)
	{
		Client = client ?? throw new ArgumentNullException(nameof(client));
		Model = model ?? throw new ArgumentNullException(nameof(model));
	}

	/// <summary>
	/// Sends a message to the currently selected model
	/// </summary>
	/// <param name="message">The message to send</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public Task<Message> SendAsync(
		string message,
		CancellationToken cancellationToken = default)
	{
		return SendAsync(message, null, cancellationToken);
	}

	/// <summary>
	/// Sends a message to the currently selected model
	/// </summary>
	/// <param name="message">The message to send</param>
	/// <param name="imagesAsBase64">Base64 encoded images to send to the model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public Task<Message> SendAsync(
		string message,
		IEnumerable<string>? imagesAsBase64,
		CancellationToken cancellationToken = default)
	{
		return SendAsAsync(MessageRole.User, message, imagesAsBase64, cancellationToken);
	}

	/// <summary>
	/// Sends a message in a given role to the currently selected model
	/// </summary>
	/// <param name="role">The role in which the message should be sent</param>
	/// <param name="message">The message to send</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public Task<Message> SendAsAsync(
		string role,
		string message,
		CancellationToken cancellationToken = default)
	{
		return SendAsAsync(role, message, null, cancellationToken);
	}

	/// <summary>
	/// Sends a message in a given role to the currently selected model
	/// </summary>
	/// <param name="role">The role in which the message should be sent</param>
	/// <param name="message">The message to send</param>
	/// <param name="imagesAsBase64">Base64 encoded images to send to the model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task<Message> SendAsAsync(
		string role,
		string message,
		IEnumerable<string?>? imagesAsBase64,
		CancellationToken cancellationToken = default)
	{
		History.Add(new Message
		{
			Content = message,
			Role = role,
			Images = imagesAsBase64?.ToList() ?? [],
		});

		var request = new GenerateChatCompletionRequest
		{
			Messages = History.ToList(),
			Model = Model,
			Stream = true,
		};

		var answer = await Client.GenerateChatCompletionAsync(request, cancellationToken).WaitAsync().ConfigureAwait(false);
		if (answer.Message == null)
		{
			throw new InvalidOperationException("Response message was null.");
		}
		
		History.Add(answer.Message);
		
		return answer.Message;
	}
}