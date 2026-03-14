
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatStreamEventMessage
    {
        /// <summary>
        /// Role of the message for this chunk
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>
        /// Partial assistant message text
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Partial thinking text when `think` is enabled
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public string? Thinking { get; set; }

        /// <summary>
        /// Partial tool calls, if any
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tool_calls")]
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? ToolCalls { get; set; }

        /// <summary>
        /// Partial base64-encoded images, when present
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("images")]
        public global::System.Collections.Generic.IList<string>? Images { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatStreamEventMessage" /> class.
        /// </summary>
        /// <param name="role">
        /// Role of the message for this chunk
        /// </param>
        /// <param name="content">
        /// Partial assistant message text
        /// </param>
        /// <param name="thinking">
        /// Partial thinking text when `think` is enabled
        /// </param>
        /// <param name="toolCalls">
        /// Partial tool calls, if any
        /// </param>
        /// <param name="images">
        /// Partial base64-encoded images, when present
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatStreamEventMessage(
            string? role,
            string? content,
            string? thinking,
            global::System.Collections.Generic.IList<global::Ollama.ToolCall>? toolCalls,
            global::System.Collections.Generic.IList<string>? images)
        {
            this.Role = role;
            this.Content = content;
            this.Thinking = thinking;
            this.ToolCalls = toolCalls;
            this.Images = images;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatStreamEventMessage" /> class.
        /// </summary>
        public ChatStreamEventMessage()
        {
        }
    }
}