
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
                client: _httpClient);
            PrepareGenerateChatCompletionArguments(
                httpClient: _httpClient,
                request: request);

            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri.TrimEnd('/') + "/chat", global::System.UriKind.RelativeOrAbsolute));
            var __json = global::System.Text.Json.JsonSerializer.Serialize(request, global::Ollama.SourceGenerationContext.Default.GenerateChatCompletionRequest);
            httpRequest.Content = new global::System.Net.Http.StringContent(
                content: __json,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");

            PrepareRequest(
                client: _httpClient,
                request: httpRequest);
            PrepareGenerateChatCompletionRequest(
                httpClient: _httpClient,
                httpRequestMessage: httpRequest,
                request: request);

            using var response = await _httpClient.SendAsync(
                request: httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: _httpClient,
                response: response);
            ProcessGenerateChatCompletionResponse(
                httpClient: _httpClient,
                httpResponseMessage: response);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            using var reader = new global::System.IO.StreamReader(stream);

            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var __content = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                var streamedResponse = global::System.Text.Json.JsonSerializer.Deserialize(__content, global::Ollama.SourceGenerationContext.Default.GenerateChatCompletionResponse) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return streamedResponse;
            }
        }

        /// <summary>
        /// Generate the next message in a chat with a provided model.<br/>
        /// This is a streaming endpoint, so there will be a series of responses. The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="messages"></param>
        /// <param name="format"></param>
        /// <param name="options"></param>
        /// <param name="stream"></param>
        /// <param name="keepAlive"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateChatCompletionResponse> GenerateChatCompletionAsync(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.Message> messages,
            global::Ollama.ResponseFormat? format = default,
            global::Ollama.RequestOptions? options = default,
            bool stream = true,
            int? keepAlive = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = new global::Ollama.GenerateChatCompletionRequest
            {
                Model = model,
                Messages = messages,
                Format = format,
                Options = options,
                Stream = stream,
                KeepAlive = keepAlive,
            };

            var enumerable = GenerateChatCompletionAsync(
                request: request,
                cancellationToken: cancellationToken);

            await foreach (var response in enumerable)
            {
                yield return response;
            }
        }
    }
}