
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Summary information for a locally available model
    /// </summary>
    public sealed partial class ModelSummary
    {
        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Name of the upstream model, if the model is remote
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("remote_model")]
        public string? RemoteModel { get; set; }

        /// <summary>
        /// URL of the upstream Ollama host, if the model is remote
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("remote_host")]
        public string? RemoteHost { get; set; }

        /// <summary>
        /// Last modified timestamp in ISO 8601 format
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("modified_at")]
        public string? ModifiedAt { get; set; }

        /// <summary>
        /// Total size of the model on disk in bytes
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("size")]
        public long? Size { get; set; }

        /// <summary>
        /// SHA256 digest identifier of the model contents
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// Additional information about the model's format and family
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("details")]
        public global::Ollama.ModelSummaryDetails? Details { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSummary" /> class.
        /// </summary>
        /// <param name="name">
        /// Model name
        /// </param>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="remoteModel">
        /// Name of the upstream model, if the model is remote
        /// </param>
        /// <param name="remoteHost">
        /// URL of the upstream Ollama host, if the model is remote
        /// </param>
        /// <param name="modifiedAt">
        /// Last modified timestamp in ISO 8601 format
        /// </param>
        /// <param name="size">
        /// Total size of the model on disk in bytes
        /// </param>
        /// <param name="digest">
        /// SHA256 digest identifier of the model contents
        /// </param>
        /// <param name="details">
        /// Additional information about the model's format and family
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelSummary(
            string? name,
            string? model,
            string? remoteModel,
            string? remoteHost,
            string? modifiedAt,
            long? size,
            string? digest,
            global::Ollama.ModelSummaryDetails? details)
        {
            this.Name = name;
            this.Model = model;
            this.RemoteModel = remoteModel;
            this.RemoteHost = remoteHost;
            this.ModifiedAt = modifiedAt;
            this.Size = size;
            this.Digest = digest;
            this.Details = details;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSummary" /> class.
        /// </summary>
        public ModelSummary()
        {
        }
    }
}