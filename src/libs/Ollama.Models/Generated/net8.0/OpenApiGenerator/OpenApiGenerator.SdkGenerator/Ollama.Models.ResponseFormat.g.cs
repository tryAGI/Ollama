
#nullable enable

namespace Ollama
{
    /// <summary>
    /// The format to return a response in. Currently the only accepted value is json.<br/>
    /// Enable JSON mode by setting the format parameter to json. This will structure the response as valid JSON.<br/>
    /// Note: it's important to instruct the model to use JSON in the prompt. Otherwise, the model may generate large amounts whitespace.
    /// </summary>
    public enum ResponseFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ResponseFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ResponseFormat value)
        {
            return value switch
            {
                ResponseFormat.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ResponseFormat? ToEnum(string value)
        {
            return value switch
            {
                "json" => ResponseFormat.Json,
                _ => null,
            };
        }
    }
}