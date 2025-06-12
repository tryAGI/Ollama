
#nullable enable

namespace Ollama
{
    /// <summary>
    /// A message in the chat endpoint
    /// </summary>
    public sealed partial class Message
    {
        /// <summary>
        /// The role of the message
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("role")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Ollama.JsonConverters.MessageRoleJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Ollama.MessageRole Role { get; set; }

        /// <summary>
        /// The content of the message<br/>
        /// Example: Why is the sky blue?
        /// </summary>
        /// <example>Why is the sky blue?</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("content")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Content { get; set; }

        /// <summary>
        /// Contains the text that was inside thinking tags in the original model output when `think` is enabled.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("thinking")]
        public string? Thinking { get; set; }

        /// <summary>
        /// (optional) a list of Base64-encoded images to include in the message (for multimodal models such as llava)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("images")]
        public global::System.Collections.Generic.IList<string>? Images { get; set; }

        /// <summary>
        /// A list of tools the model wants to call.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tool_calls")]
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? ToolCalls { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        /// <param name="role">
        /// The role of the message
        /// </param>
        /// <param name="content">
        /// The content of the message<br/>
        /// Example: Why is the sky blue?
        /// </param>
        /// <param name="thinking">
        /// Contains the text that was inside thinking tags in the original model output when `think` is enabled.
        /// </param>
        /// <param name="images">
        /// (optional) a list of Base64-encoded images to include in the message (for multimodal models such as llava)
        /// </param>
        /// <param name="toolCalls">
        /// A list of tools the model wants to call.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public Message(
            global::Ollama.MessageRole role,
            string content,
            string? thinking,
            global::System.Collections.Generic.IList<string>? images,
            global::System.Collections.Generic.IList<global::Ollama.ToolCall>? toolCalls)
        {
            this.Role = role;
            this.Content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            this.Thinking = thinking;
            this.Images = images;
            this.ToolCalls = toolCalls;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        public Message()
        {
        }
    }
}