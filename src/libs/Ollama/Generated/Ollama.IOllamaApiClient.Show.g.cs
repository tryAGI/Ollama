#nullable enable

namespace Ollama
{
    public partial interface IOllamaApiClient
    {
        /// <summary>
        /// Show model details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.ShowResponse> ShowAsync(

            global::Ollama.ShowRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Show model details
        /// </summary>
        /// <param name="model">
        /// Model name to show
        /// </param>
        /// <param name="verbose">
        /// If true, includes large verbose fields in the response.
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.ShowResponse> ShowAsync(
            string model,
            bool? verbose = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}