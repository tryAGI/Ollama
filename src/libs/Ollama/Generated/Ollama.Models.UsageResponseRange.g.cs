
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Selected time range.
    /// </summary>
    public enum UsageResponseRange
    {
        /// <summary>
        ///
        /// </summary>
        x24h,
        /// <summary>
        ///
        /// </summary>
        x30d,
        /// <summary>
        ///
        /// </summary>
        x7d,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class UsageResponseRangeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageResponseRange value)
        {
            return value switch
            {
                UsageResponseRange.x24h => "24h",
                UsageResponseRange.x30d => "30d",
                UsageResponseRange.x7d => "7d",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageResponseRange? ToEnum(string value)
        {
            return value switch
            {
                "24h" => UsageResponseRange.x24h,
                "30d" => UsageResponseRange.x30d,
                "7d" => UsageResponseRange.x7d,
                _ => null,
            };
        }
    }
}