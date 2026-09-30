
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneNoulQuestionType
    {
        /// <summary>
        ///
        /// </summary>
        Noul,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneNoulQuestionTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneNoulQuestionType value)
        {
            return value switch
            {
                SystemOneNoulQuestionType.Noul => "noul",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneNoulQuestionType? ToEnum(string value)
        {
            return value switch
            {
                "noul" => SystemOneNoulQuestionType.Noul,
                _ => null,
            };
        }
    }
}