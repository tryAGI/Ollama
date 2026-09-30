
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneNoulAnswerType
    {
        /// <summary>
        ///
        /// </summary>
        Noul,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneNoulAnswerTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneNoulAnswerType value)
        {
            return value switch
            {
                SystemOneNoulAnswerType.Noul => "noul",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneNoulAnswerType? ToEnum(string value)
        {
            return value switch
            {
                "noul" => SystemOneNoulAnswerType.Noul,
                _ => null,
            };
        }
    }
}