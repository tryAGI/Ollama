
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneChoiceQuestionType
    {
        /// <summary>
        ///
        /// </summary>
        Choice,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneChoiceQuestionTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneChoiceQuestionType value)
        {
            return value switch
            {
                SystemOneChoiceQuestionType.Choice => "choice",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneChoiceQuestionType? ToEnum(string value)
        {
            return value switch
            {
                "choice" => SystemOneChoiceQuestionType.Choice,
                _ => null,
            };
        }
    }
}