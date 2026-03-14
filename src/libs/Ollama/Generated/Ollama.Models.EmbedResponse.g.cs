
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class EmbedResponse
    {
        /// <summary>
        /// Model that produced the embeddings
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Array of vector embeddings
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("embeddings")]
        public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>? Embeddings { get; set; }

        /// <summary>
        /// Total time spent generating in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total_duration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Load time in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("load_duration")]
        public long? LoadDuration { get; set; }

        /// <summary>
        /// Number of input tokens processed to generate embeddings
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_count")]
        public int? PromptEvalCount { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbedResponse" /> class.
        /// </summary>
        /// <param name="model">
        /// Model that produced the embeddings
        /// </param>
        /// <param name="embeddings">
        /// Array of vector embeddings
        /// </param>
        /// <param name="totalDuration">
        /// Total time spent generating in nanoseconds
        /// </param>
        /// <param name="loadDuration">
        /// Load time in nanoseconds
        /// </param>
        /// <param name="promptEvalCount">
        /// Number of input tokens processed to generate embeddings
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public EmbedResponse(
            string? model,
            global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>? embeddings,
            long? totalDuration,
            long? loadDuration,
            int? promptEvalCount)
        {
            this.Model = model;
            this.Embeddings = embeddings;
            this.TotalDuration = totalDuration;
            this.LoadDuration = loadDuration;
            this.PromptEvalCount = promptEvalCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbedResponse" /> class.
        /// </summary>
        public EmbedResponse()
        {
        }
    }
}