#nullable enable

namespace Ollama
{
    public partial interface IModelsClient
    {
        /// <summary>
        /// Create a blob from a file. Returns the server file path.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task CreateBlobAsync(
            string digest,
            byte[] request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a blob from a file. Returns the server file path.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task CreateBlobAsync(
            string digest,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}