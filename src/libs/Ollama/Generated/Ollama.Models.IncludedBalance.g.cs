
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class IncludedBalance
    {
        /// <summary>
        /// Remaining included credits in USD.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("balance_usd")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double BalanceUsd { get; set; }

        /// <summary>
        /// Included credits available for the full period in USD.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowance_usd")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double AllowanceUsd { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("period")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.IncludedBalancePeriod Period { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludedBalance" /> class.
        /// </summary>
        /// <param name="balanceUsd">
        /// Remaining included credits in USD.
        /// </param>
        /// <param name="allowanceUsd">
        /// Included credits available for the full period in USD.
        /// </param>
        /// <param name="period"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public IncludedBalance(
            double balanceUsd,
            double allowanceUsd,
            global::Ollama.IncludedBalancePeriod period)
        {
            this.BalanceUsd = balanceUsd;
            this.AllowanceUsd = allowanceUsd;
            this.Period = period ?? throw new global::System.ArgumentNullException(nameof(period));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludedBalance" /> class.
        /// </summary>
        public IncludedBalance()
        {
        }

    }
}