
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Selected grouping. Present when group_by is requested.
    /// </summary>
    public enum UsageResponseGroupBy
    {
        /// <summary>
        ///
        /// </summary>
        Model,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class UsageResponseGroupByExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageResponseGroupBy value)
        {
            return value switch
            {
                UsageResponseGroupBy.Model => "model",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageResponseGroupBy? ToEnum(string value)
        {
            return value switch
            {
                "model" => UsageResponseGroupBy.Model,
                _ => null,
            };
        }
    }
}