
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Map of hyper-parameters which are applied to the model
    /// </summary>
    public sealed partial class CreateModelRequestParameters
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}