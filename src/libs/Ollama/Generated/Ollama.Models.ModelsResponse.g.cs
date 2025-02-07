
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Response class for the list models endpoint.
    /// </summary>
    public sealed partial class ModelsResponse
    {
        /// <summary>
        /// List of models available locally.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("models")]
        public global::System.Collections.Generic.IList<global::Ollama.Model>? Models { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsResponse" /> class.
        /// </summary>
        /// <param name="models">
        /// List of models available locally.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelsResponse(
            global::System.Collections.Generic.IList<global::Ollama.Model>? models)
        {
            this.Models = models;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsResponse" /> class.
        /// </summary>
        public ModelsResponse()
        {
        }
    }
}