
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public readonly partial struct OneOf<T1, T2, T3> : global::System.IEquatable<OneOf<T1, T2, T3>>
    {
        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public T1? Value1 { get; init; }
#else
        public T1? Value1 { get; }
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
        public bool TryPickValue1(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out T1? value)
        {
            value = Value1;
            return IsValue1;
        }

        /// <summary>
        ///
        /// </summary>
        public T1 PickValue1() => Value1 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'Value1' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public T2? Value2 { get; init; }
#else
        public T2? Value2 { get; }
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
        public bool TryPickValue2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out T2? value)
        {
            value = Value2;
            return IsValue2;
        }

        /// <summary>
        ///
        /// </summary>
        public T2 PickValue2() => Value2 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'Value2' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public T3? Value3 { get; init; }
#else
        public T3? Value3 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Value3))]
#endif
        public bool IsValue3 => Value3 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickValue3(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out T3? value)
        {
            value = Value3;
            return IsValue3;
        }

        /// <summary>
        ///
        /// </summary>
        public T3 PickValue3() => Value3 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'Value3' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator OneOf<T1, T2, T3>(T1 value) => new OneOf<T1, T2, T3>((T1?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator T1?(OneOf<T1, T2, T3> @this) => @this.Value1;

        /// <summary>
        ///
        /// </summary>
        public OneOf(T1? value)
        {
            Value1 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static OneOf<T1, T2, T3> FromValue1(T1? value) => new OneOf<T1, T2, T3>(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator OneOf<T1, T2, T3>(T2 value) => new OneOf<T1, T2, T3>((T2?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator T2?(OneOf<T1, T2, T3> @this) => @this.Value2;

        /// <summary>
        ///
        /// </summary>
        public OneOf(T2? value)
        {
            Value2 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static OneOf<T1, T2, T3> FromValue2(T2? value) => new OneOf<T1, T2, T3>(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator OneOf<T1, T2, T3>(T3 value) => new OneOf<T1, T2, T3>((T3?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator T3?(OneOf<T1, T2, T3> @this) => @this.Value3;

        /// <summary>
        ///
        /// </summary>
        public OneOf(T3? value)
        {
            Value3 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static OneOf<T1, T2, T3> FromValue3(T3? value) => new OneOf<T1, T2, T3>(value);

        /// <summary>
        ///
        /// </summary>
        public OneOf(
            T1? value1,
            T2? value2,
            T3? value3
            )
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            Value3 as object ??
            Value2 as object ??
            Value1 as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            Value1?.ToString() ??
            Value2?.ToString() ??
            Value3?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsValue1 && !IsValue2 && !IsValue3 || !IsValue1 && IsValue2 && !IsValue3 || !IsValue1 && !IsValue2 && IsValue3;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<T1, TResult>? value1 = null,
            global::System.Func<T2, TResult>? value2 = null,
            global::System.Func<T3, TResult>? value3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Value1 is { } __value0 && value1 != null)
            {
                return value1(__value0);
            }
            else if (Value2 is { } __value1 && value2 != null)
            {
                return value2(__value1);
            }
            else if (Value3 is { } __value2 && value3 != null)
            {
                return value3(__value2);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<T1>? value1 = null,

            global::System.Action<T2>? value2 = null,

            global::System.Action<T3>? value3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Value1 is { } __value0)
            {
                value1?.Invoke(__value0);
            }
            else if (Value2 is { } __value1)
            {
                value2?.Invoke(__value1);
            }
            else if (Value3 is { } __value2)
            {
                value3?.Invoke(__value2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<T1>? value1 = null,
            global::System.Action<T2>? value2 = null,
            global::System.Action<T3>? value3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Value1 is { } __value0)
            {
                value1?.Invoke(__value0);
            }
            else if (Value2 is { } __value1)
            {
                value2?.Invoke(__value1);
            }
            else if (Value3 is { } __value2)
            {
                value3?.Invoke(__value2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override int GetHashCode()
        {
            var fields = new object?[]
            {
                Value1,
                typeof(T1),
                Value2,
                typeof(T2),
                Value3,
                typeof(T3),
            };
            const int offset = unchecked((int)2166136261);
            const int prime = 16777619;
            static int HashCodeAggregator(int hashCode, object? value) => value == null
                ? (hashCode ^ 0) * prime
                : (hashCode ^ value.GetHashCode()) * prime;

            return global::System.Linq.Enumerable.Aggregate(fields, offset, HashCodeAggregator);
        }

        /// <summary>
        ///
        /// </summary>
        public bool Equals(OneOf<T1, T2, T3> other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<T1?>.Default.Equals(Value1, other.Value1) &&
                global::System.Collections.Generic.EqualityComparer<T2?>.Default.Equals(Value2, other.Value2) &&
                global::System.Collections.Generic.EqualityComparer<T3?>.Default.Equals(Value3, other.Value3)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(OneOf<T1, T2, T3> obj1, OneOf<T1, T2, T3> obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<OneOf<T1, T2, T3>>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(OneOf<T1, T2, T3> obj1, OneOf<T1, T2, T3> obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is OneOf<T1, T2, T3> o && Equals(o);
        }
    }
}
