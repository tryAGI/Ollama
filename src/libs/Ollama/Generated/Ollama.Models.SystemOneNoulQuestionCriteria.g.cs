
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Optional descriptions for the two outcomes. Omitted entries use model-specific defaults.
    /// </summary>
    public sealed partial class SystemOneNoulQuestionCriteria
    {
        /// <summary>
        /// Default Value: No
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("false")]
        public string? False { get; set; }

        /// <summary>
        /// Default Value: Yes
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("true")]
        public string? True { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulQuestionCriteria" /> class.
        /// </summary>
        /// <param name="false">
        /// Default Value: No
        /// </param>
        /// <param name="true">
        /// Default Value: Yes
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneNoulQuestionCriteria(
            string? @false,
            string? @true)
        {
            this.False = @false;
            this.True = @true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneNoulQuestionCriteria" /> class.
        /// </summary>
        public SystemOneNoulQuestionCriteria()
        {
        }

    }
}