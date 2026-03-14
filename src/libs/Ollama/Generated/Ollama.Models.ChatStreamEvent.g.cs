
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatStreamEvent
    {
        /// <summary>
        /// Model name used for this stream event
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// When this chunk was created (ISO 8601)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public global::System.DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("message")]
        public global::Ollama.ChatStreamEventMessage? Message { get; set; }

        /// <summary>
        /// True for the final event in the stream
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("done")]
        public bool? Done { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatStreamEvent" /> class.
        /// </summary>
        /// <param name="model">
        /// Model name used for this stream event
        /// </param>
        /// <param name="createdAt">
        /// When this chunk was created (ISO 8601)
        /// </param>
        /// <param name="message"></param>
        /// <param name="done">
        /// True for the final event in the stream
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatStreamEvent(
            string? model,
            global::System.DateTime? createdAt,
            global::Ollama.ChatStreamEventMessage? message,
            bool? done)
        {
            this.Model = model;
            this.CreatedAt = createdAt;
            this.Message = message;
            this.Done = done;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatStreamEvent" /> class.
        /// </summary>
        public ChatStreamEvent()
        {
        }
    }
}