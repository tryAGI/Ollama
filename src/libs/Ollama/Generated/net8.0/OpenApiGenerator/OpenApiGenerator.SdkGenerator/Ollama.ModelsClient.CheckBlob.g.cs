
#nullable enable

namespace Ollama
{
    public partial class ModelsClient
    {
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
            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Head,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri + $"/blobs/{digest}", global::System.UriKind.RelativeOrAbsolute));

            using var response = await _httpClient.SendAsync(
                request: httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}