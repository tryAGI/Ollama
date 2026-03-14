
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class EmbedRequest
    {
        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Text or array of texts to generate embeddings for
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("input")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>> Input { get; set; }

        /// <summary>
        /// If true, truncate inputs that exceed the context window. If false, returns an error.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("truncate")]
        public bool? Truncate { get; set; }

        /// <summary>
        /// Number of dimensions to generate embeddings for
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("dimensions")]
        public int? Dimensions { get; set; }

        /// <summary>
        /// Model keep-alive duration
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("keep_alive")]
        public string? KeepAlive { get; set; }

        /// <summary>
        /// Runtime options that control text generation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("options")]
        public global::Ollama.ModelOptions? Options { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbedRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="input">
        /// Text or array of texts to generate embeddings for
        /// </param>
        /// <param name="truncate">
        /// If true, truncate inputs that exceed the context window. If false, returns an error.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="dimensions">
        /// Number of dimensions to generate embeddings for
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public EmbedRequest(
            string model,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>> input,
            bool? truncate,
            int? dimensions,
            string? keepAlive,
            global::Ollama.ModelOptions? options)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Input = input;
            this.Truncate = truncate;
            this.Dimensions = dimensions;
            this.KeepAlive = keepAlive;
            this.Options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbedRequest" /> class.
        /// </summary>
        public EmbedRequest()
        {
        }
    }
}