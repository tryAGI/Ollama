#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// Controls a model's thinking output. Use `/api/show` to discover the supported values and default for the selected model. `true` requests thinking, `false` requests no thinking output, and `null` uses the model default. String values are model-defined; supported names must match `/api/show` exactly. Numbers are not supported.
    /// </summary>
    public readonly partial struct ThinkValue : global::System.IEquatable<ThinkValue>
    {
        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public bool? ThinkValueVariant1 { get; init; }
#else
        public bool? ThinkValueVariant1 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(ThinkValueVariant1))]
#endif
        public bool IsThinkValueVariant1 => ThinkValueVariant1 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickThinkValueVariant1(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out bool? value)
        {
            value = ThinkValueVariant1;
            return IsThinkValueVariant1;
        }

        /// <summary>
        ///
        /// </summary>
        public bool PickThinkValueVariant1() => IsThinkValueVariant1
            ? ThinkValueVariant1!.Value
            : throw new global::System.InvalidOperationException($"Expected union variant 'ThinkValueVariant1' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public string? ThinkValueVariant2 { get; init; }
#else
        public string? ThinkValueVariant2 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(ThinkValueVariant2))]
#endif
        public bool IsThinkValueVariant2 => ThinkValueVariant2 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickThinkValueVariant2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out string? value)
        {
            value = ThinkValueVariant2;
            return IsThinkValueVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public string PickThinkValueVariant2() => IsThinkValueVariant2
            ? ThinkValueVariant2!
            : throw new global::System.InvalidOperationException($"Expected union variant 'ThinkValueVariant2' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public object? ThinkValueVariant3 { get; init; }
#else
        public object? ThinkValueVariant3 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(ThinkValueVariant3))]
#endif
        public bool IsThinkValueVariant3 => ThinkValueVariant3 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickThinkValueVariant3(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out object? value)
        {
            value = ThinkValueVariant3;
            return IsThinkValueVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public object PickThinkValueVariant3() => IsThinkValueVariant3
            ? ThinkValueVariant3!
            : throw new global::System.InvalidOperationException($"Expected union variant 'ThinkValueVariant3' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator ThinkValue(bool value) => new ThinkValue((bool?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator bool?(ThinkValue @this) => @this.ThinkValueVariant1;

        /// <summary>
        ///
        /// </summary>
        public ThinkValue(bool? value)
        {
            ThinkValueVariant1 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static ThinkValue FromThinkValueVariant1(bool? value) => new ThinkValue(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator ThinkValue(string value) => new ThinkValue((string?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator string?(ThinkValue @this) => @this.ThinkValueVariant2;

        /// <summary>
        ///
        /// </summary>
        public ThinkValue(string? value)
        {
            ThinkValueVariant2 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static ThinkValue FromThinkValueVariant2(string? value) => new ThinkValue(value);

        /// <summary>
        ///
        /// </summary>
        public ThinkValue(
            bool? thinkValueVariant1,
            string? thinkValueVariant2,
            object? thinkValueVariant3
            )
        {
            ThinkValueVariant1 = thinkValueVariant1;
            ThinkValueVariant2 = thinkValueVariant2;
            ThinkValueVariant3 = thinkValueVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            ThinkValueVariant3 as object ??
            ThinkValueVariant2 as object ??
            ThinkValueVariant1 as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            ThinkValueVariant1?.ToString().ToLowerInvariant() ??
            ThinkValueVariant2?.ToString() ??
            ThinkValueVariant3?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsThinkValueVariant1 && !IsThinkValueVariant2 && !IsThinkValueVariant3 || !IsThinkValueVariant1 && IsThinkValueVariant2 && !IsThinkValueVariant3 || !IsThinkValueVariant1 && !IsThinkValueVariant2 && IsThinkValueVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<bool?, TResult>? thinkValueVariant1 = null,
            global::System.Func<string, TResult>? thinkValueVariant2 = null,
            global::System.Func<object, TResult>? thinkValueVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (IsThinkValueVariant1 && thinkValueVariant1 != null)
            {
                return thinkValueVariant1(ThinkValueVariant1!);
            }
            else if (IsThinkValueVariant2 && thinkValueVariant2 != null)
            {
                return thinkValueVariant2(ThinkValueVariant2!);
            }
            else if (IsThinkValueVariant3 && thinkValueVariant3 != null)
            {
                return thinkValueVariant3(ThinkValueVariant3!);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<bool?>? thinkValueVariant1 = null,

            global::System.Action<string>? thinkValueVariant2 = null,

            global::System.Action<object>? thinkValueVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (IsThinkValueVariant1)
            {
                thinkValueVariant1?.Invoke(ThinkValueVariant1!);
            }
            else if (IsThinkValueVariant2)
            {
                thinkValueVariant2?.Invoke(ThinkValueVariant2!);
            }
            else if (IsThinkValueVariant3)
            {
                thinkValueVariant3?.Invoke(ThinkValueVariant3!);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<bool?>? thinkValueVariant1 = null,
            global::System.Action<string>? thinkValueVariant2 = null,
            global::System.Action<object>? thinkValueVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (IsThinkValueVariant1)
            {
                thinkValueVariant1?.Invoke(ThinkValueVariant1!);
            }
            else if (IsThinkValueVariant2)
            {
                thinkValueVariant2?.Invoke(ThinkValueVariant2!);
            }
            else if (IsThinkValueVariant3)
            {
                thinkValueVariant3?.Invoke(ThinkValueVariant3!);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override int GetHashCode()
        {
            var fields = new object?[]
            {
                ThinkValueVariant1,
                typeof(bool),
                ThinkValueVariant2,
                typeof(string),
                ThinkValueVariant3,
                typeof(object),
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
        public bool Equals(ThinkValue other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<bool?>.Default.Equals(ThinkValueVariant1, other.ThinkValueVariant1) &&
                global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(ThinkValueVariant2, other.ThinkValueVariant2) &&
                global::System.Collections.Generic.EqualityComparer<object?>.Default.Equals(ThinkValueVariant3, other.ThinkValueVariant3)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(ThinkValue obj1, ThinkValue obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<ThinkValue>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(ThinkValue obj1, ThinkValue obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is ThinkValue o && Equals(o);
        }
    }
}
