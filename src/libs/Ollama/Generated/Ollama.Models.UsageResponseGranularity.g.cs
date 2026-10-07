
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Set automatically: hour for 24h, day for 7d and 30d.
    /// </summary>
    public enum UsageResponseGranularity
    {
        /// <summary>
        /// hour for 24h, day for 7d and 30d.
        /// </summary>
        Day,
        /// <summary>
        /// hour for 24h, day for 7d and 30d.
        /// </summary>
        Hour,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class UsageResponseGranularityExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageResponseGranularity value)
        {
            return value switch
            {
                UsageResponseGranularity.Day => "day",
                UsageResponseGranularity.Hour => "hour",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageResponseGranularity? ToEnum(string value)
        {
            return value switch
            {
                "day" => UsageResponseGranularity.Day,
                "hour" => UsageResponseGranularity.Hour,
                _ => null,
            };
        }
    }
}