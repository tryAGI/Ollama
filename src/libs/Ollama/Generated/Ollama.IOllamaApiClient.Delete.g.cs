#nullable enable

namespace Ollama
{
    public partial interface IOllamaApiClient
    {
        /// <summary>
        /// Delete a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteAsync(

            global::Ollama.DeleteRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a model
        /// </summary>
        /// <param name="model">
        /// Model name to delete
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task DeleteAsync(
            string model,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}