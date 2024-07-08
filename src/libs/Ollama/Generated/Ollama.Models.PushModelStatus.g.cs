using System.Linq;
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// Status pushing the model.
    /// </summary>
    public readonly struct PushModelStatus : global::System.IEquatable<PushModelStatus>
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
        public static implicit operator PushModelStatus(string value) => new PushModelStatus(value);

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator string?(PushModelStatus @this) => @this.Value1;

        /// <summary>
        /// 
        /// </summary>
        public PushModelStatus(string? value)
        {
            Value1 = value;
        }

        /// <summary>
        /// 
        /// </summary>
#if NET6_0_OR_GREATER
        public global::Ollama.PushModelStatusVariant2? Value2 { get; init; }
#else
        public global::Ollama.PushModelStatusVariant2? Value2 { get; }
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
        public static implicit operator PushModelStatus(global::Ollama.PushModelStatusVariant2 value) => new PushModelStatus(value);

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator global::Ollama.PushModelStatusVariant2?(PushModelStatus @this) => @this.Value2;

        /// <summary>
        /// 
        /// </summary>
        public PushModelStatus(global::Ollama.PushModelStatusVariant2? value)
        {
            Value2 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public PushModelStatus(
            string? value1,
            global::Ollama.PushModelStatusVariant2? value2
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
                typeof(global::Ollama.PushModelStatusVariant2),
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
        public bool Equals(PushModelStatus other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(Value1, other.Value1) &&
                global::System.Collections.Generic.EqualityComparer<global::Ollama.PushModelStatusVariant2?>.Default.Equals(Value2, other.Value2) 
                ;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(PushModelStatus obj1, PushModelStatus obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<PushModelStatus>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(PushModelStatus obj1, PushModelStatus obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is PushModelStatus o && Equals(o);
        }
    }
}
