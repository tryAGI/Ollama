
#nullable enable

namespace Ollama
{
    public partial class CompletionsClient
    {
        /// <summary>
        /// Generate a response for a given prompt with a provided model.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<GenerateCompletionResponse> GenerateCompletionAsync(
            GenerateCompletionRequest request,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri + "/generate", global::System.UriKind.RelativeOrAbsolute));
            httpRequest.Content = new global::System.Net.Http.StringContent(
                content: global::System.Text.Json.JsonSerializer.Serialize(request, global::Ollama.SourceGenerationContext.Default.GenerateCompletionRequest),
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");

            using var response = await _httpClient.SendAsync(
                request: httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
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
        /// Generate a response for a given prompt with a provided model.
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
        public async global::System.Collections.Generic.IAsyncEnumerable<GenerateCompletionResponse> GenerateCompletionAsync(
            string model,
            string prompt,
            global::System.Collections.Generic.IList<string?>? images = default,
            string? system = default,
            string? template = default,
            global::System.Collections.Generic.IList<long>? context = default,
            RequestOptions? options = default,
            GenerateCompletionRequestFormat? format = default,
            bool raw = default,
            bool stream = true,
            int? keepAlive = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = new GenerateCompletionRequest
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