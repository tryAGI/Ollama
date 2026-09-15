
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class CreateRequest
    {
        /// <summary>
        /// Name for the model to create
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Existing model to create from
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("from")]
        public string? From { get; set; }

        /// <summary>
        /// Prompt template to use for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("template")]
        public string? Template { get; set; }

        /// <summary>
        /// Name of the renderer for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("renderer")]
        public string? Renderer { get; set; }

        /// <summary>
        /// Name of the parser for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parser")]
        public string? Parser { get; set; }

        /// <summary>
        /// Source file names mapped to their SHA-256 digests. Split GGUF models must include each shard under its original split filename.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("files")]
        public global::System.Collections.Generic.Dictionary<string, string>? Files { get; set; }

        /// <summary>
        /// Draft source file names mapped to their SHA-256 digests
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("draft_files")]
        public global::System.Collections.Generic.Dictionary<string, string>? DraftFiles { get; set; }

        /// <summary>
        /// License string or list of licenses for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("license")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>))]
        public global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? License { get; set; }

        /// <summary>
        /// System prompt to embed in the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("system")]
        public string? System { get; set; }

        /// <summary>
        /// Key-value parameters for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parameters")]
        public object? Parameters { get; set; }

        /// <summary>
        /// Message history to use for the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("messages")]
        public global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? Messages { get; set; }

        /// <summary>
        /// Quantization level to apply during import (e.g. `nvfp4`)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("quantize")]
        public string? Quantize { get; set; }

        /// <summary>
        /// Quantization level to apply to draft weights during import
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("draft_quantize")]
        public string? DraftQuantize { get; set; }

        /// <summary>
        /// Minimum Ollama version required by the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("requires")]
        public string? Requires { get; set; }

        /// <summary>
        /// Stream status updates<br/>
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
        /// Initializes a new instance of the <see cref="CreateRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Name for the model to create
        /// </param>
        /// <param name="from">
        /// Existing model to create from
        /// </param>
        /// <param name="template">
        /// Prompt template to use for the model
        /// </param>
        /// <param name="renderer">
        /// Name of the renderer for the model
        /// </param>
        /// <param name="parser">
        /// Name of the parser for the model
        /// </param>
        /// <param name="files">
        /// Source file names mapped to their SHA-256 digests. Split GGUF models must include each shard under its original split filename.
        /// </param>
        /// <param name="draftFiles">
        /// Draft source file names mapped to their SHA-256 digests
        /// </param>
        /// <param name="license">
        /// License string or list of licenses for the model
        /// </param>
        /// <param name="system">
        /// System prompt to embed in the model
        /// </param>
        /// <param name="parameters">
        /// Key-value parameters for the model
        /// </param>
        /// <param name="messages">
        /// Message history to use for the model
        /// </param>
        /// <param name="quantize">
        /// Quantization level to apply during import (e.g. `nvfp4`)
        /// </param>
        /// <param name="draftQuantize">
        /// Quantization level to apply to draft weights during import
        /// </param>
        /// <param name="requires">
        /// Minimum Ollama version required by the model
        /// </param>
        /// <param name="stream">
        /// Stream status updates<br/>
        /// Default Value: true
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CreateRequest(
            string model,
            string? from,
            string? template,
            string? renderer,
            string? parser,
            global::System.Collections.Generic.Dictionary<string, string>? files,
            global::System.Collections.Generic.Dictionary<string, string>? draftFiles,
            global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? license,
            string? system,
            object? parameters,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? messages,
            string? quantize,
            string? draftQuantize,
            string? requires,
            bool? stream)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.From = from;
            this.Template = template;
            this.Renderer = renderer;
            this.Parser = parser;
            this.Files = files;
            this.DraftFiles = draftFiles;
            this.License = license;
            this.System = system;
            this.Parameters = parameters;
            this.Messages = messages;
            this.Quantize = quantize;
            this.DraftQuantize = draftQuantize;
            this.Requires = requires;
            this.Stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequest" /> class.
        /// </summary>
        public CreateRequest()
        {
        }

    }
}