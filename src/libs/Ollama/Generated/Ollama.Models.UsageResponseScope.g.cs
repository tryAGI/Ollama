
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Selected usage scope.
    /// </summary>
    public enum UsageResponseScope
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
    public static class UsageResponseScopeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this UsageResponseScope value)
        {
            return value switch
            {
                UsageResponseScope.Self => "self",
                UsageResponseScope.Team => "team",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static UsageResponseScope? ToEnum(string value)
        {
            return value switch
            {
                "self" => UsageResponseScope.Self,
                "team" => UsageResponseScope.Team,
                _ => null,
            };
        }
    }
}