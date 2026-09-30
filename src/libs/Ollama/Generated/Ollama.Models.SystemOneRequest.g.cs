
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneRequest
    {
        /// <summary>
        /// Local model trained for System One, such as nimble. Requires compatible GGUF weights and a scoring-capable runner; cloud and MLX/Safetensors models are not supported.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("state")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.SystemOneContentJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.SystemOneContent State { get; set; }

        /// <summary>
        /// Named questions about the shared state. Each is scored separately against the full state and question schema; answers are not passed to later questions.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("questions")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required object Questions { get; set; }

        /// <summary>
        /// How long to keep the model loaded after the request, as a duration string (such as 5m) or seconds. Zero unloads after the request; a negative value keeps it loaded. Defaults to the server's keep-alive setting (5m unless configured otherwise).
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("keep_alive")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>))]
        public global::Ollama.OneOf<string, double?>? KeepAlive { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Local model trained for System One, such as nimble. Requires compatible GGUF weights and a scoring-capable runner; cloud and MLX/Safetensors models are not supported.
        /// </param>
        /// <param name="state">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="questions">
        /// Named questions about the shared state. Each is scored separately against the full state and question schema; answers are not passed to later questions.
        /// </param>
        /// <param name="keepAlive">
        /// How long to keep the model loaded after the request, as a duration string (such as 5m) or seconds. Zero unloads after the request; a negative value keeps it loaded. Defaults to the server's keep-alive setting (5m unless configured otherwise).
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SystemOneRequest(
            string model,
            global::Ollama.SystemOneContent state,
            object questions,
            global::Ollama.OneOf<string, double?>? keepAlive)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.State = state;
            this.Questions = questions ?? throw new global::System.ArgumentNullException(nameof(questions));
            this.KeepAlive = keepAlive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemOneRequest" /> class.
        /// </summary>
        public SystemOneRequest()
        {
        }

    }
}