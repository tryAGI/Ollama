
#nullable enable

namespace Ollama
{
    public partial class ChatClient
    {
        partial void PrepareGenerateChatCompletionArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.GenerateChatCompletionRequest request);
        partial void PrepareGenerateChatCompletionRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.GenerateChatCompletionRequest request);
        partial void ProcessGenerateChatCompletionResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Generate the next message in a chat with a provided model.<br/>
        /// This is a streaming endpoint, so there will be a series of responses. The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateChatCompletionResponse> GenerateChatCompletionAsync(
            global::Ollama.GenerateChatCompletionRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareGenerateChatCompletionArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new PathBuilder(
                path: "/chat",
                baseUri: HttpClient.BaseAddress); 
            var __path = __pathBuilder.ToString();
            using var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
            var __httpRequestContent = new global::System.Net.Http.StringContent(
                content: __httpRequestContentBody,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");
            __httpRequest.Content = __httpRequestContent;

            PrepareRequest(
                client: HttpClient,
                request: __httpRequest);
            PrepareGenerateChatCompletionRequest(
                httpClient: HttpClient,
                httpRequestMessage: __httpRequest,
                request: request);

            using var __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: HttpClient,
                response: __response);
            ProcessGenerateChatCompletionResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            __response.EnsureSuccessStatusCode();

            using var stream = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            using var reader = new global::System.IO.StreamReader(stream);

            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var __content = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                var streamedResponse = global::Ollama.GenerateChatCompletionResponse.FromJson(__content, JsonSerializerContext) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return streamedResponse;
            }
        }

        /// <summary>
        /// Generate the next message in a chat with a provided model.<br/>
        /// This is a streaming endpoint, so there will be a series of responses. The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </param>
        /// <param name="messages">
        /// The messages of the chat, this can be used to keep a chat memory
        /// </param>
        /// <param name="format">
        /// The format to return a response in. Currently the only accepted value is json.<br/>
        /// Enable JSON mode by setting the format parameter to json. This will structure the response as valid JSON.<br/>
        /// Note: it's important to instruct the model to use JSON in the prompt. Otherwise, the model may generate large amounts whitespace.
        /// </param>
        /// <param name="options">
        /// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="keepAlive">
        /// How long (in minutes) to keep the model loaded in memory.<br/>
        /// - If set to a positive duration (e.g. 20), the model will stay loaded for the provided duration.<br/>
        /// - If set to a negative duration (e.g. -1), the model will stay loaded indefinitely.<br/>
        /// - If set to 0, the model will be unloaded immediately once finished.<br/>
        /// - If not set, the model will stay loaded for 5 minutes by default
        /// </param>
        /// <param name="tools">
        /// A list of tools the model may call.
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateChatCompletionResponse> GenerateChatCompletionAsync(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.Message> messages,
            global::Ollama.ResponseFormat? format = default,
            global::Ollama.RequestOptions? options = default,
            bool? stream = true,
            int? keepAlive = default,
            global::System.Collections.Generic.IList<global::Ollama.Tool>? tools = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Ollama.GenerateChatCompletionRequest
            {
                Model = model,
                Messages = messages,
                Format = format,
                Options = options,
                Stream = stream,
                KeepAlive = keepAlive,
                Tools = tools,
            };

            var __enumerable = GenerateChatCompletionAsync(
                request: __request,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}