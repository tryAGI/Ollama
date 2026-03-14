
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatResponse
    {
        /// <summary>
        /// Model name used to generate this message
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Timestamp of response creation (ISO 8601)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public global::System.DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("message")]
        public global::Ollama.ChatResponseMessage? Message { get; set; }

        /// <summary>
        /// Indicates whether the chat response has finished
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done")]
        public bool? Done { get; set; }

        /// <summary>
        /// Reason the response finished
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done_reason")]
        public string? DoneReason { get; set; }

        /// <summary>
        /// Total time spent generating in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total_duration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Time spent loading the model in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("load_duration")]
        public long? LoadDuration { get; set; }

        /// <summary>
        /// Number of tokens in the prompt
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_count")]
        public int? PromptEvalCount { get; set; }

        /// <summary>
        /// Time spent evaluating the prompt in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt_eval_duration")]
        public long? PromptEvalDuration { get; set; }

        /// <summary>
        /// Number of tokens generated in the response
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_count")]
        public int? EvalCount { get; set; }

        /// <summary>
        /// Time spent generating tokens in nanoseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("eval_duration")]
        public long? EvalDuration { get; set; }

        /// <summary>
        /// Log probability information for the generated tokens when logprobs are enabled
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("logprobs")]
        public global::System.Collections.Generic.IList<global::Ollama.Logprob>? Logprobs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatResponse" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name used to generate this message
        /// </param>
        /// <param name="createdAt">
        /// Timestamp of response creation (ISO 8601)
        /// </param>
        /// <param name="message"></param>
        /// <param name="done">
        /// Indicates whether the chat response has finished
        /// </param>
        /// <param name="doneReason">
        /// Reason the response finished
        /// </param>
        /// <param name="totalDuration">
        /// Total time spent generating in nanoseconds
        /// </param>
        /// <param name="loadDuration">
        /// Time spent loading the model in nanoseconds
        /// </param>
        /// <param name="promptEvalCount">
        /// Number of tokens in the prompt
        /// </param>
        /// <param name="promptEvalDuration">
        /// Time spent evaluating the prompt in nanoseconds
        /// </param>
        /// <param name="evalCount">
        /// Number of tokens generated in the response
        /// </param>
        /// <param name="evalDuration">
        /// Time spent generating tokens in nanoseconds
        /// </param>
        /// <param name="logprobs">
        /// Log probability information for the generated tokens when logprobs are enabled
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatResponse(
            string? model,
            global::System.DateTime? createdAt,
            global::Ollama.ChatResponseMessage? message,
            bool? done,
            string? doneReason,
            long? totalDuration,
            long? loadDuration,
            int? promptEvalCount,
            long? promptEvalDuration,
            int? evalCount,
            long? evalDuration,
            global::System.Collections.Generic.IList<global::Ollama.Logprob>? logprobs)
        {
            this.Model = model;
            this.CreatedAt = createdAt;
            this.Message = message;
            this.Done = done;
            this.DoneReason = doneReason;
            this.TotalDuration = totalDuration;
            this.LoadDuration = loadDuration;
            this.PromptEvalCount = promptEvalCount;
            this.PromptEvalDuration = promptEvalDuration;
            this.EvalCount = evalCount;
            this.EvalDuration = evalDuration;
            this.Logprobs = logprobs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatResponse" /> class.
        /// </summary>
        public ChatResponse()
        {
        }
    }
}