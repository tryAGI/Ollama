
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class ShowResponse
    {
        /// <summary>
        /// Thinking controls advertised by a model. Models without thinking metadata omit this field.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public global::Ollama.Thinking? Thinking { get; set; }

        /// <summary>
        /// Model parameter settings serialized as text
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameters")]
        public string? Parameters { get; set; }

        /// <summary>
        /// The license of the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("license")]
        public string? License { get; set; }

        /// <summary>
        /// Last modified timestamp in ISO 8601 format
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("modified_at")]
        public string? ModifiedAt { get; set; }

        /// <summary>
        /// High-level model details
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("details")]
        public object? Details { get; set; }

        /// <summary>
        /// The template used by the model to render prompts
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("template")]
        public string? Template { get; set; }

        /// <summary>
        /// List of supported features
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("capabilities")]
        public global::System.Collections.Generic.IList<string>? Capabilities { get; set; }

        /// <summary>
        /// Additional model metadata
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model_info")]
        public object? ModelInfo { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowResponse" /> class.
        /// </summary>
        /// <param name="thinking">
        /// Thinking controls advertised by a model. Models without thinking metadata omit this field.
        /// </param>
        /// <param name="parameters">
        /// Model parameter settings serialized as text
        /// </param>
        /// <param name="license">
        /// The license of the model
        /// </param>
        /// <param name="modifiedAt">
        /// Last modified timestamp in ISO 8601 format
        /// </param>
        /// <param name="details">
        /// High-level model details
        /// </param>
        /// <param name="template">
        /// The template used by the model to render prompts
        /// </param>
        /// <param name="capabilities">
        /// List of supported features
        /// </param>
        /// <param name="modelInfo">
        /// Additional model metadata
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ShowResponse(
            global::Ollama.Thinking? thinking,
            string? parameters,
            string? license,
            string? modifiedAt,
            object? details,
            string? template,
            global::System.Collections.Generic.IList<string>? capabilities,
            object? modelInfo)
        {
            this.Thinking = thinking;
            this.Parameters = parameters;
            this.License = license;
            this.ModifiedAt = modifiedAt;
            this.Details = details;
            this.Template = template;
            this.Capabilities = capabilities;
            this.ModelInfo = modelInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowResponse" /> class.
        /// </summary>
        public ShowResponse()
        {
        }

    }
}