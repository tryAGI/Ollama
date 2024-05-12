using System.Runtime.CompilerServices;
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
	/// Sends a request to the /api/chat endpoint
	/// </summary>
	/// <param name="client"></param>
	/// <param name="chatRequest">The request to send to Ollama</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>List of the returned messages including the previous context</returns>
	public static async IAsyncEnumerable<GenerateChatCompletionResponse> SendChatAsync(
		this OllamaApiClient client,
		GenerateChatCompletionRequest chatRequest,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var enumerable = client.SendChatAsync(chatRequest, cancellationToken).ConfigureAwait(false);
		
		await foreach (var response in enumerable)
		{
			yield return response;
		}
	}

	/// <summary>
	/// Sends a request to the /api/copy endpoint to copy a model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="source">The name of the existing model to copy</param>
	/// <param name="destination">The name the copied model should get</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task CopyModelAsync(
		this OllamaApiClient client,
		string source,
		string destination,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.CopyModelAsync(new CopyModelRequest
		{
			Source = source,
			Destination = destination,
		}, cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/create endpoint to create a model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="name">The name for the new model</param>
	/// <param name="modelFileContent">
	/// The file content for the model file the new model should be built with.
	/// See https://github.com/jmorganca/ollama/blob/main/docs/modelfile.md
	/// </param>
	/// <param name="path">The name path to the model file</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async IAsyncEnumerable<CreateModelResponse> CreateModelAsync(
		this OllamaApiClient client,
		string name,
		string modelFileContent,
		string? path = null,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var enumerable = client.CreateModelAsync(new CreateModelRequest
		{
			Model = name,
			Modelfile = modelFileContent,
			Path = path,
			Stream = true,
		}, cancellationToken).ConfigureAwait(false);
		
		await foreach (var response in enumerable)
		{
			yield return response;
		}
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

		if (response.Status != "success")
		{
			throw new InvalidOperationException($"Failed to pull model with status {response.Status}");
		}
	}
	
	/// <summary>
	/// Sends a request to the /api/pull endpoint to pull a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model">The name of the model to pull</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async IAsyncEnumerable<PullModelResponse> PullModelAsync(
		this OllamaApiClient client,
		string model,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var enumerable = client.PullModelAsync(new PullModelRequest
		{
			Model = model,
		}, cancellationToken).ConfigureAwait(false);
		
		await foreach (var response in enumerable)
		{
			yield return response;
		}
	}

	/// <summary>
	/// Sends a request to the /api/push endpoint to push a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="name">The name of the model to push</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async IAsyncEnumerable<PushModelResponse> PushModelAsync(
		this OllamaApiClient client,
		string name,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var enumerable = client.PushModelAsync(new PushModelRequest
		{
			Model = name,
			Stream = true,
		}, cancellationToken).ConfigureAwait(false);
		
		await foreach (var response in enumerable)
		{
			yield return response;
		}
	}

	/// <summary>
	/// Sends a request to the /api/embeddings endpoint to generate embeddings for the currently selected model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="prompt">The prompt to generate embeddings for</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task<GenerateEmbeddingResponse> GenerateEmbeddingsAsync(
		this OllamaApiClient client,
		string model,
		string prompt,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		return await client.GenerateEmbeddingsAsync(new GenerateEmbeddingRequest
		{
			Model = model,
			Prompt = prompt,
		}, cancellationToken).ConfigureAwait(false);
	}

	/// <inheritdoc cref="OllamaApiClient.GetCompletionAsync"/>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="prompt">The prompt to generate a completion for</param>
	/// <param name="context">
	/// The context that keeps the conversation for a chat-like history.
	/// Should reuse the result from earlier calls if these calls belong together. Can be null initially.
	/// </param>
	/// <param name="stream"></param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async IAsyncEnumerable<GenerateCompletionResponse> GetCompletionAsync(
		this OllamaApiClient client,
		string model,
		string prompt,
		bool stream = true,
		IList<long>? context = null,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var enumerable = client.GetCompletionAsync(new GenerateCompletionRequest
		{
			Prompt = prompt,
			Model = model,
			Stream = stream,
			Context = context ?? [],
		}, cancellationToken).ConfigureAwait(false);
		
		await foreach (var response in enumerable)
		{
			yield return response;
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
		await foreach (var response in enumerable)
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
		
		string? responseRole = null;
		var responseContent = new StringBuilder();
		
		var currentResponse = new GenerateChatCompletionResponse();
		await foreach (var response in enumerable)
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
		await foreach (var response in enumerable)
		{
			currentResponse = response;
		}

		return currentResponse;
	}
}