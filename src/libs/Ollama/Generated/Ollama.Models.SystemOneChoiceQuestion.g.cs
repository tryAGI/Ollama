
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneChoiceQuestion
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneChoiceQuestionTypeJsonConverter))]
        public global::Ollama.SystemOneChoiceQuestionType Type { get; set; }

        /// <summary>
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("instructions")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneContentJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.SystemOneContent Instructions { get; set; }

        /// <summary>
        /// Option keys mapped to descriptions. A null description uses the key itself. Keys must not be blank; ties select the first option in request order.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("criteria")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.Dictionary<string, string?> Criteria { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneChoiceQuestion" /> class.
        /// </summary>
        /// <param name="instructions">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="criteria">
        /// Option keys mapped to descriptions. A null description uses the key itself. Keys must not be blank; ties select the first option in request order.
        /// </param>
        /// <param name="type"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneChoiceQuestion(
            global::Ollama.SystemOneContent instructions,
            global::System.Collections.Generic.Dictionary<string, string?> criteria,
            global::Ollama.SystemOneChoiceQuestionType type)
        {
            this.Type = type;
            this.Instructions = instructions;
            this.Criteria = criteria ?? throw new global::System.ArgumentNullException(nameof(criteria));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneChoiceQuestion" /> class.
        /// </summary>
        public SystemOneChoiceQuestion()
        {
        }

    }
}