
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GenerateRequest
    {
        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Text for the model to generate a response from
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// Used for fill-in-the-middle models, text that appears after the user prompt and before the model response
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("suffix")]
        public string? Suffix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("images")]
        public global::System.Collections.Generic.IList<string>? Images { get; set; }

        /// <summary>
        /// Structured output format for the model to generate a response from. Supports either the string `"json"` or a JSON schema object.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("format")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, object>))]
        public global::Ollama.OneOf<string, object>? Format { get; set; }

        /// <summary>
        /// System prompt for the model to generate a response from
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("system")]
        public string? System { get; set; }

        /// <summary>
        /// When true, returns a stream of partial responses<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("think")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, global::Ollama.GenerateRequestThink?>))]
        public global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>? Think { get; set; }

        /// <summary>
        /// When true, returns the raw response from the model without any prompt templating
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("raw")]
        public bool? Raw { get; set; }

        /// <summary>
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("keep_alive")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>))]
        public global::Ollama.OneOf<string, double?>? KeepAlive { get; set; }

        /// <summary>
        /// Runtime options that control text generation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("options")]
        public global::Ollama.ModelOptions? Options { get; set; }

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
        /// Initializes a new instance of the <see cref="GenerateRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="prompt">
        /// Text for the model to generate a response from
        /// </param>
        /// <param name="suffix">
        /// Used for fill-in-the-middle models, text that appears after the user prompt and before the model response
        /// </param>
        /// <param name="images"></param>
        /// <param name="format">
        /// Structured output format for the model to generate a response from. Supports either the string `"json"` or a JSON schema object.
        /// </param>
        /// <param name="system">
        /// System prompt for the model to generate a response from
        /// </param>
        /// <param name="stream">
        /// When true, returns a stream of partial responses<br/>
        /// Default Value: true
        /// </param>
        /// <param name="think">
        /// When true, returns separate thinking output in addition to content. Can be a boolean (true/false) or a string ("high", "medium", "low") for supported models.
        /// </param>
        /// <param name="raw">
        /// When true, returns the raw response from the model without any prompt templating
        /// </param>
        /// <param name="keepAlive">
        /// Model keep-alive duration (for example `5m` or `0` to unload immediately)
        /// </param>
        /// <param name="options">
        /// Runtime options that control text generation
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
        public GenerateRequest(
            string model,
            string? prompt,
            string? suffix,
            global::System.Collections.Generic.IList<string>? images,
            global::Ollama.OneOf<string, object>? format,
            string? system,
            bool? stream,
            global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>? think,
            bool? raw,
            global::Ollama.OneOf<string, double?>? keepAlive,
            global::Ollama.ModelOptions? options,
            bool? logprobs,
            int? topLogprobs)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Prompt = prompt;
            this.Suffix = suffix;
            this.Images = images;
            this.Format = format;
            this.System = system;
            this.Stream = stream;
            this.Think = think;
            this.Raw = raw;
            this.KeepAlive = keepAlive;
            this.Options = options;
            this.Logprobs = logprobs;
            this.TopLogprobs = topLogprobs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateRequest" /> class.
        /// </summary>
        public GenerateRequest()
        {
        }
    }
}