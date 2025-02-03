
#nullable enable

namespace Ollama
{
    /// <summary>
    /// A JSON Schema object that defines the structure of the response. The model will generate a response that matches this schema.
    /// </summary>
    public sealed partial class ResponseFormatEnum2
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}