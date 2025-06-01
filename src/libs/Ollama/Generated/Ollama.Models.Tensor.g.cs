
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Metadata for a given tensor.
    /// </summary>
    public sealed partial class Tensor
    {
        /// <summary>
        /// The name of the tensor.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The type of the tensor.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// The shape of the tensor.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("shape")]
        public global::System.Collections.Generic.IList<long>? Shape { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Tensor" /> class.
        /// </summary>
        /// <param name="name">
        /// The name of the tensor.
        /// </param>
        /// <param name="type">
        /// The type of the tensor.
        /// </param>
        /// <param name="shape">
        /// The shape of the tensor.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public Tensor(
            string? name,
            string? type,
            global::System.Collections.Generic.IList<long>? shape)
        {
            this.Name = name;
            this.Type = type;
            this.Shape = shape;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tensor" /> class.
        /// </summary>
        public Tensor()
        {
        }
    }
}