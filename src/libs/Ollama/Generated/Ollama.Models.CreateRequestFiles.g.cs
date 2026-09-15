
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Source file names mapped to their SHA-256 digests. Split GGUF models must include each shard under its original split filename.
    /// </summary>
    public sealed partial class CreateRequestFiles
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

    }
}