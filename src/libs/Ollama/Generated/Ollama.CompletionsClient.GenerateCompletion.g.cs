
#nullable enable

namespace Ollama
{
    public partial class CompletionsClient
    {
        partial void PrepareGenerateCompletionArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.GenerateCompletionRequest request);
        partial void PrepareGenerateCompletionRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.GenerateCompletionRequest request);
        partial void ProcessGenerateCompletionResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Generate a response for a given prompt with a provided model.<br/>
        /// The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateCompletionResponse> GenerateCompletionAsync(
            global::Ollama.GenerateCompletionRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareGenerateCompletionArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Ollama.PathBuilder(
                path: "/generate",
                baseUri: HttpClient.BaseAddress); 
            var __path = __pathBuilder.ToString();
            using var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
            __httpRequest.Version = global::System.Net.HttpVersion.Version11;
            __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif
            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
            var __httpRequestContent = new global::System.Net.Http.StringContent(
                content: __httpRequestContentBody,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");
            __httpRequest.Content = __httpRequestContent;

            PrepareRequest(
                client: HttpClient,
                request: __httpRequest);
            PrepareGenerateCompletionRequest(
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
            ProcessGenerateCompletionResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            try
            {
                __response.EnsureSuccessStatusCode();
            }
            catch (global::System.Net.Http.HttpRequestException __ex)
            {
                throw new global::Ollama.ApiException(
                    message: __response.ReasonPhrase ?? string.Empty,
                    innerException: __ex,
                    statusCode: __response.StatusCode)
                {
                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                        __response.Headers,
                        h => h.Key,
                        h => h.Value),
                };
            }

            using var __stream = await __response.Content.ReadAsStreamAsync(
#if NET5_0_OR_GREATER
                cancellationToken
#endif
            ).ConfigureAwait(false);
            using var __reader = new global::System.IO.StreamReader(__stream);

            while (!__reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var __content = await __reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                var __streamedResponse = global::Ollama.GenerateCompletionResponse.FromJson(__content, JsonSerializerContext) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return __streamedResponse;
            }
        }

        /// <summary>
        /// Generate a response for a given prompt with a provided model.<br/>
        /// The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </param>
        /// <param name="prompt">
        /// The prompt to generate a response.<br/>
        /// Example: Why is the sky blue?
        /// </param>
        /// <param name="suffix">
        /// The text that comes after the inserted text.
        /// </param>
        /// <param name="system">
        /// The system prompt to (overrides what is defined in the Modelfile).
        /// </param>
        /// <param name="template">
        /// The full prompt or prompt template (overrides what is defined in the Modelfile).
        /// </param>
        /// <param name="context">
        /// The context parameter returned from a previous request to [generateCompletion], this can be used to keep a short conversational memory.
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="raw">
        /// If `true` no formatting will be applied to the prompt and no context will be returned. <br/>
        /// You may choose to use the `raw` parameter if you are specifying a full templated prompt in your request to the API, and are managing history yourself.
        /// </param>
        /// <param name="format"></param>
        /// <param name="keepAlive">
        /// How long (in minutes) to keep the model loaded in memory.<br/>
        /// - If set to a positive duration (e.g. 20), the model will stay loaded for the provided duration.<br/>
        /// - If set to a negative duration (e.g. -1), the model will stay loaded indefinitely.<br/>
        /// - If set to 0, the model will be unloaded immediately once finished.<br/>
        /// - If not set, the model will stay loaded for 5 minutes by default
        /// </param>
        /// <param name="images">
        /// (optional) a list of Base64-encoded images to include in the message (for multimodal models such as llava)
        /// </param>
        /// <param name="options">
        /// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
        /// </param>
        /// <param name="think">
        /// Think controls whether thinking/reasoning models will think before<br/>
        /// responding. Needs to be a pointer so we can distinguish between false<br/>
        /// (request that thinking _not_ be used) and unset (use the old behavior<br/>
        /// before this option was introduced).
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateCompletionResponse> GenerateCompletionAsync(
            string model,
            string prompt,
            string? suffix = default,
            string? system = default,
            string? template = default,
            global::System.Collections.Generic.IList<long>? context = default,
            bool? stream = default,
            bool? raw = default,
            global::Ollama.ResponseFormat? format = default,
            int? keepAlive = default,
            global::System.Collections.Generic.IList<string>? images = default,
            global::Ollama.RequestOptions? options = default,
            bool? think = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Ollama.GenerateCompletionRequest
            {
                Model = model,
                Prompt = prompt,
                Suffix = suffix,
                System = system,
                Template = template,
                Context = context,
                Stream = stream,
                Raw = raw,
                Format = format,
                KeepAlive = keepAlive,
                Images = images,
                Options = options,
                Think = think,
            };

            var __enumerable = GenerateCompletionAsync(
                request: __request,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}