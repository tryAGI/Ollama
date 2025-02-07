
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Response class for the list running models endpoint.
    /// </summary>
    public sealed partial class ProcessResponse
    {
        /// <summary>
        /// List of running models.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("models")]
        public global::System.Collections.Generic.IList<global::Ollama.ProcessModel>? Models { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessResponse" /> class.
        /// </summary>
        /// <param name="models">
        /// List of running models.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ProcessResponse(
            global::System.Collections.Generic.IList<global::Ollama.ProcessModel>? models)
        {
            this.Models = models;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessResponse" /> class.
        /// </summary>
        public ProcessResponse()
        {
        }
    }
}