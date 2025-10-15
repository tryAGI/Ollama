
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Enable JSON mode
    /// </summary>
    public enum GenerateChatCompletionRequestFormatEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class GenerateChatCompletionRequestFormatEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateChatCompletionRequestFormatEnum value)
        {
            return value switch
            {
                GenerateChatCompletionRequestFormatEnum.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateChatCompletionRequestFormatEnum? ToEnum(string value)
        {
            return value switch
            {
                "json" => GenerateChatCompletionRequestFormatEnum.Json,
                _ => null,
            };
        }
    }
}