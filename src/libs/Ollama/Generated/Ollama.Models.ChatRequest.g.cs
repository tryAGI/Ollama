
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatRequest
    {
        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Chat history as an array of message objects (each with a role and content)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("messages")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Ollama.ChatMessage> Messages { get; set; }

        /// <summary>
        /// Optional list of function tools the model may call during the chat
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tools")]
        public global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? Tools { get; set; }

        /// <summary>
        /// Format to return a response in. Can be `json` or a JSON schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("format")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.ChatRequestFormatEnum?, object>))]
        public global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? Format { get; set; }

        /// <summary>
        /// Runtime options that control text generation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("options")]
        public global::Ollama.ModelOptions? Options { get; set; }

        /// <summary>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("think")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, global::Ollama.ChatRequestThink?>))]
        public global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>? Think { get; set; }

        /// <summary>
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("keep_alive")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>))]
        public global::Ollama.OneOf<string, double?>? KeepAlive { get; set; }

        /// <summary>
        /// Whether to return log probabilities of the output tokens
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("logprobs")]
        public bool? Logprobs { get; set; }

        /// <summary>
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_logprobs")]
        public int? TopLogprobs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="messages">
        /// Chat history as an array of message objects (each with a role and content)
        /// </param>
        /// <param name="tools">
        /// Optional list of function tools the model may call during the chat
        /// </param>
        /// <param name="format">
        /// Format to return a response in. Can be `json` or a JSON schema
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
        /// </param>
        /// <param name="stream">
        /// Default Value: true
        /// </param>
        /// <param name="think">
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="logprobs">
        /// Whether to return log probabilities of the output tokens
        /// </param>
        /// <param name="topLogprobs">
        /// Number of most likely tokens to return at each token position when logprobs are enabled
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatRequest(
            string model,
            global::System.Collections.Generic.IList<global::Ollama.ChatMessage> messages,
            global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? tools,
            global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? format,
            global::Ollama.ModelOptions? options,
            bool? stream,
            global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>? think,
            global::Ollama.OneOf<string, double?>? keepAlive,
            bool? logprobs,
            int? topLogprobs)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Messages = messages ?? throw new global::System.ArgumentNullException(nameof(messages));
            this.Tools = tools;
            this.Format = format;
            this.Options = options;
            this.Stream = stream;
            this.Think = think;
            this.KeepAlive = keepAlive;
            this.Logprobs = logprobs;
            this.TopLogprobs = topLogprobs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRequest" /> class.
        /// </summary>
        public ChatRequest()
        {
        }
    }
}