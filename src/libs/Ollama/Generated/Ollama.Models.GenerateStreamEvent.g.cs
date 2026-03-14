
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GenerateStreamEvent
    {
        /// <summary>
        /// Model name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// ISO 8601 timestamp of response creation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The model's generated text response for this chunk
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("response")]
        public string? Response { get; set; }

        /// <summary>
        /// The model's generated thinking output for this chunk
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public string? Thinking { get; set; }

        /// <summary>
        /// Indicates whether the stream has finished
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done")]
        public bool? Done { get; set; }

        /// <summary>
        /// Reason streaming finished
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done_reason")]
        public string? DoneReason { get; set; }

        /// <summary>
        /// Time spent generating the response in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total_duration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Time spent loading the model in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("load_duration")]
        public long? LoadDuration { get; set; }

        /// <summary>
        /// Number of input tokens in the prompt
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_count")]
        public int? PromptEvalCount { get; set; }

        /// <summary>
        /// Time spent evaluating the prompt in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_duration")]
        public long? PromptEvalDuration { get; set; }

        /// <summary>
        /// Number of output tokens generated in the response
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_count")]
        public int? EvalCount { get; set; }

        /// <summary>
        /// Time spent generating tokens in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_duration")]
        public long? EvalDuration { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateStreamEvent" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name
        /// </param>
        /// <param name="createdAt">
        /// ISO 8601 timestamp of response creation
        /// </param>
        /// <param name="response">
        /// The model's generated text response for this chunk
        /// </param>
        /// <param name="thinking">
        /// The model's generated thinking output for this chunk
        /// </param>
        /// <param name="done">
        /// Indicates whether the stream has finished
        /// </param>
        /// <param name="doneReason">
        /// Reason streaming finished
        /// </param>
        /// <param name="totalDuration">
        /// Time spent generating the response in nanoseconds
        /// </param>
        /// <param name="loadDuration">
        /// Time spent loading the model in nanoseconds
        /// </param>
        /// <param name="promptEvalCount">
        /// Number of input tokens in the prompt
        /// </param>
        /// <param name="promptEvalDuration">
        /// Time spent evaluating the prompt in nanoseconds
        /// </param>
        /// <param name="evalCount">
        /// Number of output tokens generated in the response
        /// </param>
        /// <param name="evalDuration">
        /// Time spent generating tokens in nanoseconds
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GenerateStreamEvent(
            string? model,
            string? createdAt,
            string? response,
            string? thinking,
            bool? done,
            string? doneReason,
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
            this.DoneReason = doneReason;
            this.TotalDuration = totalDuration;
            this.LoadDuration = loadDuration;
            this.PromptEvalCount = promptEvalCount;
            this.PromptEvalDuration = promptEvalDuration;
            this.EvalCount = evalCount;
            this.EvalDuration = evalDuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateStreamEvent" /> class.
        /// </summary>
        public GenerateStreamEvent()
        {
        }
    }
}