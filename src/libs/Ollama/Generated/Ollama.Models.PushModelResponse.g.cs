
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// Response class for pushing a model.
    /// </summary>
    public sealed partial class PushModelResponse
    {
        /// <summary>
        /// Status pushing the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.AnyOfJsonConverterFactory2))]
        public global::Ollama.AnyOf<string, global::Ollama.PushModelResponseStatus?>? Status { get; set; }

        /// <summary>
        /// the model's digest<br/>
        /// Example: sha256:bc07c81de745696fdf5afca05e065818a8149fb0c77266fb584d9b2cba3711a
        /// </summary>
        /// <example>sha256:bc07c81de745696fdf5afca05e065818a8149fb0c77266fb584d9b2cba3711a</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// total size of the model<br/>
        /// Example: 2142590208L
        /// </summary>
        /// <example>2142590208L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("total")]
        public long? Total { get; set; }

        /// <summary>
        /// Total bytes transferred.<br/>
        /// Example: 2142590208L
        /// </summary>
        /// <example>2142590208L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("completed")]
        public long? Completed { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PushModelResponse" /> class.
        /// </summary>
        /// <param name="status">
        /// Status pushing the model.
        /// </param>
        /// <param name="digest">
        /// the model's digest<br/>
        /// Example: sha256:bc07c81de745696fdf5afca05e065818a8149fb0c77266fb584d9b2cba3711a
        /// </param>
        /// <param name="total">
        /// total size of the model<br/>
        /// Example: 2142590208L
        /// </param>
        /// <param name="completed">
        /// Total bytes transferred.<br/>
        /// Example: 2142590208L
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public PushModelResponse(
            global::Ollama.AnyOf<string, global::Ollama.PushModelResponseStatus?>? status,
            string? digest,
            long? total,
            long? completed)
        {
            this.Status = status;
            this.Digest = digest;
            this.Total = total;
            this.Completed = completed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PushModelResponse" /> class.
        /// </summary>
        public PushModelResponse()
        {
        }
    }
}