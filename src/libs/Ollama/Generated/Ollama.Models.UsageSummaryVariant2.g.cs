
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class UsageSummaryVariant2
    {
        /// <summary>
        /// Present when group_by is requested. Currently returns up to 10 groups selected across the entire range, ranked by usage_usd or by request_count when the range includes legacy requests. Groups use the same order in every bucket; groups without requests in a bucket are omitted.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("groups")]
        public global::System.Collections.Generic.IList<global::Ollama.UsageGroup>? Groups { get; set; }

        /// <summary>
        /// Combined usage from groups outside the current limit. Omitted when there are no requests from additional groups.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("remainder")]
        public global::Ollama.UsageMetrics? Remainder { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageSummaryVariant2" /> class.
        /// </summary>
        /// <param name="groups">
        /// Present when group_by is requested. Currently returns up to 10 groups selected across the entire range, ranked by usage_usd or by request_count when the range includes legacy requests. Groups use the same order in every bucket; groups without requests in a bucket are omitted.
        /// </param>
        /// <param name="remainder">
        /// Combined usage from groups outside the current limit. Omitted when there are no requests from additional groups.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public UsageSummaryVariant2(
            global::System.Collections.Generic.IList<global::Ollama.UsageGroup>? groups,
            global::Ollama.UsageMetrics? remainder)
        {
            this.Groups = groups;
            this.Remainder = remainder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageSummaryVariant2" /> class.
        /// </summary>
        public UsageSummaryVariant2()
        {
        }

    }
}