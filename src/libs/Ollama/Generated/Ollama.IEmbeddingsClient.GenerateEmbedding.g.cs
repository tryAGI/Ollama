#nullable enable

namespace Ollama
{
    public partial interface IEmbeddingsClient
    {
        /// <summary>
        /// Generate embeddings from a model.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.GenerateEmbeddingResponse> GenerateEmbeddingAsync(
            global::Ollama.GenerateEmbeddingRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Generate embeddings from a model.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.1
        /// </param>
        /// <param name="prompt">
        /// Text to generate embeddings for.<br/>
        /// Example: Here is an article about llamas...
        /// </param>
        /// <param name="options">
        /// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
        /// </param>
        /// <param name="keepAlive">
        /// How long (in minutes) to keep the model loaded in memory.<br/>
        /// - If set to a positive duration (e.g. 20), the model will stay loaded for the provided duration.<br/>
        /// - If set to a negative duration (e.g. -1), the model will stay loaded indefinitely.<br/>
        /// - If set to 0, the model will be unloaded immediately once finished.<br/>
        /// - If not set, the model will stay loaded for 5 minutes by default
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.GenerateEmbeddingResponse> GenerateEmbeddingAsync(
            string model,
            string prompt,
            global::Ollama.RequestOptions? options = default,
            int? keepAlive = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}