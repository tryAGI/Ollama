
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
        [global::System.Text.Json.Serialization.JsonPropertyName("response")]
        public string? Response { get; set; }

        /// <summary>
        /// Whether the response has completed.<br/>
        /// Example: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done")]
        public bool? Done { get; set; }

        /// <summary>
        /// An encoding of the conversation used in this response, this can be sent in the next request to keep a conversational memory.<br/>
        /// Example: [1L, 2L, 3L]
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("context")]
        public global::System.Collections.Generic.IList<long>? Context { get; set; }

        /// <summary>
        /// Time spent generating the response.<br/>
        /// Example: 5589157167L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total_duration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Time spent in nanoseconds loading the model.<br/>
        /// Example: 3013701500L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("load_duration")]
        public long? LoadDuration { get; set; }

        /// <summary>
        /// Number of tokens in the prompt.<br/>
        /// Example: 46
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_count")]
        public int? PromptEvalCount { get; set; }

        /// <summary>
        /// Time spent in nanoseconds evaluating the prompt.<br/>
        /// Example: 1160282000L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_duration")]
        public long? PromptEvalDuration { get; set; }

        /// <summary>
        /// Number of tokens the response.<br/>
        /// Example: 113
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_count")]
        public int? EvalCount { get; set; }

        /// <summary>
        /// Time in nanoseconds spent generating the response.<br/>
        /// Example: 1325948000L
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_duration")]
        public long? EvalDuration { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}