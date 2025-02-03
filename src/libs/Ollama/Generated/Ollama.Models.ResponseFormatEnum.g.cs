
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Enable JSON mode by setting the format parameter to 'json'. This will structure the response as valid JSON.
    /// </summary>
    public enum ResponseFormatEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ResponseFormatEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ResponseFormatEnum value)
        {
            return value switch
            {
                ResponseFormatEnum.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ResponseFormatEnum? ToEnum(string value)
        {
            return value switch
            {
                "json" => ResponseFormatEnum.Json,
                _ => null,
            };
        }
    }
}