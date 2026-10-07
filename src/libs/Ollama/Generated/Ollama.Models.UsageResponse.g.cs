
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class UsageResponse
    {
        /// <summary>
        /// Selected time range.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("range")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.UsageResponseRangeJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.UsageResponseRange Range { get; set; }

        /// <summary>
        /// Selected usage scope.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("scope")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.UsageResponseScopeJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.UsageResponseScope Scope { get; set; }

        /// <summary>
        /// Set automatically: hour for 24h, day for 7d and 30d.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("granularity")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.UsageResponseGranularityJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.UsageResponseGranularity Granularity { get; set; }

        /// <summary>
        /// Start of the range in UTC, inclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("from")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime From { get; set; }

        /// <summary>
        /// End of the range in UTC, exclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("until")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime Until { get; set; }

        /// <summary>
        /// Usage across the entire range.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("totals")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.UsageMetrics Totals { get; set; }

        /// <summary>
        /// Usage in chronological order, including buckets with no recorded requests.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("buckets")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Ollama.UsageBucket> Buckets { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageResponse" /> class.
        /// </summary>
        /// <param name="range">
        /// Selected time range.
        /// </param>
        /// <param name="scope">
        /// Selected usage scope.
        /// </param>
        /// <param name="granularity">
        /// Set automatically: hour for 24h, day for 7d and 30d.
        /// </param>
        /// <param name="from">
        /// Start of the range in UTC, inclusive.
        /// </param>
        /// <param name="until">
        /// End of the range in UTC, exclusive.
        /// </param>
        /// <param name="totals">
        /// Usage across the entire range.
        /// </param>
        /// <param name="buckets">
        /// Usage in chronological order, including buckets with no recorded requests.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public UsageResponse(
            global::Ollama.UsageResponseRange range,
            global::Ollama.UsageResponseScope scope,
            global::Ollama.UsageResponseGranularity granularity,
            global::System.DateTime from,
            global::System.DateTime until,
            global::Ollama.UsageMetrics totals,
            global::System.Collections.Generic.IList<global::Ollama.UsageBucket> buckets)
        {
            this.Range = range;
            this.Scope = scope;
            this.Granularity = granularity;
            this.From = from;
            this.Until = until;
            this.Totals = totals ?? throw new global::System.ArgumentNullException(nameof(totals));
            this.Buckets = buckets ?? throw new global::System.ArgumentNullException(nameof(buckets));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageResponse" /> class.
        /// </summary>
        public UsageResponse()
        {
        }

    }
}