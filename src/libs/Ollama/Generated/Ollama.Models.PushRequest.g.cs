
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class PushRequest
    {
        /// <summary>
        /// Name of the model to publish
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Allow publishing over insecure connections
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("insecure")]
        public bool? Insecure { get; set; }

        /// <summary>
        /// Stream progress updates<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PushRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Name of the model to publish
        /// </param>
        /// <param name="insecure">
        /// Allow publishing over insecure connections
        /// </param>
        /// <param name="stream">
        /// Stream progress updates<br/>
        /// Default Value: true
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PushRequest(
            string model,
            bool? insecure,
            bool? stream)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Insecure = insecure;
            this.Stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PushRequest" /> class.
        /// </summary>
        public PushRequest()
        {
        }
    }
}