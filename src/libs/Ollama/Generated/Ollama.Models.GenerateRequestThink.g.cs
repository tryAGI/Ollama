
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum GenerateRequestThink
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
    public static class GenerateRequestThinkExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateRequestThink value)
        {
            return value switch
            {
                GenerateRequestThink.High => "high",
                GenerateRequestThink.Low => "low",
                GenerateRequestThink.Medium => "medium",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateRequestThink? ToEnum(string value)
        {
            return value switch
            {
                "high" => GenerateRequestThink.High,
                "low" => GenerateRequestThink.Low,
                "medium" => GenerateRequestThink.Medium,
                _ => null,
            };
        }
    }
}