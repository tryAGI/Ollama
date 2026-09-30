
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneScoreAnswerType
    {
        /// <summary>
        ///
        /// </summary>
        Score,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneScoreAnswerTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneScoreAnswerType value)
        {
            return value switch
            {
                SystemOneScoreAnswerType.Score => "score",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneScoreAnswerType? ToEnum(string value)
        {
            return value switch
            {
                "score" => SystemOneScoreAnswerType.Score,
                _ => null,
            };
        }
    }
}