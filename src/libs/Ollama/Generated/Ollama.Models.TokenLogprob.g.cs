
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Log probability information for a single token alternative
    /// </summary>
    public sealed partial class TokenLogprob
    {
        /// <summary>
        /// The text representation of the token
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("token")]
        public string? Token { get; set; }

        /// <summary>
        /// The log probability of this token
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("logprob")]
        public double? Logprob { get; set; }

        /// <summary>
        /// The raw byte representation of the token
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("bytes")]
        public global::System.Collections.Generic.IList<long>? Bytes { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLogprob" /> class.
        /// </summary>
        /// <param name="token">
        /// The text representation of the token
        /// </param>
        /// <param name="logprob">
        /// The log probability of this token
        /// </param>
        /// <param name="bytes">
        /// The raw byte representation of the token
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TokenLogprob(
            string? token,
            double? logprob,
            global::System.Collections.Generic.IList<long>? bytes)
        {
            this.Token = token;
            this.Logprob = logprob;
            this.Bytes = bytes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLogprob" /> class.
        /// </summary>
        public TokenLogprob()
        {
        }
    }
}