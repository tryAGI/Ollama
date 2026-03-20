#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Get version<br/>
        /// Retrieve the version of the Ollama
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/version
        /// </remarks>
        global::System.Threading.Tasks.Task<global::Ollama.VersionResponse> VersionAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}