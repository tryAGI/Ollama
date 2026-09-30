#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Answer typed questions<br/>
        /// Answer choice, yes/no, and scoring questions with a local System One model. Requires Ollama v0.35.0 or later. See the [decision guide](/capabilities/decision) for examples.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/v1/systemone \<br/>
        ///   -H 'Content-Type: application/json' \<br/>
        ///   -d '{<br/>
        ///     "model": "nimble",<br/>
        ///     "state": "Our checkout has returned 500 errors since 9am.",<br/>
        ///     "questions": {<br/>
        ///       "label": {<br/>
        ///         "type": "choice",<br/>
        ///         "instructions": "Which label fits this ticket?",<br/>
        ///         "criteria": {<br/>
        ///           "billing": "Payments and refunds",<br/>
        ///           "bug": "Software errors",<br/>
        ///           "account": "Login and account access"<br/>
        ///         }<br/>
        ///       }<br/>
        ///     }<br/>
        ///   }'
        /// </remarks>
        global::System.Threading.Tasks.Task<global::Ollama.SystemOneResponse> SystemoneAsync(

            global::Ollama.SystemOneRequest request,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Answer typed questions<br/>
        /// Answer choice, yes/no, and scoring questions with a local System One model. Requires Ollama v0.35.0 or later. See the [decision guide](/capabilities/decision) for examples.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        /// <remarks>
        /// curl http://localhost:11434/v1/systemone \<br/>
        ///   -H 'Content-Type: application/json' \<br/>
        ///   -d '{<br/>
        ///     "model": "nimble",<br/>
        ///     "state": "Our checkout has returned 500 errors since 9am.",<br/>
        ///     "questions": {<br/>
        ///       "label": {<br/>
        ///         "type": "choice",<br/>
        ///         "instructions": "Which label fits this ticket?",<br/>
        ///         "criteria": {<br/>
        ///           "billing": "Payments and refunds",<br/>
        ///           "bug": "Software errors",<br/>
        ///           "account": "Login and account access"<br/>
        ///         }<br/>
        ///       }<br/>
        ///     }<br/>
        ///   }'
        /// </remarks>
        global::System.Threading.Tasks.Task<global::Ollama.AutoSDKHttpResponse<global::Ollama.SystemOneResponse>> SystemoneAsResponseAsync(

            global::Ollama.SystemOneRequest request,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Answer typed questions<br/>
        /// Answer choice, yes/no, and scoring questions with a local System One model. Requires Ollama v0.35.0 or later. See the [decision guide](/capabilities/decision) for examples.
        /// </summary>
        /// <param name="model">
        /// Local model trained for System One, such as nimble. Requires compatible GGUF weights and a scoring-capable runner; cloud and MLX/Safetensors models are not supported.
        /// </param>
        /// <param name="state">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="questions">
        /// Named questions about the shared state. Each is scored separately against the full state and question schema; answers are not passed to later questions.
        /// </param>
        /// <param name="keepAlive">
        /// How long to keep the model loaded after the request, as a duration string (such as 5m) or seconds. Zero unloads after the request; a negative value keeps it loaded. Defaults to the server's keep-alive setting (5m unless configured otherwise).
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.SystemOneResponse> SystemoneAsync(
            string model,
            global::Ollama.SystemOneContent state,
            object questions,
            global::Ollama.OneOf<string, double?>? keepAlive = default,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}