
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class UsageMetrics
    {
        /// <summary>
        /// Number of recorded requests.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("request_count")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int RequestCount { get; set; }

        /// <summary>
        /// Total value of the requests in USD, including usage covered by your plan and usage paid from purchased credits.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("usage_usd")]
        public double? UsageUsd { get; set; }

        /// <summary>
        /// Recorded input tokens, including cached input tokens.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("input_tokens")]
        public int? InputTokens { get; set; }

        /// <summary>
        /// Recorded input tokens read from cache, already included in input_tokens.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("cached_input_tokens")]
        public int? CachedInputTokens { get; set; }

        /// <summary>
        /// Recorded output tokens.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("output_tokens")]
        public int? OutputTokens { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageMetrics" /> class.
        /// </summary>
        /// <param name="requestCount">
        /// Number of recorded requests.
        /// </param>
        /// <param name="usageUsd">
        /// Total value of the requests in USD, including usage covered by your plan and usage paid from purchased credits.
        /// </param>
        /// <param name="inputTokens">
        /// Recorded input tokens, including cached input tokens.
        /// </param>
        /// <param name="cachedInputTokens">
        /// Recorded input tokens read from cache, already included in input_tokens.
        /// </param>
        /// <param name="outputTokens">
        /// Recorded output tokens.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public UsageMetrics(
            int requestCount,
            double? usageUsd,
            int? inputTokens,
            int? cachedInputTokens,
            int? outputTokens)
        {
            this.RequestCount = requestCount;
            this.UsageUsd = usageUsd;
            this.InputTokens = inputTokens;
            this.CachedInputTokens = cachedInputTokens;
            this.OutputTokens = outputTokens;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageMetrics" /> class.
        /// </summary>
        public UsageMetrics()
        {
        }

    }
}