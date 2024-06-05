
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Reason why the model is done generating a response.
    /// </summary>
    public sealed partial class DoneReason
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}