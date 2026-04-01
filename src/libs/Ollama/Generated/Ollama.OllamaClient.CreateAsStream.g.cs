
#nullable enable

namespace Ollama
{
    public partial class OllamaClient
    {
        partial void PrepareCreateAsStreamArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.CreateRequest request);
        partial void PrepareCreateAsStreamRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.CreateRequest request);
        partial void ProcessCreateAsStreamResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Create a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/create -d '{<br/>
        ///   "from": "gemma3",<br/>
        ///   "model": "alpaca",<br/>
        ///   "system": "You are Alpaca, a helpful AI assistant. You only answer with Emojis."<br/>
        /// }'
        /// </remarks>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> CreateAsStreamAsync(

            global::Ollama.CreateRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            request = new global::Ollama.CreateRequest
            {
                Model = request.Model,
                From = request.From,
                Template = request.Template,
                License = request.License,
                System = request.System,
                Parameters = request.Parameters,
                Messages = request.Messages,
                Quantize = request.Quantize,
                Stream = true,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareCreateAsStreamArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Ollama.PathBuilder(
                path: "/api/create",
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
            PrepareCreateAsStreamRequest(
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
            ProcessCreateAsStreamResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);

            try
            {
                __response.EnsureSuccessStatusCode();
            }
            catch (global::System.Net.Http.HttpRequestException __ex)
            {
                string? __content = null;
                try
                {
                    __content = await __response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                        cancellationToken
#endif
                    ).ConfigureAwait(false);
                }
                catch (global::System.Exception)
                {
                }

                throw new global::Ollama.ApiException(
                    message: __content ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __ex,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content,
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

                var __streamedResponse = global::Ollama.StatusEvent.FromJson(__content, JsonSerializerContext) ??
                                       throw new global::Ollama.ApiException(
                                           message: $"Response deserialization failed for \"{__content}\" ",
                                           statusCode: __response.StatusCode)
                                       {
                                           ResponseBody = __content,
                                           ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                               __response.Headers,
                                               h => h.Key,
                                               h => h.Value),
                                       };

                yield return __streamedResponse;
            }
        }
        /// <summary>
        /// Create a model
        /// </summary>
        /// <param name="model">
        /// Name for the model to create
        /// </param>
        /// <param name="from">
        /// Existing model to create from
        /// </param>
        /// <param name="template">
        /// Prompt template to use for the model
        /// </param>
        /// <param name="license">
        /// License string or list of licenses for the model
        /// </param>
        /// <param name="system">
        /// System prompt to embed in the model
        /// </param>
        /// <param name="parameters">
        /// Key-value parameters for the model
        /// </param>
        /// <param name="messages">
        /// Message history to use for the model
        /// </param>
        /// <param name="quantize">
        /// Quantization level to apply (e.g. `q4_K_M`, `q8_0`)
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> CreateAsStreamAsync(
            string model,
            string? from = default,
            string? template = default,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? license = default,
            string? system = default,
            object? parameters = default,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? messages = default,
            string? quantize = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Ollama.CreateRequest
            {
                Model = model,
                From = from,
                Template = template,
                License = license,
                System = system,
                Parameters = parameters,
                Messages = messages,
                Quantize = quantize,
                Stream = true,
            };

            var __enumerable = CreateAsStreamAsync(
                request: __request,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}