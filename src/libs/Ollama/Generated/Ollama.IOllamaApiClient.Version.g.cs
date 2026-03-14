#nullable enable

namespace Ollama
{
    public partial interface IOllamaApiClient
    {
        /// <summary>
        /// Get version<br/>
        /// Retrieve the version of the Ollama
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.VersionResponse> VersionAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}