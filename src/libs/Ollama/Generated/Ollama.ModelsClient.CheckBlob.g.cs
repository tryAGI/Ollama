
#nullable enable

namespace Ollama
{
    public partial class ModelsClient
    {
        partial void PrepareCheckBlobArguments(
            global::System.Net.Http.HttpClient httpClient,
            ref string digest);
        partial void PrepareCheckBlobRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            string digest);
        partial void ProcessCheckBlobResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Ensures that the file blob used for a FROM or ADAPTER field exists on the server.<br/>
        /// This is checking your Ollama server and not Ollama.ai.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task CheckBlobAsync(
            string digest,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            PrepareArguments(
                client: _httpClient);
            PrepareCheckBlobArguments(
                httpClient: _httpClient,
                digest: ref digest);

            var __pathBuilder = new PathBuilder(
                path: $"/blobs/{digest}",
                baseUri: _httpClient.BaseAddress); 
            var __path = __pathBuilder.ToString();
            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Head,
                requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));

            PrepareRequest(
                client: _httpClient,
                request: httpRequest);
            PrepareCheckBlobRequest(
                httpClient: _httpClient,
                httpRequestMessage: httpRequest,
                digest: digest);

            using var response = await _httpClient.SendAsync(
                request: httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: _httpClient,
                response: response);
            ProcessCheckBlobResponse(
                httpClient: _httpClient,
                httpResponseMessage: response);
            response.EnsureSuccessStatusCode();
        }
    }
}