
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ToolDefinition
    {
        /// <summary>
        /// Type of tool (always `function`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.ToolDefinitionTypeJsonConverter))]
        public global::Ollama.ToolDefinitionType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("function")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.ToolDefinitionFunction Function { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinition" /> class.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="type">
        /// Type of tool (always `function`)
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ToolDefinition(
            global::Ollama.ToolDefinitionFunction function,
            global::Ollama.ToolDefinitionType type)
        {
            this.Type = type;
            this.Function = function ?? throw new global::System.ArgumentNullException(nameof(function));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinition" /> class.
        /// </summary>
        public ToolDefinition()
        {
        }
    }
}