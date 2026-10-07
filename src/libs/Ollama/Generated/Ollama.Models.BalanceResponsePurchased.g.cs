
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class BalanceResponsePurchased
    {
        /// <summary>
        /// Remaining unexpired purchased credits in USD.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("balance_usd")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double BalanceUsd { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponsePurchased" /> class.
        /// </summary>
        /// <param name="balanceUsd">
        /// Remaining unexpired purchased credits in USD.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public BalanceResponsePurchased(
            double balanceUsd)
        {
            this.BalanceUsd = balanceUsd;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponsePurchased" /> class.
        /// </summary>
        public BalanceResponsePurchased()
        {
        }

    }
}