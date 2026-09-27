
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Thinking controls advertised by a model. Models without thinking metadata omit this field.
    /// </summary>
    public sealed partial class Thinking
    {
        /// <summary>
        /// Values explicitly supported by the model's `think` request field. Booleans represent on/off controls and strings represent model-defined levels. An array containing only `false` identifies a model without thinking support.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("values")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Ollama.OneOf<bool?, string>> Values { get; set; }

        /// <summary>
        /// Value used when `think` is not set. For models that use this metadata for named thinking levels, unsupported names resolve to this default.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("default")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, string>))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.OneOf<bool?, string> Default { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Thinking" /> class.
        /// </summary>
        /// <param name="values">
        /// Values explicitly supported by the model's `think` request field. Booleans represent on/off controls and strings represent model-defined levels. An array containing only `false` identifies a model without thinking support.
        /// </param>
        /// <param name="default">
        /// Value used when `think` is not set. For models that use this metadata for named thinking levels, unsupported names resolve to this default.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public Thinking(
            global::System.Collections.Generic.IList<global::Ollama.OneOf<bool?, string>> values,
            global::Ollama.OneOf<bool?, string> @default)
        {
            this.Values = values ?? throw new global::System.ArgumentNullException(nameof(values));
            this.Default = @default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Thinking" /> class.
        /// </summary>
        public Thinking()
        {
        }

    }
}