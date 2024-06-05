
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Details about a model.
    /// </summary>
    public sealed partial class ModelDetails
    {
        /// <summary>
        /// The parent model of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parent_model")]
        public string? ParentModel { get; set; }

        /// <summary>
        /// The format of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <summary>
        /// The family of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("family")]
        public string? Family { get; set; }

        /// <summary>
        /// The families of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("families")]
        public global::System.Collections.Generic.IList<string?>? Families { get; set; }

        /// <summary>
        /// The size of the model's parameters.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameter_size")]
        public string? ParameterSize { get; set; }

        /// <summary>
        /// The quantization level of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("quantization_level")]
        public string? QuantizationLevel { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}