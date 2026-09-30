
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneNoulQuestion
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneNoulQuestionTypeJsonConverter))]
        public global::Ollama.SystemOneNoulQuestionType Type { get; set; }

        /// <summary>
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("instructions")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneContentJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.SystemOneContent Instructions { get; set; }

        /// <summary>
        /// Optional descriptions for the two outcomes. Omitted entries use No and Yes.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("criteria")]
        public global::Ollama.SystemOneNoulQuestionCriteria? Criteria { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulQuestion" /> class.
        /// </summary>
        /// <param name="instructions">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="type"></param>
        /// <param name="criteria">
        /// Optional descriptions for the two outcomes. Omitted entries use No and Yes.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneNoulQuestion(
            global::Ollama.SystemOneContent instructions,
            global::Ollama.SystemOneNoulQuestionType type,
            global::Ollama.SystemOneNoulQuestionCriteria? criteria)
        {
            this.Type = type;
            this.Instructions = instructions;
            this.Criteria = criteria;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulQuestion" /> class.
        /// </summary>
        public SystemOneNoulQuestion()
        {
        }

    }
}