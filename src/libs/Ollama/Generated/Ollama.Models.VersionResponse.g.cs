
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The response class for the version endpoint.
    /// </summary>
    public sealed partial class VersionResponse
    {
        /// <summary>
        /// The version of the Ollama server.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionResponse" /> class.
        /// </summary>
        /// <param name="version">
        /// The version of the Ollama server.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public VersionResponse(
            string? version)
        {
            this.Version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionResponse" /> class.
        /// </summary>
        public VersionResponse()
        {
        }
    }
}