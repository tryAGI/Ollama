
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Enable JSON mode<br/>
    /// Default Value: json
    /// </summary>
    public enum GenerateCompletionRequestFormatEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class GenerateCompletionRequestFormatEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateCompletionRequestFormatEnum value)
        {
            return value switch
            {
                GenerateCompletionRequestFormatEnum.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateCompletionRequestFormatEnum? ToEnum(string value)
        {
            return value switch
            {
                "json" => GenerateCompletionRequestFormatEnum.Json,
                _ => null,
            };
        }
    }
}