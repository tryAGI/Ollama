
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum GenerateCompletionRequestThink
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
    public static class GenerateCompletionRequestThinkExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateCompletionRequestThink value)
        {
            return value switch
            {
                GenerateCompletionRequestThink.High => "high",
                GenerateCompletionRequestThink.Medium => "medium",
                GenerateCompletionRequestThink.Low => "low",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateCompletionRequestThink? ToEnum(string value)
        {
            return value switch
            {
                "high" => GenerateCompletionRequestThink.High,
                "medium" => GenerateCompletionRequestThink.Medium,
                "low" => GenerateCompletionRequestThink.Low,
                _ => null,
            };
        }
    }
}