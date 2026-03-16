#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Copy a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task CopyAsync(

            global::Ollama.CopyRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Copy a model
        /// </summary>
        /// <param name="source">
        /// Existing model name to copy from
        /// </param>
        /// <param name="destination">
        /// New model name to create
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task CopyAsync(
            string source,
            string destination,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}