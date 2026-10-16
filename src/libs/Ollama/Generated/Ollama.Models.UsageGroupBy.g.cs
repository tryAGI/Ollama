
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public enum UsageGroupBy
    {
        /// <summary>
        /// model.
        /// </summary>
        Model,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class UsageGroupByExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageGroupBy value)
        {
            return value switch
            {
                UsageGroupBy.Model => "model",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageGroupBy? ToEnum(string value)
        {
            return value switch
            {
                "model" => UsageGroupBy.Model,
                _ => null,
            };
        }
    }
}