
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum DoneReasonVariant2
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
    public static class DoneReasonVariant2Extensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this DoneReasonVariant2 value)
        {
            return value switch
            {
                DoneReasonVariant2.Stop => "stop",
                DoneReasonVariant2.Length => "length",
                DoneReasonVariant2.Load => "load",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static DoneReasonVariant2? ToEnum(string value)
        {
            return value switch
            {
                "stop" => DoneReasonVariant2.Stop,
                "length" => DoneReasonVariant2.Length,
                "load" => DoneReasonVariant2.Load,
                _ => null,
            };
        }
    }
}