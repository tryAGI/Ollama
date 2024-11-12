
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The arguments to pass to the function.
    /// </summary>
    public sealed partial class ToolCallFunctionArgs
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallFunctionArgs" /> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ToolCallFunctionArgs(
 )
        {
        }
    }
}