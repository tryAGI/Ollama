
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Capability of a model.
    /// </summary>
    public enum Capability
    {
        /// <summary>
        /// 
        /// </summary>
        Completion,
        /// <summary>
        /// 
        /// </summary>
        Tools,
        /// <summary>
        /// 
        /// </summary>
        Insert,
        /// <summary>
        /// 
        /// </summary>
        Vision,
        /// <summary>
        /// 
        /// </summary>
        Embedding,
        /// <summary>
        /// 
        /// </summary>
        Thinking,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CapabilityExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this Capability value)
        {
            return value switch
            {
                Capability.Completion => "completion",
                Capability.Tools => "tools",
                Capability.Insert => "insert",
                Capability.Vision => "vision",
                Capability.Embedding => "embedding",
                Capability.Thinking => "thinking",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static Capability? ToEnum(string value)
        {
            return value switch
            {
                "completion" => Capability.Completion,
                "tools" => Capability.Tools,
                "insert" => Capability.Insert,
                "vision" => Capability.Vision,
                "embedding" => Capability.Embedding,
                "thinking" => Capability.Thinking,
                _ => null,
            };
        }
    }
}