#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {

        /// <summary>
        /// Push a model
        /// </summary>

        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>

        /// <remarks>
        /// curl http://localhost:11434/api/push -d '{<br/>
        ///   "model": "my-username/my-model"<br/>
        /// }'
        /// </remarks>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> PushAsStreamAsync(

            global::Ollama.PushRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Push a model
        /// </summary>
        /// <param name="model">
        /// Name of the model to publish
        /// </param>
        /// <param name="insecure">
        /// Allow publishing over insecure connections
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> PushAsStreamAsync(
            string model,
            bool? insecure = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}