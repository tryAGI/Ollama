
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneNoulAnswer
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneNoulAnswerTypeJsonConverter))]
        public global::Ollama.SystemOneNoulAnswerType Type { get; set; }

        /// <summary>
        /// Probability of true among the false and true candidates. This is a number, not a Boolean.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("noul")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double Noul { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulAnswer" /> class.
        /// </summary>
        /// <param name="noul">
        /// Probability of true among the false and true candidates. This is a number, not a Boolean.
        /// </param>
        /// <param name="type"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneNoulAnswer(
            double noul,
            global::Ollama.SystemOneNoulAnswerType type)
        {
            this.Type = type;
            this.Noul = noul;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulAnswer" /> class.
        /// </summary>
        public SystemOneNoulAnswer()
        {
        }

    }
}