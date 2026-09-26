#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Generate a chat message<br/>
        /// Generate the next chat message in a conversation between a user and an assistant.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/api/chat -d '{<br/>
        ///   "model": "gemma4",<br/>
        ///   "messages": [<br/>
        ///     {<br/>
        ///       "role": "user",<br/>
        ///       "content": "why is the sky blue?"<br/>
        ///     }<br/>
        ///   ]<br/>
        /// }'
        /// </remarks>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.ChatStreamEvent> ChatAsStreamAsync(

            global::Ollama.ChatRequest request,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Generate a chat message<br/>
        /// Generate the next chat message in a conversation between a user and an assistant.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="messages">
        /// Chat history as an array of message objects (each with a role and content)
        /// </param>
        /// <param name="tools">
        /// Optional list of function tools the model may call during the chat
        /// </param>
        /// <param name="format">
        /// Format to return a response in. Can be `json` or a JSON schema
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="think">
        /// Controls a model's thinking output. Use `/api/show` to discover the supported values and default for the selected model. `true` requests thinking, `false` requests no thinking output, and `null` uses the model default. String values are model-defined; supported names must match `/api/show` exactly. Numbers are not supported.
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="logprobs">
        /// Whether to return log probabilities of the output tokens
        /// </param>
        /// <param name="topLogprobs">
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.ChatStreamEvent> ChatAsStreamAsync(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage> messages,
            global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? tools = default,
            global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? format = default,
            global::Ollama.ModelOptions? options = default,
            global::Ollama.ThinkValue? think = default,
            global::Ollama.OneOf<string, double?>? keepAlive = default,
            bool? logprobs = default,
            int? topLogprobs = default,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}