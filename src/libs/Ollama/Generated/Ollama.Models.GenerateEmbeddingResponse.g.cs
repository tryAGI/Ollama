
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Returns the embedding information.
    /// </summary>
    public sealed partial class GenerateEmbeddingResponse
    {
        /// <summary>
        /// The embedding for the prompt.<br/>
        /// Example: [0.5670403838157654, 0.009260174818336964, ...]
        /// </summary>
        /// <example>[0.5670403838157654, 0.009260174818336964, ...]</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("embedding")]
        public global::System.Collections.Generic.IList<double>? Embedding { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateEmbeddingResponse" /> class.
        /// </summary>
        /// <param name="embedding">
        /// The embedding for the prompt.<br/>
        /// Example: [0.5670403838157654, 0.009260174818336964, ...]
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public GenerateEmbeddingResponse(
            global::System.Collections.Generic.IList<double>? embedding)
        {
            this.Embedding = embedding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateEmbeddingResponse" /> class.
        /// </summary>
        public GenerateEmbeddingResponse()
        {
        }
    }
}