
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum GenerateChatCompletionResponseDoneReason
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
    public static class GenerateChatCompletionResponseDoneReasonExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GenerateChatCompletionResponseDoneReason value)
        {
            return value switch
            {
                GenerateChatCompletionResponseDoneReason.Stop => "stop",
                GenerateChatCompletionResponseDoneReason.Length => "length",
                GenerateChatCompletionResponseDoneReason.Load => "load",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GenerateChatCompletionResponseDoneReason? ToEnum(string value)
        {
            return value switch
            {
                "stop" => GenerateChatCompletionResponseDoneReason.Stop,
                "length" => GenerateChatCompletionResponseDoneReason.Length,
                "load" => GenerateChatCompletionResponseDoneReason.Load,
                _ => null,
            };
        }
    }
}