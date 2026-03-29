
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ToolDefinitionFunction
    {
        /// <summary>
        /// Function name exposed to the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// Human-readable description of the function
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// JSON Schema for the function parameters
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameters")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required object Parameters { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinitionFunction" /> class.
        /// </summary>
        /// <param name="name">
        /// Function name exposed to the model
        /// </param>
        /// <param name="parameters">
        /// JSON Schema for the function parameters
        /// </param>
        /// <param name="description">
        /// Human-readable description of the function
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ToolDefinitionFunction(
            string name,
            object parameters,
            string? description)
        {
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
            this.Parameters = parameters ?? throw new global::System.ArgumentNullException(nameof(parameters));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinitionFunction" /> class.
        /// </summary>
        public ToolDefinitionFunction()
        {
        }
    }
}