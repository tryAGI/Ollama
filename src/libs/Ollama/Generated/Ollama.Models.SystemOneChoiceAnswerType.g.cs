
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneChoiceAnswerType
    {
        /// <summary>
        ///
        /// </summary>
        Choice,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneChoiceAnswerTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneChoiceAnswerType value)
        {
            return value switch
            {
                SystemOneChoiceAnswerType.Choice => "choice",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneChoiceAnswerType? ToEnum(string value)
        {
            return value switch
            {
                "choice" => SystemOneChoiceAnswerType.Choice,
                _ => null,
            };
        }
    }
}