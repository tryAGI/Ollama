using System.Text;

namespace Ollama;

/// <summary>
/// 
/// </summary>
public static class OllamaApiClientExtensions
{
	/// <summary>
	/// Starts a new chat with the currently selected model.
	/// </summary>
	/// <param name="client">The client to start the chat with</param>
	/// <param name="model"></param>
	/// <returns>
	/// A chat instance that can be used to receive and send messages from and to
	/// the Ollama endpoint while maintaining the message history.
	/// </returns>
	public static Chat Chat(
		this OllamaApiClient client,
		string model)
	{
		return new Chat(client, model);
	}
	
	/// <summary>
	/// Pulls the specified model from the server and ensures the operation was successful. <br/>
	/// Safe to call if model already exists. <br/>
	/// </summary>
	/// <param name="client">The client to pull the model with.</param>
	/// <param name="model">The model to pull.</param>
	/// <param name="insecure">Optional. If set to true, the client will not validate the server's SSL certificate.</param>
	/// <param name="username">Optional. The username to use for authentication.</param>
	/// <param name="password">Optional. The password to use for authentication.</param>
	/// <param name="cancellationToken">Optional. A token to cancel the operation.</param>
	/// <exception cref="ArgumentNullException">Thrown when the client or model is null.</exception>
	/// <exception cref="InvalidOperationException">Thrown when the response status is not "success".</exception>
	public static async Task PullModelAndEnsureSuccessAsync(
		this ModelsClient client,
		string model,
		bool insecure = false,
		string? username = null,
		string? password = null,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));
		model = model ?? throw new ArgumentNullException(nameof(model));
		
		var response = await client.PullModelAsync(
			model: model,
			insecure: insecure,
			username: username,
			password: password,
			stream: false,
			cancellationToken: cancellationToken).WaitAsync().ConfigureAwait(false);
		response.EnsureSuccess();
	}
	
	/// <summary>
	/// Throws an InvalidOperationException if the response is not successful.
	/// </summary>
	/// <param name="response"></param>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static void EnsureSuccess(
		this PullModelResponse response)
	{
		response = response ?? throw new ArgumentNullException(nameof(response));

		if (response.Status?.Value2 != PullModelResponseStatus.Success)
		{
			throw new InvalidOperationException($"Failed to pull model with status {response.Status?.Object}");
		}
	}
	
	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<GenerateCompletionResponse> WaitAsync(
		this IAsyncEnumerable<GenerateCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var text = string.Empty;
		var currentResponse = new GenerateCompletionResponse();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			text += response.Response;
			currentResponse = response;
		}
		
		currentResponse.Response = text;

		return currentResponse;
	}

	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<GenerateChatCompletionResponse> WaitAsync(
		this IAsyncEnumerable<GenerateChatCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		MessageRole? responseRole = null;
		var responseContent = new StringBuilder();
		
		var currentResponse = new GenerateChatCompletionResponse();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			responseRole ??= response.Message?.Role;
			responseContent.Append(response.Message?.Content);
			
			currentResponse = response;
		}
		
		currentResponse.Message = new Message
		{
			Role = responseRole ?? MessageRole.User,
			Content = responseContent.ToString()
		};

		return currentResponse;
	}

	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<T> WaitAsync<T>(
		this IAsyncEnumerable<T> enumerable) where T : new()
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var currentResponse = new T();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			currentResponse = response;
		}

		return currentResponse;
	}
}