
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Default Value: 7d
    /// </summary>
    public enum UsageRange
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
    public static class UsageRangeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageRange value)
        {
            return value switch
            {
                UsageRange.x24h => "24h",
                UsageRange.x30d => "30d",
                UsageRange.x7d => "7d",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageRange? ToEnum(string value)
        {
            return value switch
            {
                "24h" => UsageRange.x24h,
                "30d" => UsageRange.x30d,
                "7d" => UsageRange.x7d,
                _ => null,
            };
        }
    }
}