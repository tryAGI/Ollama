#nullable enable

namespace Ollama
{
    public partial interface IModelsClient
    {
        /// <summary>
        /// Download a model from the ollama library.<br/>
        /// Cancelled pulls are resumed from where they left off, and multiple calls will share the same download progress.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.PullModelResponse> PullModelAsync(
            global::Ollama.PullModelRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Download a model from the ollama library.<br/>
        /// Cancelled pulls are resumed from where they left off, and multiple calls will share the same download progress.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </param>
        /// <param name="insecure">
        /// Allow insecure connections to the library. <br/>
        /// Only use this if you are pulling from your own library during development.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="username">
        /// Ollama username.
        /// </param>
        /// <param name="password">
        /// Ollama password.
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.PullModelResponse> PullModelAsync(
            string model,
            bool? insecure = false,
            string? username = default,
            string? password = default,
            bool? stream = true,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}