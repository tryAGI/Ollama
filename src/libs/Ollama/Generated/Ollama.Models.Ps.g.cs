
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class Ps
    {
        /// <summary>
        /// Name of the running model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Name of the running model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Size of the model in bytes
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("size")]
        public long? Size { get; set; }

        /// <summary>
        /// SHA256 digest of the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// Model details such as format and family
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("details")]
        public object? Details { get; set; }

        /// <summary>
        /// Time when the model will be unloaded
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("expires_at")]
        public string? ExpiresAt { get; set; }

        /// <summary>
        /// VRAM usage in bytes
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("size_vram")]
        public int? SizeVram { get; set; }

        /// <summary>
        /// Context length for the running model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("context_length")]
        public int? ContextLength { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Ps" /> class.
        /// </summary>
        /// <param name="name">
        /// Name of the running model
        /// </param>
        /// <param name="model">
        /// Name of the running model
        /// </param>
        /// <param name="size">
        /// Size of the model in bytes
        /// </param>
        /// <param name="digest">
        /// SHA256 digest of the model
        /// </param>
        /// <param name="details">
        /// Model details such as format and family
        /// </param>
        /// <param name="expiresAt">
        /// Time when the model will be unloaded
        /// </param>
        /// <param name="sizeVram">
        /// VRAM usage in bytes
        /// </param>
        /// <param name="contextLength">
        /// Context length for the running model
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public Ps(
            string? name,
            string? model,
            long? size,
            string? digest,
            object? details,
            string? expiresAt,
            int? sizeVram,
            int? contextLength)
        {
            this.Name = name;
            this.Model = model;
            this.Size = size;
            this.Digest = digest;
            this.Details = details;
            this.ExpiresAt = expiresAt;
            this.SizeVram = sizeVram;
            this.ContextLength = contextLength;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ps" /> class.
        /// </summary>
        public Ps()
        {
        }
    }
}