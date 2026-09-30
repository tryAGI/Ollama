
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneResponseUsage
    {
        /// <summary>
        /// Sum of full rendered prompt lengths across all questions, including repeated shared context even when cached.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("input_tokens")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int InputTokens { get; set; }

        /// <summary>
        /// Tokens generated internally for scoring, including prefix preparation and retries. May exceed the question count; not the length of the JSON response.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("output_tokens")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int OutputTokens { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneResponseUsage" /> class.
        /// </summary>
        /// <param name="inputTokens">
        /// Sum of full rendered prompt lengths across all questions, including repeated shared context even when cached.
        /// </param>
        /// <param name="outputTokens">
        /// Tokens generated internally for scoring, including prefix preparation and retries. May exceed the question count; not the length of the JSON response.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneResponseUsage(
            int inputTokens,
            int outputTokens)
        {
            this.InputTokens = inputTokens;
            this.OutputTokens = outputTokens;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneResponseUsage" /> class.
        /// </summary>
        public SystemOneResponseUsage()
        {
        }

    }
}