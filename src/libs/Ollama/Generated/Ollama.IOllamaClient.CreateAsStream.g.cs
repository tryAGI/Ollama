#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Create a model
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/create -d '{<br/>
        ///   "from": "gemma3",<br/>
        ///   "model": "alpaca",<br/>
        ///   "system": "You are Alpaca, a helpful AI assistant. You only answer with Emojis."<br/>
        /// }'
        /// </remarks>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> CreateAsStreamAsync(

            global::Ollama.CreateRequest request,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a model
        /// </summary>
        /// <param name="model">
        /// Name for the model to create
        /// </param>
        /// <param name="from">
        /// Existing model to create from
        /// </param>
        /// <param name="template">
        /// Prompt template to use for the model
        /// </param>
        /// <param name="license">
        /// License string or list of licenses for the model
        /// </param>
        /// <param name="system">
        /// System prompt to embed in the model
        /// </param>
        /// <param name="parameters">
        /// Key-value parameters for the model
        /// </param>
        /// <param name="messages">
        /// Message history to use for the model
        /// </param>
        /// <param name="quantize">
        /// Quantization level to apply (e.g. `q4_K_M`, `q8_0`)
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.StatusEvent> CreateAsStreamAsync(
            string model,
            string? from = default,
            string? template = default,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? license = default,
            string? system = default,
            object? parameters = default,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? messages = default,
            string? quantize = default,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}