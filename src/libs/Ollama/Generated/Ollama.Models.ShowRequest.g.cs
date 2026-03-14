
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ShowRequest
    {
        /// <summary>
        /// Model name to show
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// If true, includes large verbose fields in the response.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("verbose")]
        public bool? Verbose { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name to show
        /// </param>
        /// <param name="verbose">
        /// If true, includes large verbose fields in the response.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ShowRequest(
            string model,
            bool? verbose)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Verbose = verbose;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowRequest" /> class.
        /// </summary>
        public ShowRequest()
        {
        }
    }
}