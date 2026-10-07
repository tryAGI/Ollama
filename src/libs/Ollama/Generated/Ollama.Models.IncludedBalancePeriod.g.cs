
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class IncludedBalancePeriod
    {
        /// <summary>
        /// Start of the included period in UTC, inclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("from")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime From { get; set; }

        /// <summary>
        /// End of the included period in UTC, exclusive.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("until")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime Until { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludedBalancePeriod" /> class.
        /// </summary>
        /// <param name="from">
        /// Start of the included period in UTC, inclusive.
        /// </param>
        /// <param name="until">
        /// End of the included period in UTC, exclusive.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public IncludedBalancePeriod(
            global::System.DateTime from,
            global::System.DateTime until)
        {
            this.From = from;
            this.Until = until;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludedBalancePeriod" /> class.
        /// </summary>
        public IncludedBalancePeriod()
        {
        }

    }
}