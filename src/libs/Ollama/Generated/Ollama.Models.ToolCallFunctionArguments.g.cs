
#nullable enable

namespace Ollama
{
    /// <summary>
    /// JSON object of arguments to pass to the function
    /// </summary>
    public sealed partial class ToolCallFunctionArguments
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}