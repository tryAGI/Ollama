
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneChoiceAnswer
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneChoiceAnswerTypeJsonConverter))]
        public global::Ollama.SystemOneChoiceAnswerType Type { get; set; }

        /// <summary>
        /// Option key with the highest probability. Ties follow the model's option order.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("choice")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Choice { get; set; }

        /// <summary>
        /// Probabilities normalized over the supplied candidates, summing to 1 subject to floating-point precision.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("probabilities")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.Dictionary<string, double> Probabilities { get; set; }

        /// <summary>
        /// Distribution concentration, calculated as 1 - H(p) / ln(N), where H(p) is entropy and N is the candidate count. Zero means uniform probabilities; values near 1 mean one candidate dominates. Not calibrated correctness.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("confidence")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double Confidence { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneChoiceAnswer" /> class.
        /// </summary>
        /// <param name="choice">
        /// Option key with the highest probability. Ties follow the model's option order.
        /// </param>
        /// <param name="probabilities">
        /// Probabilities normalized over the supplied candidates, summing to 1 subject to floating-point precision.
        /// </param>
        /// <param name="confidence">
        /// Distribution concentration, calculated as 1 - H(p) / ln(N), where H(p) is entropy and N is the candidate count. Zero means uniform probabilities; values near 1 mean one candidate dominates. Not calibrated correctness.
        /// </param>
        /// <param name="type"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneChoiceAnswer(
            string choice,
            global::System.Collections.Generic.Dictionary<string, double> probabilities,
            double confidence,
            global::Ollama.SystemOneChoiceAnswerType type)
        {
            this.Type = type;
            this.Choice = choice ?? throw new global::System.ArgumentNullException(nameof(choice));
            this.Probabilities = probabilities ?? throw new global::System.ArgumentNullException(nameof(probabilities));
            this.Confidence = confidence;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneChoiceAnswer" /> class.
        /// </summary>
        public SystemOneChoiceAnswer()
        {
        }

    }
}