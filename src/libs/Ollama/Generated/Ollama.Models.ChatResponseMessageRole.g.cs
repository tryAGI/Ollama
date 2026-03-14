
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Always `assistant` for model responses
    /// </summary>
    public enum ChatResponseMessageRole
    {
        /// <summary>
        /// 
        /// </summary>
        Assistant,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ChatResponseMessageRoleExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ChatResponseMessageRole value)
        {
            return value switch
            {
                ChatResponseMessageRole.Assistant => "assistant",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ChatResponseMessageRole? ToEnum(string value)
        {
            return value switch
            {
                "assistant" => ChatResponseMessageRole.Assistant,
                _ => null,
            };
        }
    }
}