
#nullable enable

namespace Ollama
{
    /// <summary>
    /// A function that the model may call.
    /// </summary>
    public sealed partial class ToolFunction
    {
        /// <summary>
        /// The name of the function to be called.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// A description of what the function does, used by the model to choose when and how to call the function.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Description { get; set; }

        /// <summary>
        /// The parameters the functions accepts, described as a JSON Schema object.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameters")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required object Parameters { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}