
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class BalanceResponse
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("included")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.IncludedBalance, global::Ollama.LegacyIncludedBalance>))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.OneOf<global::Ollama.IncludedBalance, global::Ollama.LegacyIncludedBalance> Included { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("purchased")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.BalanceResponsePurchased Purchased { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        /// <param name="included"></param>
        /// <param name="purchased"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public BalanceResponse(
            global::Ollama.OneOf<global::Ollama.IncludedBalance, global::Ollama.LegacyIncludedBalance> included,
            global::Ollama.BalanceResponsePurchased purchased)
        {
            this.Included = included;
            this.Purchased = purchased ?? throw new global::System.ArgumentNullException(nameof(purchased));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        public BalanceResponse()
        {
        }

    }
}