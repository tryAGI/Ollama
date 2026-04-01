
#nullable enable

namespace Ollama
{
    public partial class OllamaClient
    {
        partial void PrepareChatAsStreamArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.ChatRequest request);
        partial void PrepareChatAsStreamRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.ChatRequest request);
        partial void ProcessChatAsStreamResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Generate a chat message<br/>
        /// Generate the next chat message in a conversation between a user and an assistant.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/chat -d '{<br/>
        ///   "model": "gemma3",<br/>
        ///   "messages": [<br/>
        ///     {<br/>
        ///       "role": "user",<br/>
        ///       "content": "why is the sky blue?"<br/>
        ///     }<br/>
        ///   ]<br/>
        /// }'
        /// </remarks>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.ChatStreamEvent> ChatAsStreamAsync(

            global::Ollama.ChatRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));


            request = new global::Ollama.ChatRequest
            {
                Model = request.Model,
                Messages = request.Messages,
                Tools = request.Tools,
                Format = request.Format,
                Options = request.Options,
                Stream = true,
                Think = request.Think,
                KeepAlive = request.KeepAlive,
                Logprobs = request.Logprobs,
                TopLogprobs = request.TopLogprobs,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareChatAsStreamArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Ollama.PathBuilder(
                path: "/api/chat",
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
            PrepareChatAsStreamRequest(
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
            ProcessChatAsStreamResponse(
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

                var __streamedResponse = global::Ollama.ChatStreamEvent.FromJson(__content, JsonSerializerContext) ??
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
        /// Generate a chat message<br/>
        /// Generate the next chat message in a conversation between a user and an assistant.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="messages">
        /// Chat history as an array of message objects (each with a role and content)
        /// </param>
        /// <param name="tools">
        /// Optional list of function tools the model may call during the chat
        /// </param>
        /// <param name="format">
        /// Format to return a response in. Can be `json` or a JSON schema
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="think">
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="logprobs">
        /// Whether to return log probabilities of the output tokens
        /// </param>
        /// <param name="topLogprobs">
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.ChatStreamEvent> ChatAsStreamAsync(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage> messages,
            global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? tools = default,
            global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? format = default,
            global::Ollama.ModelOptions? options = default,
            global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>? think = default,
            global::Ollama.OneOf<string, double?>? keepAlive = default,
            bool? logprobs = default,
            int? topLogprobs = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {

            var __request = new global::Ollama.ChatRequest
            {
                Model = model,
                Messages = messages,
                Tools = tools,
                Format = format,
                Options = options,
                Stream = true,
                Think = think,
                KeepAlive = keepAlive,
                Logprobs = logprobs,
                TopLogprobs = topLogprobs,
            };

            var __enumerable = ChatAsStreamAsync(
                request: __request,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}