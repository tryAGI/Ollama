#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {

        /// <summary>
        /// List running models<br/>
        /// Retrieve a list of models that are currently running
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>

        /// <remarks>
        /// curl http://localhost:11434/api/ps
        /// </remarks>
        global::System.Threading.Tasks.Task<global::Ollama.PsResponse> PsAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}