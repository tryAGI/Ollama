#nullable enable

namespace Ollama
{
    public partial interface IChatClient
    {
        /// <summary>
        /// Generate the next message in a chat with a provided model.<br/>
        /// This is a streaming endpoint, so there will be a series of responses. The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateChatCompletionResponse> GenerateChatCompletionAsync(
            global::Ollama.GenerateChatCompletionRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Generate the next message in a chat with a provided model.<br/>
        /// This is a streaming endpoint, so there will be a series of responses. The final response object will include statistics and additional data from the request.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </param>
        /// <param name="messages">
        /// The messages of the chat, this can be used to keep a chat memory
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="format"></param>
        /// <param name="keepAlive">
        /// How long (in minutes) to keep the model loaded in memory.<br/>
        /// - If set to a positive duration (e.g. 20), the model will stay loaded for the provided duration.<br/>
        /// - If set to a negative duration (e.g. -1), the model will stay loaded indefinitely.<br/>
        /// - If set to 0, the model will be unloaded immediately once finished.<br/>
        /// - If not set, the model will stay loaded for 5 minutes by default
        /// </param>
        /// <param name="tools">
        /// A list of tools the model may call.
        /// </param>
        /// <param name="options">
        /// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
        /// </param>
        /// <param name="think">
        /// Think controls whether thinking/reasoning models will think before<br/>
        /// responding. Needs to be a pointer so we can distinguish between false<br/>
        /// (request that thinking _not_ be used) and unset (use the old behavior<br/>
        /// before this option was introduced).
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.GenerateChatCompletionResponse> GenerateChatCompletionAsync(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.Message> messages,
            bool? stream = default,
            global::Ollama.ResponseFormat? format = default,
            int? keepAlive = default,
            global::System.Collections.Generic.IList<global::Ollama.Tool>? tools = default,
            global::Ollama.RequestOptions? options = default,
            bool? think = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}