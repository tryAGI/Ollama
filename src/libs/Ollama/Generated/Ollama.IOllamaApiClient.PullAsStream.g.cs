#nullable enable

namespace Ollama
{
    public partial interface IOllamaApiClient
    {
        /// <summary>
        /// Pull a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> PullAsStreamAsync(

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
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> PullAsStreamAsync(
            string model,
            bool? insecure = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}