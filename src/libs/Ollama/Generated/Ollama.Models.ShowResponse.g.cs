
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
        /// The effective chat renderer of the model (aliases resolved), when one is set
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("renderer")]
        public string? Renderer { get; set; }

        /// <summary>
        /// The output parser configured on the model, when one is set
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parser")]
        public string? Parser { get; set; }

        /// <summary>
        /// Where the chat prompt actually comes from; one of `renderer_parser`, `renderer`, `parser` (a Go renderer runs and any packaged template is inert), `harmony`, `go_template`, `gguf_chat_template` (the runner renders the GGUF's embedded jinja), or `none`
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("template_source")]
        public string? TemplateSource { get; set; }

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
        /// <param name="renderer">
        /// The effective chat renderer of the model (aliases resolved), when one is set
        /// </param>
        /// <param name="parser">
        /// The output parser configured on the model, when one is set
        /// </param>
        /// <param name="templateSource">
        /// Where the chat prompt actually comes from; one of `renderer_parser`, `renderer`, `parser` (a Go renderer runs and any packaged template is inert), `harmony`, `go_template`, `gguf_chat_template` (the runner renders the GGUF's embedded jinja), or `none`
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
            string? renderer,
            string? parser,
            string? templateSource,
            global::System.Collections.Generic.IList<string>? capabilities,
            object? modelInfo)
        {
            this.Thinking = thinking;
            this.Parameters = parameters;
            this.License = license;
            this.ModifiedAt = modifiedAt;
            this.Details = details;
            this.Template = template;
            this.Renderer = renderer;
            this.Parser = parser;
            this.TemplateSource = templateSource;
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