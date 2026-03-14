
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatResponseMessage
    {
        /// <summary>
        /// Always `assistant` for model responses
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("role")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.ChatResponseMessageRoleJsonConverter))]
        public global::Ollama.ChatResponseMessageRole? Role { get; set; }

        /// <summary>
        /// Assistant message text
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Optional deliberate thinking trace when `think` is enabled
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public string? Thinking { get; set; }

        /// <summary>
        /// Tool calls requested by the assistant
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tool_calls")]
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? ToolCalls { get; set; }

        /// <summary>
        /// Optional base64-encoded images in the response
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("images")]
        public global::System.Collections.Generic.IList<string>? Images { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatResponseMessage" /> class.
        /// </summary>
        /// <param name="role">
        /// Always `assistant` for model responses
        /// </param>
        /// <param name="content">
        /// Assistant message text
        /// </param>
        /// <param name="thinking">
        /// Optional deliberate thinking trace when `think` is enabled
        /// </param>
        /// <param name="toolCalls">
        /// Tool calls requested by the assistant
        /// </param>
        /// <param name="images">
        /// Optional base64-encoded images in the response
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatResponseMessage(
            global::Ollama.ChatResponseMessageRole? role,
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
        /// Initializes a new instance of the <see cref="ChatResponseMessage" /> class.
        /// </summary>
        public ChatResponseMessage()
        {
        }
    }
}