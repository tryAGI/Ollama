
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Type of tool (always `function`)
    /// </summary>
    public enum ToolDefinitionType
    {
        /// <summary>
        /// 
        /// </summary>
        Function,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ToolDefinitionTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ToolDefinitionType value)
        {
            return value switch
            {
                ToolDefinitionType.Function => "function",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ToolDefinitionType? ToEnum(string value)
        {
            return value switch
            {
                "function" => ToolDefinitionType.Function,
                _ => null,
            };
        }
    }
}