
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Runtime options that control text generation
    /// </summary>
    public sealed partial class ModelOptions
    {
        /// <summary>
        /// Random seed used for reproducible outputs
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("seed")]
        public int? Seed { get; set; }

        /// <summary>
        /// Controls randomness in generation (higher = more random)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("temperature")]
        public float? Temperature { get; set; }

        /// <summary>
        /// Limits next token selection to the K most likely
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_k")]
        public int? TopK { get; set; }

        /// <summary>
        /// Cumulative probability threshold for nucleus sampling
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_p")]
        public float? TopP { get; set; }

        /// <summary>
        /// Minimum probability threshold for token selection
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("min_p")]
        public float? MinP { get; set; }

        /// <summary>
        /// Stop sequences that will halt generation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stop")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>))]
        public global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? Stop { get; set; }

        /// <summary>
        /// Context length size (number of tokens)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_ctx")]
        public int? NumCtx { get; set; }

        /// <summary>
        /// Maximum number of tokens to generate
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_predict")]
        public int? NumPredict { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelOptions" /> class.
        /// </summary>
        /// <param name="seed">
        /// Random seed used for reproducible outputs
        /// </param>
        /// <param name="temperature">
        /// Controls randomness in generation (higher = more random)
        /// </param>
        /// <param name="topK">
        /// Limits next token selection to the K most likely
        /// </param>
        /// <param name="topP">
        /// Cumulative probability threshold for nucleus sampling
        /// </param>
        /// <param name="minP">
        /// Minimum probability threshold for token selection
        /// </param>
        /// <param name="stop">
        /// Stop sequences that will halt generation
        /// </param>
        /// <param name="numCtx">
        /// Context length size (number of tokens)
        /// </param>
        /// <param name="numPredict">
        /// Maximum number of tokens to generate
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelOptions(
            int? seed,
            float? temperature,
            int? topK,
            float? topP,
            float? minP,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? stop,
            int? numCtx,
            int? numPredict)
        {
            this.Seed = seed;
            this.Temperature = temperature;
            this.TopK = topK;
            this.TopP = topP;
            this.MinP = minP;
            this.Stop = stop;
            this.NumCtx = numCtx;
            this.NumPredict = numPredict;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelOptions" /> class.
        /// </summary>
        public ModelOptions()
        {
        }
    }
}