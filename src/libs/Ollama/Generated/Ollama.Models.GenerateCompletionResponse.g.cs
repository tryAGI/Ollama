
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The response class for the generate endpoint.
    /// </summary>
    public sealed partial class GenerateCompletionResponse
    {
        /// <summary>
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </summary>
        /// <example>llama3.2</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Date on which a model was created.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public global::System.DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The response for a given prompt with a provided model.<br/>
        /// Example: The sky appears blue because of a phenomenon called Rayleigh scattering.
        /// </summary>
        /// <example>The sky appears blue because of a phenomenon called Rayleigh scattering.</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("response")]
        public string? Response { get; set; }

        /// <summary>
        /// Contains the text that was inside thinking tags in the original model output when `think` is enabled.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public string? Thinking { get; set; }

        /// <summary>
        /// Whether the response has completed.<br/>
        /// Example: true
        /// </summary>
        /// <example>true</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("done")]
        public bool? Done { get; set; }

        /// <summary>
        /// An encoding of the conversation used in this response, this can be sent in the next request to keep a conversational memory.<br/>
        /// Example: [1L, 2L, 3L]
        /// </summary>
        /// <example>[1L, 2L, 3L]</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("context")]
        public global::System.Collections.Generic.IList<long>? Context { get; set; }

        /// <summary>
        /// Time spent generating the response.<br/>
        /// Example: 5589157167L
        /// </summary>
        /// <example>5589157167L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("total_duration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Time spent in nanoseconds loading the model.<br/>
        /// Example: 3013701500L
        /// </summary>
        /// <example>3013701500L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("load_duration")]
        public long? LoadDuration { get; set; }

        /// <summary>
        /// Number of tokens in the prompt.<br/>
        /// Example: 46
        /// </summary>
        /// <example>46</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_count")]
        public int? PromptEvalCount { get; set; }

        /// <summary>
        /// Time spent in nanoseconds evaluating the prompt.<br/>
        /// Example: 1160282000L
        /// </summary>
        /// <example>1160282000L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_duration")]
        public long? PromptEvalDuration { get; set; }

        /// <summary>
        /// Number of tokens the response.<br/>
        /// Example: 113
        /// </summary>
        /// <example>113</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_count")]
        public int? EvalCount { get; set; }

        /// <summary>
        /// Time in nanoseconds spent generating the response.<br/>
        /// Example: 1325948000L
        /// </summary>
        /// <example>1325948000L</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_duration")]
        public long? EvalDuration { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCompletionResponse" /> class.
        /// </summary>
        /// <param name="model">
        /// The model name. <br/>
        /// Model names follow a `model:tag` format. Some examples are `orca-mini:3b-q4_1` and `llama3:70b`. The tag is optional and, if not provided, will default to `latest`. The tag is used to identify a specific version.<br/>
        /// Example: llama3.2
        /// </param>
        /// <param name="createdAt">
        /// Date on which a model was created.
        /// </param>
        /// <param name="response">
        /// The response for a given prompt with a provided model.<br/>
        /// Example: The sky appears blue because of a phenomenon called Rayleigh scattering.
        /// </param>
        /// <param name="thinking">
        /// Contains the text that was inside thinking tags in the original model output when `think` is enabled.
        /// </param>
        /// <param name="done">
        /// Whether the response has completed.<br/>
        /// Example: true
        /// </param>
        /// <param name="context">
        /// An encoding of the conversation used in this response, this can be sent in the next request to keep a conversational memory.<br/>
        /// Example: [1L, 2L, 3L]
        /// </param>
        /// <param name="totalDuration">
        /// Time spent generating the response.<br/>
        /// Example: 5589157167L
        /// </param>
        /// <param name="loadDuration">
        /// Time spent in nanoseconds loading the model.<br/>
        /// Example: 3013701500L
        /// </param>
        /// <param name="promptEvalCount">
        /// Number of tokens in the prompt.<br/>
        /// Example: 46
        /// </param>
        /// <param name="promptEvalDuration">
        /// Time spent in nanoseconds evaluating the prompt.<br/>
        /// Example: 1160282000L
        /// </param>
        /// <param name="evalCount">
        /// Number of tokens the response.<br/>
        /// Example: 113
        /// </param>
        /// <param name="evalDuration">
        /// Time in nanoseconds spent generating the response.<br/>
        /// Example: 1325948000L
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GenerateCompletionResponse(
            string? model,
            global::System.DateTime? createdAt,
            string? response,
            string? thinking,
            bool? done,
            global::System.Collections.Generic.IList<long>? context,
            long? totalDuration,
            long? loadDuration,
            int? promptEvalCount,
            long? promptEvalDuration,
            int? evalCount,
            long? evalDuration)
        {
            this.Model = model;
            this.CreatedAt = createdAt;
            this.Response = response;
            this.Thinking = thinking;
            this.Done = done;
            this.Context = context;
            this.TotalDuration = totalDuration;
            this.LoadDuration = loadDuration;
            this.PromptEvalCount = promptEvalCount;
            this.PromptEvalDuration = promptEvalDuration;
            this.EvalCount = evalCount;
            this.EvalDuration = evalDuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCompletionResponse" /> class.
        /// </summary>
        public GenerateCompletionResponse()
        {
        }
    }
}