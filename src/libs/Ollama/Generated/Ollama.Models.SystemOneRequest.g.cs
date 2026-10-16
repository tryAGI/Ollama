
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class SystemOneRequest
    {
        /// <summary>
        /// Model trained for System One, such as nimble, or clef:cloud for Ollama's cloud.
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
        /// Base64-encoded images shared by all questions, in request order. Requires a model with vision, such as Clef. URLs and data URLs are not supported.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("images")]
        public global::System.Collections.Generic.IList<byte[]>? Images { get; set; }

        /// <summary>
        /// Named questions about the shared state. Answers are not passed to later questions. Cloud models accept names of up to 100 ASCII letters, digits, `_`, `.`, or `-`.
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
        /// Model trained for System One, such as nimble, or clef:cloud for Ollama's cloud.
        /// </param>
        /// <param name="state">
        /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
        /// </param>
        /// <param name="questions">
        /// Named questions about the shared state. Answers are not passed to later questions. Cloud models accept names of up to 100 ASCII letters, digits, `_`, `.`, or `-`.
        /// </param>
        /// <param name="images">
        /// Base64-encoded images shared by all questions, in request order. Requires a model with vision, such as Clef. URLs and data URLs are not supported.
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
            global::System.Collections.Generic.IList<byte[]>? images,
            global::Ollama.OneOf<string, double?>? keepAlive)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.State = state;
            this.Images = images;
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