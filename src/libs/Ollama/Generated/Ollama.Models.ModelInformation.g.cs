
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Details about a model.
    /// </summary>
    public sealed partial class ModelInformation
    {
        /// <summary>
        /// The architecture of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("general.architecture")]
        public string? GeneralArchitecture { get; set; }

        /// <summary>
        /// The file type of the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("general.file_type")]
        public int? GeneralFileType { get; set; }

        /// <summary>
        /// The number of parameters in the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("general.parameter_count")]
        public long? GeneralParameterCount { get; set; }

        /// <summary>
        /// The number of parameters in the model.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("general.quantization_version")]
        public int? GeneralQuantizationVersion { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelInformation" /> class.
        /// </summary>
        /// <param name="generalArchitecture">
        /// The architecture of the model.
        /// </param>
        /// <param name="generalFileType">
        /// The file type of the model.
        /// </param>
        /// <param name="generalParameterCount">
        /// The number of parameters in the model.
        /// </param>
        /// <param name="generalQuantizationVersion">
        /// The number of parameters in the model.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ModelInformation(
            string? generalArchitecture,
            int? generalFileType,
            long? generalParameterCount,
            int? generalQuantizationVersion)
        {
            this.GeneralArchitecture = generalArchitecture;
            this.GeneralFileType = generalFileType;
            this.GeneralParameterCount = generalParameterCount;
            this.GeneralQuantizationVersion = generalQuantizationVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelInformation" /> class.
        /// </summary>
        public ModelInformation()
        {
        }
    }
}