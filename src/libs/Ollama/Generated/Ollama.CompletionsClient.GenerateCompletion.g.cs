
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
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateCompletionResponse> GenerateCompletionAsync(
            global::Ollama.GenerateCompletionRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: _httpClient);
            PrepareGenerateCompletionArguments(
                httpClient: _httpClient,
                request: request);

            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri.TrimEnd('/') + "/generate", global::System.UriKind.RelativeOrAbsolute));
            var __json = global::System.Text.Json.JsonSerializer.Serialize(request, global::Ollama.SourceGenerationContext.Default.GenerateCompletionRequest);
            httpRequest.Content = new global::System.Net.Http.StringContent(
                content: __json,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");

            PrepareRequest(
                client: _httpClient,
                request: httpRequest);
            PrepareGenerateCompletionRequest(
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
            ProcessGenerateCompletionResponse(
                httpClient: _httpClient,
                httpResponseMessage: response);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            using var reader = new global::System.IO.StreamReader(stream);

            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var __content = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                var streamedResponse = global::System.Text.Json.JsonSerializer.Deserialize(__content, global::Ollama.SourceGenerationContext.Default.GenerateCompletionResponse) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return streamedResponse;
            }
        }

        /// <summary>
        /// Generate a response for a given prompt with a provided model.<br/>
        /// The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="prompt"></param>
        /// <param name="images"></param>
        /// <param name="system"></param>
        /// <param name="template"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="format"></param>
        /// <param name="raw"></param>
        /// <param name="stream"></param>
        /// <param name="keepAlive"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateCompletionResponse> GenerateCompletionAsync(
            string model,
            string prompt,
            global::System.Collections.Generic.IList<string?>? images = default,
            string? system = default,
            string? template = default,
            global::System.Collections.Generic.IList<long>? context = default,
            global::Ollama.RequestOptions? options = default,
            global::Ollama.ResponseFormat? format = default,
            bool raw = default,
            bool stream = true,
            int? keepAlive = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = new global::Ollama.GenerateCompletionRequest
            {
                Model = model,
                Prompt = prompt,
                Images = images,
                System = system,
                Template = template,
                Context = context,
                Options = options,
                Format = format,
                Raw = raw,
                Stream = stream,
                KeepAlive = keepAlive,
            };

            var enumerable = GenerateCompletionAsync(
                request: request,
                cancellationToken: cancellationToken);

            await foreach (var response in enumerable)
            {
                yield return response;
            }
        }
    }
}