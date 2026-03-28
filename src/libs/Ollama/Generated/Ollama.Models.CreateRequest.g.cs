
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CreateRequest
    {
        /// <summary>
        /// Name for the model to create
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Existing model to create from
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("from")]
        public string? From { get; set; }

        /// <summary>
        /// Prompt template to use for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("template")]
        public string? Template { get; set; }

        /// <summary>
        /// License string or list of licenses for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("license")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>))]
        public global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? License { get; set; }

        /// <summary>
        /// System prompt to embed in the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("system")]
        public string? System { get; set; }

        /// <summary>
        /// Key-value parameters for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameters")]
        public object? Parameters { get; set; }

        /// <summary>
        /// Message history to use for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("messages")]
        public global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? Messages { get; set; }

        /// <summary>
        /// Quantization level to apply (e.g. `q4_K_M`, `q8_0`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("quantize")]
        public string? Quantize { get; set; }

        /// <summary>
        /// Stream status updates<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Name for the model to create
        /// </param>
        /// <param name="from">
        /// Existing model to create from
        /// </param>
        /// <param name="template">
        /// Prompt template to use for the model
        /// </param>
        /// <param name="license">
        /// License string or list of licenses for the model
        /// </param>
        /// <param name="system">
        /// System prompt to embed in the model
        /// </param>
        /// <param name="parameters">
        /// Key-value parameters for the model
        /// </param>
        /// <param name="messages">
        /// Message history to use for the model
        /// </param>
        /// <param name="quantize">
        /// Quantization level to apply (e.g. `q4_K_M`, `q8_0`)
        /// </param>
        /// <param name="stream">
        /// Stream status updates<br/>
        /// Default Value: true
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CreateRequest(
            string model,
            string? from,
            string? template,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? license,
            string? system,
            object? parameters,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? messages,
            string? quantize,
            bool? stream)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.From = from;
            this.Template = template;
            this.License = license;
            this.System = system;
            this.Parameters = parameters;
            this.Messages = messages;
            this.Quantize = quantize;
            this.Stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequest" /> class.
        /// </summary>
        public CreateRequest()
        {
        }
    }
}