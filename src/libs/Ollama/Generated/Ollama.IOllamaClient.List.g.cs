#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// List models<br/>
        /// Fetch a list of models and their details
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/tags
        /// </remarks>
        global::System.Threading.Tasks.Task<global::Ollama.ListResponse> ListAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}