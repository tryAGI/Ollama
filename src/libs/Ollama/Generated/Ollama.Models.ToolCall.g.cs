
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The tool the model wants to call.
    /// </summary>
    public sealed partial class ToolCall
    {
        /// <summary>
        /// The function the model wants to call.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("function")]
        public global::Ollama.ToolCallFunction? Function { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCall" /> class.
        /// </summary>
        /// <param name="function">
        /// The function the model wants to call.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ToolCall(
            global::Ollama.ToolCallFunction? function)
        {
            this.Function = function;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCall" /> class.
        /// </summary>
        public ToolCall()
        {
        }
    }
}