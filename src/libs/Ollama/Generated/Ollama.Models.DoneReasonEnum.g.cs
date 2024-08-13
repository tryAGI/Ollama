
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum DoneReasonEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Stop,
        /// <summary>
        /// 
        /// </summary>
        Length,
        /// <summary>
        /// 
        /// </summary>
        Load,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class DoneReasonEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this DoneReasonEnum value)
        {
            return value switch
            {
                DoneReasonEnum.Stop => "stop",
                DoneReasonEnum.Length => "length",
                DoneReasonEnum.Load => "load",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static DoneReasonEnum? ToEnum(string value)
        {
            return value switch
            {
                "stop" => DoneReasonEnum.Stop,
                "length" => DoneReasonEnum.Length,
                "load" => DoneReasonEnum.Load,
                _ => null,
            };
        }
    }
}