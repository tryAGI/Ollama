#nullable enable

namespace Ollama
{
    public partial interface IOllamaApiClient
    {
        /// <summary>
        /// Returns the version of the Ollama server.<br/>
        /// This endpoint returns the version of the Ollama server.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.VersionResponse> GetVersionAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}