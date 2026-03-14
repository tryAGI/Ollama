
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum ChatRequestFormatEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ChatRequestFormatEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ChatRequestFormatEnum value)
        {
            return value switch
            {
                ChatRequestFormatEnum.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ChatRequestFormatEnum? ToEnum(string value)
        {
            return value switch
            {
                "json" => ChatRequestFormatEnum.Json,
                _ => null,
            };
        }
    }
}