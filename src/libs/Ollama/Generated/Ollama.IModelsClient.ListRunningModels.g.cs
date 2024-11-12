#nullable enable

namespace Ollama
{
    public partial interface IModelsClient
    {
        /// <summary>
        /// List models that are running.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.ProcessResponse> ListRunningModelsAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}