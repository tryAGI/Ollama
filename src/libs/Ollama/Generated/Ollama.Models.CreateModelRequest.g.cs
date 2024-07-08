
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Create model request object.
    /// </summary>
    public sealed partial class CreateModelRequest
    {
        /// <summary>
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: mario
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// The contents of the Modelfile.<br/>
        /// Example: FROM llama3\nSYSTEM You are mario from Super Mario Bros.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("modelfile")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Modelfile { get; set; }

        /// <summary>
        /// Path to the Modelfile (optional)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// The quantization level of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("quantize")]
        public string? Quantize { get; set; }

        /// <summary>
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool Stream { get; set; } = true;

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}