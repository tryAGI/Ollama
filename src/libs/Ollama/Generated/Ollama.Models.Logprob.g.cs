
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Log probability information for a generated token
    /// </summary>
    public sealed partial class Logprob
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
        public double? Logprob1 { get; set; }

        /// <summary>
        /// The raw byte representation of the token
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("bytes")]
        public global::System.Collections.Generic.IList<long>? Bytes { get; set; }

        /// <summary>
        /// Most likely tokens and their log probabilities at this position
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_logprobs")]
        public global::System.Collections.Generic.IList<global::Ollama.TokenLogprob>? TopLogprobs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Logprob" /> class.
        /// </summary>
        /// <param name="token">
        /// The text representation of the token
        /// </param>
        /// <param name="logprob1">
        /// The log probability of this token
        /// </param>
        /// <param name="bytes">
        /// The raw byte representation of the token
        /// </param>
        /// <param name="topLogprobs">
        /// Most likely tokens and their log probabilities at this position
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public Logprob(
            string? token,
            double? logprob1,
            global::System.Collections.Generic.IList<long>? bytes,
            global::System.Collections.Generic.IList<global::Ollama.TokenLogprob>? topLogprobs)
        {
            this.Token = token;
            this.Logprob1 = logprob1;
            this.Bytes = bytes;
            this.TopLogprobs = topLogprobs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logprob" /> class.
        /// </summary>
        public Logprob()
        {
        }
    }
}