
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Default Value: self
    /// </summary>
    public enum UsageScope
    {
        /// <summary>
        ///
        /// </summary>
        Self,
        /// <summary>
        ///
        /// </summary>
        Team,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class UsageScopeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageScope value)
        {
            return value switch
            {
                UsageScope.Self => "self",
                UsageScope.Team => "team",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageScope? ToEnum(string value)
        {
            return value switch
            {
                "self" => UsageScope.Self,
                "team" => UsageScope.Team,
                _ => null,
            };
        }
    }
}