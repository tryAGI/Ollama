
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The function the model wants to call.
    /// </summary>
    public sealed partial class ToolCallFunction
    {
        /// <summary>
        /// The name of the function to be called.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// The arguments to pass to the function.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("arguments")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required object Arguments { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallFunction" /> class.
        /// </summary>
        /// <param name="name">
        /// The name of the function to be called.
        /// </param>
        /// <param name="arguments">
        /// The arguments to pass to the function.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ToolCallFunction(
            string name,
            object arguments)
        {
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Arguments = arguments ?? throw new global::System.ArgumentNullException(nameof(arguments));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallFunction" /> class.
        /// </summary>
        public ToolCallFunction()
        {
        }
    }
}