
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneScoreAnswer
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneScoreAnswerTypeJsonConverter))]
        public global::Ollama.SystemOneScoreAnswerType Type { get; set; }

        /// <summary>
        /// Probability-weighted average of the zero-based criterion indices, from 0 to the number of criteria minus 1. Not rounded to a level or normalized to 0–1.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("score")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double Score { get; set; }

        /// <summary>
        /// Zero-based indices as string keys mapped to the criterion descriptions.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("legend")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.Dictionary<string, string> Legend { get; set; }

        /// <summary>
        /// Probabilities keyed by zero-based criterion indices as strings.
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
        /// Initializes a new instance of the <see cref="SystemOneScoreAnswer" /> class.
        /// </summary>
        /// <param name="score">
        /// Probability-weighted average of the zero-based criterion indices, from 0 to the number of criteria minus 1. Not rounded to a level or normalized to 0–1.
        /// </param>
        /// <param name="legend">
        /// Zero-based indices as string keys mapped to the criterion descriptions.
        /// </param>
        /// <param name="probabilities">
        /// Probabilities keyed by zero-based criterion indices as strings.
        /// </param>
        /// <param name="confidence">
        /// Distribution concentration, calculated as 1 - H(p) / ln(N), where H(p) is entropy and N is the candidate count. Zero means uniform probabilities; values near 1 mean one candidate dominates. Not calibrated correctness.
        /// </param>
        /// <param name="type"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneScoreAnswer(
            double score,
            global::System.Collections.Generic.Dictionary<string, string> legend,
            global::System.Collections.Generic.Dictionary<string, double> probabilities,
            double confidence,
            global::Ollama.SystemOneScoreAnswerType type)
        {
            this.Type = type;
            this.Score = score;
            this.Legend = legend ?? throw new global::System.ArgumentNullException(nameof(legend));
            this.Probabilities = probabilities ?? throw new global::System.ArgumentNullException(nameof(probabilities));
            this.Confidence = confidence;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneScoreAnswer" /> class.
        /// </summary>
        public SystemOneScoreAnswer()
        {
        }

    }
}