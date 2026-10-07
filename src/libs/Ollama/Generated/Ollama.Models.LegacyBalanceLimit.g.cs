
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class LegacyBalanceLimit
    {
        /// <summary>
        /// Percentage of the limit remaining.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("remaining_percent")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double RemainingPercent { get; set; }

        /// <summary>
        /// Next reset time in UTC.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("resets_at")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime ResetsAt { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyBalanceLimit" /> class.
        /// </summary>
        /// <param name="remainingPercent">
        /// Percentage of the limit remaining.
        /// </param>
        /// <param name="resetsAt">
        /// Next reset time in UTC.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public LegacyBalanceLimit(
            double remainingPercent,
            global::System.DateTime resetsAt)
        {
            this.RemainingPercent = remainingPercent;
            this.ResetsAt = resetsAt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyBalanceLimit" /> class.
        /// </summary>
        public LegacyBalanceLimit()
        {
        }

    }
}