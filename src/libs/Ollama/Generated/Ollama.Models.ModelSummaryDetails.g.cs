
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Additional information about the model's format and family
    /// </summary>
    public sealed partial class ModelSummaryDetails
    {
        /// <summary>
        /// Model file format (for example `gguf`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <summary>
        /// Primary model family (for example `llama`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("family")]
        public string? Family { get; set; }

        /// <summary>
        /// All families the model belongs to, when applicable
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("families")]
        public global::System.Collections.Generic.IList<string>? Families { get; set; }

        /// <summary>
        /// Approximate parameter count label (for example `7B`, `13B`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameter_size")]
        public string? ParameterSize { get; set; }

        /// <summary>
        /// Quantization level used (for example `Q4_0`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("quantization_level")]
        public string? QuantizationLevel { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSummaryDetails" /> class.
        /// </summary>
        /// <param name="format">
        /// Model file format (for example `gguf`)
        /// </param>
        /// <param name="family">
        /// Primary model family (for example `llama`)
        /// </param>
        /// <param name="families">
        /// All families the model belongs to, when applicable
        /// </param>
        /// <param name="parameterSize">
        /// Approximate parameter count label (for example `7B`, `13B`)
        /// </param>
        /// <param name="quantizationLevel">
        /// Quantization level used (for example `Q4_0`)
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelSummaryDetails(
            string? format,
            string? family,
            global::System.Collections.Generic.IList<string>? families,
            string? parameterSize,
            string? quantizationLevel)
        {
            this.Format = format;
            this.Family = family;
            this.Families = families;
            this.ParameterSize = parameterSize;
            this.QuantizationLevel = quantizationLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSummaryDetails" /> class.
        /// </summary>
        public ModelSummaryDetails()
        {
        }
    }
}