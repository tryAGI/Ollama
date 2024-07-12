
#nullable enable

namespace Ollama
{
    public partial class ModelsClient
    {
        partial void PrepareCreateModelArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Ollama.CreateModelRequest request);
        partial void PrepareCreateModelRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Ollama.CreateModelRequest request);
        partial void ProcessCreateModelResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Create a model from a Modelfile.<br/>
        /// It is recommended to set `modelfile` to the content of the Modelfile rather than just set `path`. This is a requirement for remote create. Remote model creation should also create any file blobs, fields such as `FROM` and `ADAPTER`, explicitly with the server using Create a Blob and the value to the path indicated in the response.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.CreateModelResponse> CreateModelAsync(
            global::Ollama.CreateModelRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: _httpClient);
            PrepareCreateModelArguments(
                httpClient: _httpClient,
                request: request);

            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri.TrimEnd('/') + "/create", global::System.UriKind.RelativeOrAbsolute));
            var __json = global::System.Text.Json.JsonSerializer.Serialize(request, global::Ollama.SourceGenerationContext.Default.CreateModelRequest);
            httpRequest.Content = new global::System.Net.Http.StringContent(
                content: __json,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");

            PrepareRequest(
                client: _httpClient,
                request: httpRequest);
            PrepareCreateModelRequest(
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
            ProcessCreateModelResponse(
                httpClient: _httpClient,
                httpResponseMessage: response);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            using var reader = new global::System.IO.StreamReader(stream);

            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var __content = await reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                var streamedResponse = global::System.Text.Json.JsonSerializer.Deserialize(__content, global::Ollama.SourceGenerationContext.Default.CreateModelResponse) ??
                                       throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");

                yield return streamedResponse;
            }
        }

        /// <summary>
        /// Create a model from a Modelfile.<br/>
        /// It is recommended to set `modelfile` to the content of the Modelfile rather than just set `path`. This is a requirement for remote create. Remote model creation should also create any file blobs, fields such as `FROM` and `ADAPTER`, explicitly with the server using Create a Blob and the value to the path indicated in the response.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelfile"></param>
        /// <param name="path"></param>
        /// <param name="quantize"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.CreateModelResponse> CreateModelAsync(
            string model,
            string modelfile,
            string? path = default,
            string? quantize = default,
            bool stream = true,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = new global::Ollama.CreateModelRequest
            {
                Model = model,
                Modelfile = modelfile,
                Path = path,
                Quantize = quantize,
                Stream = stream,
            };

            var enumerable = CreateModelAsync(
                request: request,
                cancellationToken: cancellationToken);

            await foreach (var response in enumerable)
            {
                yield return response;
            }
        }
    }
}