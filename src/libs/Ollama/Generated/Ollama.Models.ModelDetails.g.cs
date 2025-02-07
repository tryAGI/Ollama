
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
        public global::System.Collections.Generic.IList<string>? Families { get; set; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDetails" /> class.
        /// </summary>
        /// <param name="parentModel">
        /// The parent model of the model.
        /// </param>
        /// <param name="format">
        /// The format of the model.
        /// </param>
        /// <param name="family">
        /// The family of the model.
        /// </param>
        /// <param name="families">
        /// The families of the model.
        /// </param>
        /// <param name="parameterSize">
        /// The size of the model's parameters.
        /// </param>
        /// <param name="quantizationLevel">
        /// The quantization level of the model.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelDetails(
            string? parentModel,
            string? format,
            string? family,
            global::System.Collections.Generic.IList<string>? families,
            string? parameterSize,
            string? quantizationLevel)
        {
            this.ParentModel = parentModel;
            this.Format = format;
            this.Family = family;
            this.Families = families;
            this.ParameterSize = parameterSize;
            this.QuantizationLevel = quantizationLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDetails" /> class.
        /// </summary>
        public ModelDetails()
        {
        }
    }
}