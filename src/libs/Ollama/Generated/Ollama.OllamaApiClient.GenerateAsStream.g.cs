
#nullable enable

namespace Ollama
{
    public partial class OllamaApiClient
    {
        partial void PrepareGenerateAsStreamArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.GenerateRequest request);
        partial void PrepareGenerateAsStreamRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.GenerateRequest request);
        partial void ProcessGenerateAsStreamResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Generate a response<br/>
        /// Generates a response for the provided prompt
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateStreamEvent> GenerateAsStreamAsync(

            global::Ollama.GenerateRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));


            request = new global::Ollama.GenerateRequest
            {
                Model = request.Model,
                Prompt = request.Prompt,
                Suffix = request.Suffix,
                Images = request.Images,
                Format = request.Format,
                System = request.System,
                Stream = true,
                Think = request.Think,
                Raw = request.Raw,
                KeepAlive = request.KeepAlive,
                Options = request.Options,
                Logprobs = request.Logprobs,
                TopLogprobs = request.TopLogprobs,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareGenerateAsStreamArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Ollama.PathBuilder(
                path: "/api/generate",
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
            PrepareGenerateAsStreamRequest(
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
            ProcessGenerateAsStreamResponse(
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
                if (global::System.String.IsNullOrWhiteSpace(__content))
                {
                    continue;
                }

                var __streamedResponse = global::Ollama.GenerateStreamEvent.FromJson(__content, JsonSerializerContext) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return __streamedResponse;
            }
        }

        /// <summary>
        /// Generate a response<br/>
        /// Generates a response for the provided prompt
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="prompt">
        /// Text for the model to generate a response from
        /// </param>
        /// <param name="suffix">
        /// Used for fill-in-the-middle models, text that appears after the user prompt and before the model response
        /// </param>
        /// <param name="images"></param>
        /// <param name="format">
        /// Structured output format for the model to generate a response from. Supports either the string `"json"` or a JSON schema object.
        /// </param>
        /// <param name="system">
        /// System prompt for the model to generate a response from
        /// </param>
        /// <param name="think">
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </param>
        /// <param name="raw">
        /// When true, returns the raw response from the model without any prompt templating
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="logprobs">
        /// Whether to return log probabilities of the output tokens
        /// </param>
        /// <param name="topLogprobs">
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateStreamEvent> GenerateAsStreamAsync(
            string model,
            string? prompt = default,
            string? suffix = default,
            global::System.Collections.Generic.IList<string>? images = default,
            global::Ollama.OneOf<string, object>? format = default,
            string? system = default,
            global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>? think = default,
            bool? raw = default,
            global::Ollama.OneOf<string, double?>? keepAlive = default,
            global::Ollama.ModelOptions? options = default,
            bool? logprobs = default,
            int? topLogprobs = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Ollama.GenerateRequest
            {
                Model = model,
                Prompt = prompt,
                Suffix = suffix,
                Images = images,
                Format = format,
                System = system,
                Stream = true,
                Think = think,
                Raw = raw,
                KeepAlive = keepAlive,
                Options = options,
                Logprobs = logprobs,
                TopLogprobs = topLogprobs,
            };

            var __enumerable = GenerateAsStreamAsync(
                request: __request,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}