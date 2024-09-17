#nullable enable

namespace Ollama
{
    public partial interface IModelsClient
    {
        /// <summary>
        /// Upload a model to a model library.<br/>
        /// Requires registering for ollama.ai and adding a public key first.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.PushModelResponse> PushModelAsync(
            global::Ollama.PushModelRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Upload a model to a model library.<br/>
        /// Requires registering for ollama.ai and adding a public key first.
        /// </summary>
        /// <param name="model">
        /// The name of the model to push in the form of &lt;namespace&gt;/&lt;model&gt;:&lt;tag&gt;.<br/>
        /// Example: mattw/pygmalion:latest
        /// </param>
        /// <param name="insecure">
        /// Allow insecure connections to the library. <br/>
        /// Only use this if you are pushing to your library during development.<br/>
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
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.PushModelResponse> PushModelAsync(
            string model,
            bool? insecure = false,
            string? username = default,
            string? password = default,
            bool? stream = true,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}