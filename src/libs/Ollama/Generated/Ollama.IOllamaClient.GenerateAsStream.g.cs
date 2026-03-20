#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Generate a response<br/>
        /// Generates a response for the provided prompt
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/generate -d '{<br/>
        ///   "model": "gemma3",<br/>
        ///   "prompt": "Why is the sky blue?"<br/>
        /// }'
        /// </remarks>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateStreamEvent> GenerateAsStreamAsync(

            global::Ollama.GenerateRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Generate a response<br/>
        /// Generates a response for the provided prompt
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="prompt">
        /// Text for the model to generate a response from
        /// </param>
        /// <param name="suffix">
        /// Used for fill-in-the-middle models, text that appears after the user prompt and before the model response
        /// </param>
        /// <param name="images"></param>
        /// <param name="format">
        /// Structured output format for the model to generate a response from. Supports either the string `"json"` or a JSON schema object.
        /// </param>
        /// <param name="system">
        /// System prompt for the model to generate a response from
        /// </param>
        /// <param name="think">
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </param>
        /// <param name="raw">
        /// When true, returns the raw response from the model without any prompt templating
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="logprobs">
        /// Whether to return log probabilities of the output tokens
        /// </param>
        /// <param name="topLogprobs">
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateStreamEvent> GenerateAsStreamAsync(
            string model,
            string? prompt = default,
            string? suffix = default,
            global::System.Collections.Generic.IList<string>? images = default,
            global::Ollama.OneOf<string, object>? format = default,
            string? system = default,
            global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>? think = default,
            bool? raw = default,
            global::Ollama.OneOf<string, double?>? keepAlive = default,
            global::Ollama.ModelOptions? options = default,
            bool? logprobs = default,
            int? topLogprobs = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}