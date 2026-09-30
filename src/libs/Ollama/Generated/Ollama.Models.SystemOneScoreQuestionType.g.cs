
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum SystemOneScoreQuestionType
    {
        /// <summary>
        ///
        /// </summary>
        Score,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SystemOneScoreQuestionTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SystemOneScoreQuestionType value)
        {
            return value switch
            {
                SystemOneScoreQuestionType.Score => "score",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SystemOneScoreQuestionType? ToEnum(string value)
        {
            return value switch
            {
                "score" => SystemOneScoreQuestionType.Score,
                _ => null,
            };
        }
    }
}