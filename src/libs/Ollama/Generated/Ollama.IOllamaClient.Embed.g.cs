#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Generate embeddings<br/>
        /// Creates vector embeddings representing the input text
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.EmbedResponse> EmbedAsync(

            global::Ollama.EmbedRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Generate embeddings<br/>
        /// Creates vector embeddings representing the input text
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="input">
        /// Text or array of texts to generate embeddings for
        /// </param>
        /// <param name="truncate">
        /// If true, truncate inputs that exceed the context window. If false, returns an error.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="dimensions">
        /// Number of dimensions to generate embeddings for
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.EmbedResponse> EmbedAsync(
            string model,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>> input,
            bool? truncate = default,
            int? dimensions = default,
            string? keepAlive = default,
            global::Ollama.ModelOptions? options = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}