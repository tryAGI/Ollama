using System.Linq;
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// Status pulling the model.<br/>
    /// Example: pulling manifest
    /// </summary>
    public readonly struct PullModelStatus : global::System.IEquatable<PullModelStatus>
    {
        /// <summary>
        /// 
        /// </summary>
#if NET6_0_OR_GREATER
        public string? Value1 { get; init; }
#else
        public string? Value1 { get; }
#endif

        /// <summary>
        /// 
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Value1))]
#endif
        public bool IsValue1 => Value1 != null;

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PullModelStatus(string value) => new PullModelStatus(value);

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator string?(PullModelStatus @this) => @this.Value1;

        /// <summary>
        /// 
        /// </summary>
        public PullModelStatus(string? value)
        {
            Value1 = value;
        }

        /// <summary>
        /// 
        /// </summary>
#if NET6_0_OR_GREATER
        public global::Ollama.PullModelStatusVariant2? Value2 { get; init; }
#else
        public global::Ollama.PullModelStatusVariant2? Value2 { get; }
#endif

        /// <summary>
        /// 
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Value2))]
#endif
        public bool IsValue2 => Value2 != null;

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PullModelStatus(global::Ollama.PullModelStatusVariant2 value) => new PullModelStatus(value);

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator global::Ollama.PullModelStatusVariant2?(PullModelStatus @this) => @this.Value2;

        /// <summary>
        /// 
        /// </summary>
        public PullModelStatus(global::Ollama.PullModelStatusVariant2? value)
        {
            Value2 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public PullModelStatus(
            string? value1,
            global::Ollama.PullModelStatusVariant2? value2
            )
        {
            Value1 = value1;
            Value2 = value2;
        }

        /// <summary>
        /// 
        /// </summary>
        public object? Object =>
            Value2 as object ??
            Value1 as object 
            ;

        /// <summary>
        /// 
        /// </summary>
        public bool Validate()
        {
            return IsValue1 || IsValue2;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            var fields = new object?[]
            {
                Value1,
                typeof(string),
                Value2,
                typeof(global::Ollama.PullModelStatusVariant2),
            };
            const int offset = unchecked((int)2166136261);
            const int prime = 16777619;
            static int HashCodeAggregator(int hashCode, object? value) => value == null
                ? (hashCode ^ 0) * prime
                : (hashCode ^ value.GetHashCode()) * prime;
            return fields.Aggregate(offset, HashCodeAggregator);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(PullModelStatus other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(Value1, other.Value1) &&
                global::System.Collections.Generic.EqualityComparer<global::Ollama.PullModelStatusVariant2?>.Default.Equals(Value2, other.Value2) 
                ;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(PullModelStatus obj1, PullModelStatus obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<PullModelStatus>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(PullModelStatus obj1, PullModelStatus obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is PullModelStatus o && Equals(o);
        }
    }
}
