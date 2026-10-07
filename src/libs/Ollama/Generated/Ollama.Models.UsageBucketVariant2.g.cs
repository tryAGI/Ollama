
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class UsageBucketVariant2
    {
        /// <summary>
        /// Start of the bucket in UTC, inclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("from")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime From { get; set; }

        /// <summary>
        /// End of the bucket in UTC, exclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("until")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime Until { get; set; }

        /// <summary>
        /// Present and true for the current hour or day, which is still in progress.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("partial")]
        public bool? Partial { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageBucketVariant2" /> class.
        /// </summary>
        /// <param name="from">
        /// Start of the bucket in UTC, inclusive.
        /// </param>
        /// <param name="until">
        /// End of the bucket in UTC, exclusive.
        /// </param>
        /// <param name="partial">
        /// Present and true for the current hour or day, which is still in progress.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public UsageBucketVariant2(
            global::System.DateTime from,
            global::System.DateTime until,
            bool? partial)
        {
            this.From = from;
            this.Until = until;
            this.Partial = partial;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageBucketVariant2" /> class.
        /// </summary>
        public UsageBucketVariant2()
        {
        }

    }
}