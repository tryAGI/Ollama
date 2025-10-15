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
        /// <exception cref="global::Ollama.ApiException"></exception>
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
        /// <param name="from">
        /// Name of the model or file to use as the source
        /// </param>
        /// <param name="files">
        /// Map of files to include when creating the model
        /// </param>
        /// <param name="adapters">
        /// Map of LoRA adapters to include when creating the model
        /// </param>
        /// <param name="template">
        /// Template used when constructing a request to the model
        /// </param>
        /// <param name="system">
        /// System prompt for the model
        /// </param>
        /// <param name="parameters">
        /// Map of hyper-parameters which are applied to the model
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Collections.Generic.IAsyncEnumerable<global::Ollama.CreateModelResponse> CreateModelAsync(
            string model,
            string? modelfile = default,
            string? path = default,
            string? quantize = default,
            bool? stream = default,
            string? from = default,
            global::System.Collections.Generic.Dictionary<string, string>? files = default,
            global::System.Collections.Generic.Dictionary<string, string>? adapters = default,
            string? template = default,
            string? system = default,
            object? parameters = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}