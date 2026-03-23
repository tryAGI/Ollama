
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum ChatRequestThink
    {
        /// <summary>
        /// 
        /// </summary>
        High,
        /// <summary>
        /// 
        /// </summary>
        Low,
        /// <summary>
        /// 
        /// </summary>
        Medium,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ChatRequestThinkExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ChatRequestThink value)
        {
            return value switch
            {
                ChatRequestThink.High => "high",
                ChatRequestThink.Low => "low",
                ChatRequestThink.Medium => "medium",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ChatRequestThink? ToEnum(string value)
        {
            return value switch
            {
                "high" => ChatRequestThink.High,
                "low" => ChatRequestThink.Low,
                "medium" => ChatRequestThink.Medium,
                _ => null,
            };
        }
    }
}