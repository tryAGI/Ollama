#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Pull a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.StatusResponse> PullAsync(

            global::Ollama.PullRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Pull a model
        /// </summary>
        /// <param name="model">
        /// Name of the model to download
        /// </param>
        /// <param name="insecure">
        /// Allow downloading over insecure connections
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.StatusResponse> PullAsync(
            string model,
            bool? insecure = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}