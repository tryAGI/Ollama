
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
        Medium,
        /// <summary>
        /// 
        /// </summary>
        Low,
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
                GenerateRequestThink.Medium => "medium",
                GenerateRequestThink.Low => "low",
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
                "medium" => GenerateRequestThink.Medium,
                "low" => GenerateRequestThink.Low,
                _ => null,
            };
        }
    }
}