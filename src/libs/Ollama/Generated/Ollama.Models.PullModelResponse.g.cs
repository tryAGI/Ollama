
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Response class for pulling a model. <br/>
    /// The first object is the manifest. Then there is a series of downloading responses. Until any of the download is completed, the `completed` key may not be included. <br/>
    /// The number of files to be downloaded depends on the number of layers specified in the manifest.
    /// </summary>
    public sealed partial class PullModelResponse
    {
        /// <summary>
        /// Status pulling the model.<br/>
        /// Example: pulling manifest
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.PullModelStatusJsonConverter))]
        public global::Ollama.PullModelStatus? Status { get; set; }

        /// <summary>
        /// The model's digest.<br/>
        /// Example: sha256:bc07c81de745696fdf5afca05e065818a8149fb0c77266fb584d9b2cba3711a
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// Total size of the model.<br/>
        /// Example: 2142590208L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total")]
        public long Total { get; set; }

        /// <summary>
        /// Total bytes transferred.<br/>
        /// Example: 2142590208L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("completed")]
        public long Completed { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}