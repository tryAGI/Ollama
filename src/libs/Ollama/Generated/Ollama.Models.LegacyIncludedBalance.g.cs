
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class LegacyIncludedBalance
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("session")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.LegacyBalanceLimit Session { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("weekly")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.LegacyBalanceLimit Weekly { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyIncludedBalance" /> class.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="weekly"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public LegacyIncludedBalance(
            global::Ollama.LegacyBalanceLimit session,
            global::Ollama.LegacyBalanceLimit weekly)
        {
            this.Session = session ?? throw new global::System.ArgumentNullException(nameof(session));
            this.Weekly = weekly ?? throw new global::System.ArgumentNullException(nameof(weekly));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyIncludedBalance" /> class.
        /// </summary>
        public LegacyIncludedBalance()
        {
        }

    }
}