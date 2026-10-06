
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneScoreQuestion
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneScoreQuestionTypeJsonConverter))]
        public global::Ollama.SystemOneScoreQuestionType Type { get; set; }

        /// <summary>
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("instructions")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneContentJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.SystemOneContent Instructions { get; set; }

        /// <summary>
        /// Descriptions ordered from the lowest score (index 0) to the highest. Defines a scale from 0 to the number of criteria minus 1. The maximum number of levels depends on the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("criteria")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<string> Criteria { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneScoreQuestion" /> class.
        /// </summary>
        /// <param name="instructions">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="criteria">
        /// Descriptions ordered from the lowest score (index 0) to the highest. Defines a scale from 0 to the number of criteria minus 1. The maximum number of levels depends on the model.
        /// </param>
        /// <param name="type"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneScoreQuestion(
            global::Ollama.SystemOneContent instructions,
            global::System.Collections.Generic.IList<string> criteria,
            global::Ollama.SystemOneScoreQuestionType type)
        {
            this.Type = type;
            this.Instructions = instructions;
            this.Criteria = criteria ?? throw new global::System.ArgumentNullException(nameof(criteria));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneScoreQuestion" /> class.
        /// </summary>
        public SystemOneScoreQuestion()
        {
        }

    }
}