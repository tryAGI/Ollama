
#nullable enable

namespace Ollama
{
    /// <summary>
    /// A tool the model may call.
    /// </summary>
    public sealed partial class Tool
    {
        /// <summary>
        /// The type of tool.<br/>
        /// Default Value: function
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.ToolTypeJsonConverter))]
        public global::Ollama.ToolType? Type { get; set; }

        /// <summary>
        /// A function that the model may call.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("function")]
        public global::Ollama.ToolFunction? Function { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool" /> class.
        /// </summary>
        /// <param name="type">
        /// The type of tool.<br/>
        /// Default Value: function
        /// </param>
        /// <param name="function">
        /// A function that the model may call.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public Tool(
            global::Ollama.ToolType? type,
            global::Ollama.ToolFunction? function)
        {
            this.Type = type;
            this.Function = function;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool" /> class.
        /// </summary>
        public Tool()
        {
        }
    }
}