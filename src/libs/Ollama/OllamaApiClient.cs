using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Ollama;

/// <summary>
/// https://github.com/jmorganca/ollama/blob/main/docs/api.md
/// </summary>
public class OllamaApiClient
{
	private readonly HttpClient _client;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="url"></param>
	public OllamaApiClient(string url)
		: this(new Uri(url))
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="uri"></param>
	public OllamaApiClient(Uri uri)
		: this(new HttpClient { BaseAddress = uri })
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="ArgumentNullException"></exception>
	public OllamaApiClient() : this(new HttpClient { BaseAddress = new Uri("http://localhost:11434/") })
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="client"></param>
	/// <exception cref="ArgumentNullException"></exception>
	public OllamaApiClient(HttpClient client)
	{
		_client = client ?? throw new ArgumentNullException(nameof(client));
		_client.BaseAddress ??= new Uri("http://localhost:11434/");
	}

	/// <summary>
	/// Sends a request to the /api/create endpoint to create a model
	/// </summary>
	/// <param name="request">The parameters for the model to create</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task CreateModelAsync(
		CreateModelRequest request,
		IResponseStreamer<CreateModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		await StreamPostAsync(
			"api/create",
			request,
			streamer,
			SourceGenerationContext.Default.CreateModelRequest,
			SourceGenerationContext.Default.CreateModelResponse,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/delete endpoint to delete a model
	/// </summary>
	/// <param name="model">The name of the model to delete</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task DeleteModelAsync(
		string model,
		CancellationToken cancellationToken = default)
	{
		using var request = new HttpRequestMessage(HttpMethod.Delete, "api/delete");
		request.Content = new StringContent(
			JsonSerializer.Serialize(new DeleteModelRequest { Name = model }, SourceGenerationContext.Default.DeleteModelRequest),
			Encoding.UTF8,
			"application/json");

		using var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
	}

	/// <summary>
	/// Sends a request to the /api/tags endpoint to get all models that are available locally
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task<IReadOnlyList<Model>> ListModelsAsync(
		CancellationToken cancellationToken = default)
	{
		var data = await GetAsync(
			"api/tags",
			SourceGenerationContext.Default.ModelsResponse,
			cancellationToken).ConfigureAwait(false);
		
		return data.Models?
			.Where(x => x != null)
			.Select(x => x!)
			.ToArray() ?? [];
	}
	
	/// <summary>
	/// Sends a request to the /api/show endpoint to show the information of a model
	/// </summary>
	/// <param name="model">The name of the model the get the information for</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>The model information</returns>
	public async Task<ModelInfo> ShowModelInformationAsync(
		string model,
		CancellationToken cancellationToken = default)
	{
		return await PostAsync(
			"api/show",
			new ModelInfoRequest { Name = model },
			SourceGenerationContext.Default.ModelInfoRequest,
			SourceGenerationContext.Default.ModelInfo,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/copy endpoint to copy a model
	/// </summary>
	/// <param name="request">The parameters required to copy a model</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task CopyModelAsync(
		CopyModelRequest request,
		CancellationToken cancellationToken = default)
	{
		await PostAsync(
			"api/copy",
			request,
			SourceGenerationContext.Default.CopyModelRequest,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/pull endpoint to pull a new model
	/// </summary>
	/// <param name="request">The request parameters</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task PullModelAsync(
		PullModelRequest request,
		IResponseStreamer<PullModelResponse>? streamer = null,
		CancellationToken cancellationToken = default)
	{
		await StreamPostAsync(
			"api/pull",
			request,
			streamer,
			SourceGenerationContext.Default.PullModelRequest,
			SourceGenerationContext.Default.PullModelResponse,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/push endpoint to push a new model
	/// </summary>
	/// <param name="request">The request parameters</param>
	/// <param name="streamer">
	/// The streamer that receives status updates as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the operation is running.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task PushModelAsync(
		PushModelRequest request,
		IResponseStreamer<PushModelResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		await StreamPostAsync(
			"api/push",
			request,
			streamer,
			SourceGenerationContext.Default.PushModelRequest,
			SourceGenerationContext.Default.PushModelResponse,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/embeddings endpoint to generate embeddings
	/// </summary>
	/// <param name="request">The parameters to generate embeddings for</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	public async Task<GenerateEmbeddingResponse> GenerateEmbeddingsAsync(
		GenerateEmbeddingRequest request,
		CancellationToken cancellationToken = default)
	{
		return await PostAsync(
			"api/embeddings",
			request,
			SourceGenerationContext.Default.GenerateEmbeddingRequest,
			SourceGenerationContext.Default.GenerateEmbeddingResponse,
			cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/generate endpoint to get a completion and streams the returned chunks to a given streamer
	/// that can be used to update the user interface in real-time.
	/// </summary>
	/// <param name="request">The parameters to generate a completion for</param>
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>
	/// A context object that holds the conversation history.
	/// Should be reused for further calls to this method to keep a chat going.
	/// </returns>
	public async Task<ConversationContext> StreamCompletionAsync(
		GenerateCompletionRequest request,
		IResponseStreamer<GenerateCompletionResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		request = request ?? throw new ArgumentNullException(nameof(request));
		
		return await GenerateCompletionAsync(request, streamer, cancellationToken).ConfigureAwait(false);
	}

	/// <summary>
	/// Sends a request to the /api/generate endpoint to get a completion
	/// </summary>
	/// <param name="request">The parameters to generate a completion</param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>
	/// A context object that holds the conversation history.
	/// Should be reused for further calls to this method to keep a chat going.
	/// </returns>
	public async Task<ConversationContextWithResponse> GetCompletionAsync(
		GenerateCompletionRequest request,
		CancellationToken cancellationToken = default)
	{
		request = request ?? throw new ArgumentNullException(nameof(request));

		var builder = new StringBuilder();
		var result = await GenerateCompletionAsync(request, new ActionResponseStreamer<GenerateCompletionResponse>(status => builder.Append(status.Response)), cancellationToken).ConfigureAwait(false);
		return new ConversationContextWithResponse(builder.ToString(), result.Context);
	}

	/// <summary>
	/// Sends a request to the /api/chat endpoint
	/// </summary>
	/// <param name="chatRequest">The request to send to Ollama</param>
	/// <param name="streamer">
	/// The streamer that receives parts of the answer as they are streamed by the Ollama endpoint.
	/// Can be used to update the user interface while the answer is still being generated.
	/// </param>
	/// <param name="cancellationToken">The token to cancel the operation with</param>
	/// <returns>List of the returned messages including the previous context</returns>
	public async Task<IEnumerable<Message>> SendChatAsync(
		GenerateChatCompletionRequest chatRequest,
		IResponseStreamer<GenerateChatCompletionResponse>? streamer = null,
		CancellationToken cancellationToken = default)
	{
		chatRequest = chatRequest ?? throw new ArgumentNullException(nameof(chatRequest));

		using var request = new HttpRequestMessage(HttpMethod.Post, "api/chat");
		request.Content = new StringContent(JsonSerializer.Serialize(chatRequest, SourceGenerationContext.Default.GenerateChatCompletionRequest), Encoding.UTF8, "application/json");

		var completion = chatRequest.Stream ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead;

		using var response = await _client.SendAsync(request, completion, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();

		return await ProcessStreamedChatResponseAsync(chatRequest, response, streamer, cancellationToken).ConfigureAwait(false);
	}

	private async Task<ConversationContext> GenerateCompletionAsync(
		GenerateCompletionRequest generateRequest,
		IResponseStreamer<GenerateCompletionResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		using var request = new HttpRequestMessage(HttpMethod.Post, "api/generate");
		request.Content = new StringContent(JsonSerializer.Serialize(generateRequest, SourceGenerationContext.Default.GenerateCompletionRequest), Encoding.UTF8, "application/json");

		var completion = generateRequest.Stream ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead;

		using var response = await _client.SendAsync(request, completion, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();

		return await ProcessStreamedCompletionResponseAsync(response, streamer, cancellationToken).ConfigureAwait(false);
	}

	private async Task<TResponse> GetAsync<TResponse>(
		string endpoint,
		JsonTypeInfo<TResponse> jsonTypeInfo,
		CancellationToken cancellationToken = default)
	{
		using var response = await _client.GetAsync(new Uri(endpoint, UriKind.RelativeOrAbsolute), cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();

		var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
		return JsonSerializer.Deserialize(responseBody, jsonTypeInfo) ??
		       throw new InvalidOperationException("Response deserialization failed.");
	}

	private async Task PostAsync<TRequest>(
		string endpoint,
		TRequest request,
		JsonTypeInfo<TRequest> jsonTypeInfo,
		CancellationToken cancellationToken = default)
	{
		using var content = new StringContent(JsonSerializer.Serialize(request, jsonTypeInfo), Encoding.UTF8, "application/json");
		var response = await _client.PostAsync(new Uri(endpoint, UriKind.RelativeOrAbsolute), content, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
	}

	private async Task<TResponse> PostAsync<TRequest, TResponse>(
		string endpoint,
		TRequest request,
		JsonTypeInfo<TRequest> requestJsonTypeInfo,
		JsonTypeInfo<TResponse> responseJsonTypeInfo,
		CancellationToken cancellationToken = default)
	{
		using var content = new StringContent(JsonSerializer.Serialize(request, requestJsonTypeInfo), Encoding.UTF8, "application/json");
		var response = await _client.PostAsync(new Uri(endpoint, UriKind.RelativeOrAbsolute), content, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();

		var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

		return JsonSerializer.Deserialize(responseBody, responseJsonTypeInfo) ??
		       throw new InvalidOperationException("Response deserialization failed.");
	}

	private async Task StreamPostAsync<TRequest, TResponse>(
		string endpoint,
		TRequest requestModel,
		IResponseStreamer<TResponse>? streamer,
		JsonTypeInfo<TRequest> requestJsonTypeInfo,
		JsonTypeInfo<TResponse> responseJsonTypeInfo,
		CancellationToken cancellationToken = default)
	{
		using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
		request.Content = new StringContent(JsonSerializer.Serialize(requestModel, requestJsonTypeInfo), Encoding.UTF8, "application/json");

		using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();

		await ProcessStreamedResponseAsync(response, streamer, responseJsonTypeInfo, cancellationToken).ConfigureAwait(false);
	}

	private static async Task ProcessStreamedResponseAsync<TLine>(
		HttpResponseMessage response,
		IResponseStreamer<TLine>? streamer,
		JsonTypeInfo<TLine> jsonTypeInfo,
		CancellationToken cancellationToken = default)
	{
		using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		using var reader = new StreamReader(stream);

		while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
		{
			string line = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
			var streamedResponse = JsonSerializer.Deserialize(line, jsonTypeInfo) ??
			                       throw new InvalidOperationException("Response deserialization failed.");
			streamer?.Stream(streamedResponse);
		}
	}

	private static async Task<ConversationContext> ProcessStreamedCompletionResponseAsync(
		HttpResponseMessage response,
		IResponseStreamer<GenerateCompletionResponse> streamer,
		CancellationToken cancellationToken = default)
	{
		using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		using var reader = new StreamReader(stream);

		while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
		{
			string line = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
			var streamedResponse = JsonSerializer.Deserialize(line, SourceGenerationContext.Default.GenerateCompletionResponse) ??
			                       throw new InvalidOperationException("Response deserialization failed.");
			streamer.Stream(streamedResponse);

			if (streamedResponse.Done)
			{
				var doneResponse = JsonSerializer.Deserialize(line, SourceGenerationContext.Default.GenerateCompletionResponse) ??
				                   throw new InvalidOperationException("Response deserialization failed.");
				return new ConversationContext(doneResponse.Context?.ToArray() ?? []);
			}
		}

		return new ConversationContext(Array.Empty<long>());
	}

	private static async Task<IEnumerable<Message>> ProcessStreamedChatResponseAsync(
		GenerateChatCompletionRequest chatRequest,
		HttpResponseMessage response,
		IResponseStreamer<GenerateChatCompletionResponse>? streamer = null,
		CancellationToken cancellationToken = default)
	{
		using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		using var reader = new StreamReader(stream);

		string? responseRole = null;
		var responseContent = new StringBuilder();

		while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
		{
			string line = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;

			var streamedResponse = JsonSerializer.Deserialize(line, SourceGenerationContext.Default.GenerateChatCompletionResponse) ??
			                       throw new InvalidOperationException("Response deserialization failed.");

			// keep the streamed content to build the last message
			// to return the list of messages
			responseRole ??= streamedResponse.Message?.Role;
			responseContent.Append(streamedResponse.Message?.Content);

			streamer?.Stream(streamedResponse);

			if (streamedResponse.Done)
			{
				var doneResponse = JsonSerializer.Deserialize(line, SourceGenerationContext.Default.GenerateChatCompletionResponse) ??
				                   throw new InvalidOperationException("Response deserialization failed.");
				var messages = chatRequest.Messages.ToList();
				messages.Add(new Message
				{
					Role = responseRole ?? MessageRole.User,
					Content = responseContent.ToString()
				});
				return messages;
			}
		}

		return Array.Empty<Message>();
	}
}

/// <summary>
/// 
/// </summary>
/// <param name="Context"></param>
public record ConversationContext(IList<long> Context);

/// <summary>
/// 
/// </summary>
/// <param name="Response"></param>
/// <param name="Context"></param>
public record ConversationContextWithResponse(string Response, IList<long> Context) : ConversationContext(Context);

[JsonSerializable(typeof(DeleteModelRequest))]
[JsonSerializable(typeof(GenerateCompletionRequest))]
[JsonSerializable(typeof(GenerateCompletionResponse))]
[JsonSerializable(typeof(GenerateChatCompletionRequest))]
[JsonSerializable(typeof(GenerateChatCompletionResponse))]
[JsonSerializable(typeof(PushModelRequest))]
[JsonSerializable(typeof(PushModelResponse))]
[JsonSerializable(typeof(PullModelRequest))]
[JsonSerializable(typeof(PullModelResponse))]
[JsonSerializable(typeof(CreateModelRequest))]
[JsonSerializable(typeof(CreateModelResponse))]
[JsonSerializable(typeof(GenerateEmbeddingRequest))]
[JsonSerializable(typeof(GenerateEmbeddingResponse))]
[JsonSerializable(typeof(CopyModelRequest))]
[JsonSerializable(typeof(ModelInfoRequest))]
[JsonSerializable(typeof(ModelInfo))]
[JsonSerializable(typeof(ModelsResponse))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;