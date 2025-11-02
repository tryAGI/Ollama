
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum GenerateChatCompletionRequestThink
    {
        /// <summary>
        /// 
        /// </summary>
        High,
        /// <summary>
        /// 
        /// </summary>
        Medium,
        /// <summary>
        /// 
        /// </summary>
        Low,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class GenerateChatCompletionRequestThinkExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateChatCompletionRequestThink value)
        {
            return value switch
            {
                GenerateChatCompletionRequestThink.High => "high",
                GenerateChatCompletionRequestThink.Medium => "medium",
                GenerateChatCompletionRequestThink.Low => "low",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateChatCompletionRequestThink? ToEnum(string value)
        {
            return value switch
            {
                "high" => GenerateChatCompletionRequestThink.High,
                "medium" => GenerateChatCompletionRequestThink.Medium,
                "low" => GenerateChatCompletionRequestThink.Low,
                _ => null,
            };
        }
    }
}