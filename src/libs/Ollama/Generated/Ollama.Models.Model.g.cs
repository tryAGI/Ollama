
#nullable enable

namespace Ollama
{
    /// <summary>
    /// A model available locally.
    /// </summary>
    public sealed partial class Model
    {
        /// <summary>
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.1
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model1 { get; set; }

        /// <summary>
        /// Model modification date.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("modified_at")]
        public global::System.DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Size of the model on disk.<br/>
        /// Example: 7323310500L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// The model's digest.<br/>
        /// Example: sha256:bc07c81de745696fdf5afca05e065818a8149fb0c77266fb584d9b2cba3711a
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// Details about a model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("details")]
        public global::Ollama.ModelDetails? Details { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}