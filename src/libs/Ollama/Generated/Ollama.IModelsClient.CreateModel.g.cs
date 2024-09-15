#nullable enable

namespace Ollama
{
    public partial interface IModelsClient
    {
        /// <summary>
        /// Create a model from a Modelfile.<br/>
        /// It is recommended to set `modelfile` to the content of the Modelfile rather than just set `path`. This is a requirement for remote create. Remote model creation should also create any file blobs, fields such as `FROM` and `ADAPTER`, explicitly with the server using Create a Blob and the value to the path indicated in the response.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.CreateModelResponse> CreateModelAsync(
            global::Ollama.CreateModelRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a model from a Modelfile.<br/>
        /// It is recommended to set `modelfile` to the content of the Modelfile rather than just set `path`. This is a requirement for remote create. Remote model creation should also create any file blobs, fields such as `FROM` and `ADAPTER`, explicitly with the server using Create a Blob and the value to the path indicated in the response.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: mario
        /// </param>
        /// <param name="modelfile">
        /// The contents of the Modelfile.<br/>
        /// Example: FROM llama3\nSYSTEM You are mario from Super Mario Bros.
        /// </param>
        /// <param name="path">
        /// Path to the Modelfile (optional)
        /// </param>
        /// <param name="quantize">
        /// The quantization level of the model.
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.CreateModelResponse> CreateModelAsync(
            string model,
            string modelfile,
            string? path = default,
            string? quantize = default,
            bool stream = true,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}