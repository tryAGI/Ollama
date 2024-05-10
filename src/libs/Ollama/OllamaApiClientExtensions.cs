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
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <returns>
	/// A chat instance that can be used to receive and send messages from and to
	/// the Ollama endpoint while maintaining the message history.
	/// </returns>
	public static Chat Chat(
		this OllamaApiClient client,
		string model,
		Action<GenerateChatCompletionResponse>? streamer = null)
	{
		return client.Chat(model, streamer != null
			? new ActionResponseStreamer<GenerateChatCompletionResponse>(streamer)
			: null);
	}

	/// <summary>
	/// Starts a new chat with the currently selected model.
	/// </summary>
	/// <param name="client">The client to start the chat with</param>
	/// <param name="model"></param>
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <returns>
	/// A chat instance that can be used to receive and send messages from and to
	/// the Ollama endpoint while maintaining the message history.
	/// </returns>
	public static Chat Chat(
		this OllamaApiClient client,
		string model,
		IResponseStreamer<GenerateChatCompletionResponse>? streamer = null)
	{
		return new Chat(client, model)
		{
			Streamer = streamer,
		};
	}

	/// <summary>
	/// Sends a request to the /api/chat endpoint
	/// </summary>
	/// <param name="client"></param>
	/// <param name="chatRequest">The request to send to Ollama</param>
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>List of the returned messages including the previous context</returns>
	public static async Task<IEnumerable<Message>> SendChatAsync(
		this OllamaApiClient client,
		GenerateChatCompletionRequest chatRequest,
		Action<GenerateChatCompletionResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		return await client.SendChatAsync(chatRequest, new ActionResponseStreamer<GenerateChatCompletionResponse>(streamer), cancellationToken).ConfigureAwait(false);
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

		await client.CopyModelAsync(new CopyModelRequest { Source = source, Destination = destination }, cancellationToken).ConfigureAwait(false);
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
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task CreateModelAsync(
		this OllamaApiClient client,
		string name,
		string modelFileContent,
		Action<CreateModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		await client.CreateModelAsync(name, modelFileContent, new ActionResponseStreamer<CreateModelResponse>(streamer), cancellationToken).ConfigureAwait(false);
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
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task CreateModelAsync(
		this OllamaApiClient client,
		string name,
		string modelFileContent,
		IResponseStreamer<CreateModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.CreateModelAsync(new CreateModelRequest { Name = name, Modelfile = modelFileContent, Stream = true }, streamer, cancellationToken).ConfigureAwait(false);
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
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task CreateModelAsync(
		this OllamaApiClient client,
		string name,
		string modelFileContent,
		string path,
		Action<CreateModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.CreateModelAsync(new CreateModelRequest
		{
			Name = name,
			Modelfile = modelFileContent,
			Path = path,
			Stream = true
		}, new ActionResponseStreamer<CreateModelResponse>(streamer), cancellationToken).ConfigureAwait(false);
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
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task CreateModelAsync(
		this OllamaApiClient client,
		string name,
		string modelFileContent,
		string path,
		IResponseStreamer<CreateModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.CreateModelAsync(new CreateModelRequest { Name = name, Modelfile = modelFileContent, Path = path, Stream = true }, streamer, cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/pull endpoint to pull a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model">The name of the model to pull</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task PullModelAsync(
		this OllamaApiClient client,
		string model,
		Action<PullModelResponse>? streamer = null,
		CancellationToken cancellationToken = default)
	{
		await client.PullModelAsync(
			model,
			streamer != null
				? new ActionResponseStreamer<PullModelResponse>(streamer)
				: null,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/pull endpoint to pull a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model">The name of the model to pull</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task PullModelAsync(
		this OllamaApiClient client,
		string model,
		IResponseStreamer<PullModelResponse>? streamer = null,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.PullModelAsync(new PullModelRequest { Name = model }, streamer, cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/push endpoint to push a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="name">The name of the model to push</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task PushModelAsync(
		this OllamaApiClient client,
		string name,
		Action<PushModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		await client.PushModelAsync(name, new ActionResponseStreamer<PushModelResponse>(streamer), cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/push endpoint to push a new model
	/// </summary>
	/// <param name="client"></param>
	/// <param name="name">The name of the model to push</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public static async Task PushModelAsync(
		this OllamaApiClient client,
		string name,
		IResponseStreamer<PushModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		await client.PushModelAsync(new PushModelRequest { Name = name, Stream = true }, streamer, cancellationToken).ConfigureAwait(false);
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

	/// <summary>
	/// Sends a request to the /api/generate endpoint to get a completion
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="prompt">The prompt to generate a completion for</param>
	/// <param name="context">
	/// The context that keeps the conversation for a chat-like history.
	/// Should reuse the result from earlier calls if these calls belong together. Can be null initially.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>
	/// A context object that holds the conversation history.
	/// Should be reused for further calls to this method to keep a chat going.
	/// </returns>
	public static async Task<ConversationContextWithResponse> GetCompletionAsync(
		this OllamaApiClient client,
		string model,
		string prompt,
		ConversationContext? context = null,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var request = new GenerateCompletionRequest
		{
			Prompt = prompt,
			Model = model,
			Stream = false,
			Context = context?.Context ?? []
		};

		return await client.GetCompletionAsync(request, cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/generate endpoint to get a completion and streams the returned chunks to a given streamer
	/// that can be used to update the user interface in real-time.
	/// </summary>
	/// <param name="client"></param>
	/// <param name="model"></param>
	/// <param name="prompt">The prompt to generate a completion for</param>
	/// <param name="context">
	/// The context that keeps the conversation for a chat-like history.
	/// Should reuse the result from earlier calls if these calls belong together. Can be null initially.
	/// </param>
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>
	/// A context object that holds the conversation history.
	/// Should be reused for further calls to this method to keep a chat going.
	/// </returns>
	public static async Task<ConversationContext> StreamCompletionAsync(
		this OllamaApiClient client,
		string model,
		string prompt,
		ConversationContext? context,
		Action<GenerateCompletionResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		client = client ?? throw new ArgumentNullException(nameof(client));

		var request = new GenerateCompletionRequest
		{
			Prompt = prompt,
			Model = model,
			Stream = true,
			Context = context?.Context ?? []
		};

		return await client.StreamCompletionAsync(request, new ActionResponseStreamer<GenerateCompletionResponse>(streamer), cancellationToken).ConfigureAwait(false);
	}
}