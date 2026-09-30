#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    /// A nonempty string, or an object or array serialized as JSON text. Not interpreted as chat messages or multimodal input.
    /// </summary>
    public readonly partial struct SystemOneContent : global::System.IEquatable<SystemOneContent>
    {
        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public string? SystemOneContentVariant1 { get; init; }
#else
        public string? SystemOneContentVariant1 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(SystemOneContentVariant1))]
#endif
        public bool IsSystemOneContentVariant1 => SystemOneContentVariant1 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickSystemOneContentVariant1(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out string? value)
        {
            value = SystemOneContentVariant1;
            return IsSystemOneContentVariant1;
        }

        /// <summary>
        ///
        /// </summary>
        public string PickSystemOneContentVariant1() => SystemOneContentVariant1 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'SystemOneContentVariant1' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public object? SystemOneContentVariant2 { get; init; }
#else
        public object? SystemOneContentVariant2 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(SystemOneContentVariant2))]
#endif
        public bool IsSystemOneContentVariant2 => SystemOneContentVariant2 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickSystemOneContentVariant2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out object? value)
        {
            value = SystemOneContentVariant2;
            return IsSystemOneContentVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public object PickSystemOneContentVariant2() => SystemOneContentVariant2 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'SystemOneContentVariant2' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public global::System.Collections.Generic.IList<object>? SystemOneContentVariant3 { get; init; }
#else
        public global::System.Collections.Generic.IList<object>? SystemOneContentVariant3 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(SystemOneContentVariant3))]
#endif
        public bool IsSystemOneContentVariant3 => SystemOneContentVariant3 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickSystemOneContentVariant3(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::System.Collections.Generic.IList<object>? value)
        {
            value = SystemOneContentVariant3;
            return IsSystemOneContentVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<object> PickSystemOneContentVariant3() => SystemOneContentVariant3 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'SystemOneContentVariant3' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator SystemOneContent(string value) => new SystemOneContent((string?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator string?(SystemOneContent @this) => @this.SystemOneContentVariant1;

        /// <summary>
        ///
        /// </summary>
        public SystemOneContent(string? value)
        {
            SystemOneContentVariant1 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static SystemOneContent FromSystemOneContentVariant1(string? value) => new SystemOneContent(value);

        /// <summary>
        ///
        /// </summary>
        public SystemOneContent(
            string? systemOneContentVariant1,
            object? systemOneContentVariant2,
            global::System.Collections.Generic.IList<object>? systemOneContentVariant3
            )
        {
            SystemOneContentVariant1 = systemOneContentVariant1;
            SystemOneContentVariant2 = systemOneContentVariant2;
            SystemOneContentVariant3 = systemOneContentVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            SystemOneContentVariant3 as object ??
            SystemOneContentVariant2 as object ??
            SystemOneContentVariant1 as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            SystemOneContentVariant1?.ToString() ??
            SystemOneContentVariant2?.ToString() ??
            SystemOneContentVariant3?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsSystemOneContentVariant1 && !IsSystemOneContentVariant2 && !IsSystemOneContentVariant3 || !IsSystemOneContentVariant1 && IsSystemOneContentVariant2 && !IsSystemOneContentVariant3 || !IsSystemOneContentVariant1 && !IsSystemOneContentVariant2 && IsSystemOneContentVariant3;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<string, TResult>? systemOneContentVariant1 = null,
            global::System.Func<object, TResult>? systemOneContentVariant2 = null,
            global::System.Func<global::System.Collections.Generic.IList<object>, TResult>? systemOneContentVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (SystemOneContentVariant1 is { } __value0 && systemOneContentVariant1 != null)
            {
                return systemOneContentVariant1(__value0);
            }
            else if (SystemOneContentVariant2 is { } __value1 && systemOneContentVariant2 != null)
            {
                return systemOneContentVariant2(__value1);
            }
            else if (SystemOneContentVariant3 is { } __value2 && systemOneContentVariant3 != null)
            {
                return systemOneContentVariant3(__value2);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<string>? systemOneContentVariant1 = null,

            global::System.Action<object>? systemOneContentVariant2 = null,

            global::System.Action<global::System.Collections.Generic.IList<object>>? systemOneContentVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (SystemOneContentVariant1 is { } __value0)
            {
                systemOneContentVariant1?.Invoke(__value0);
            }
            else if (SystemOneContentVariant2 is { } __value1)
            {
                systemOneContentVariant2?.Invoke(__value1);
            }
            else if (SystemOneContentVariant3 is { } __value2)
            {
                systemOneContentVariant3?.Invoke(__value2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<string>? systemOneContentVariant1 = null,
            global::System.Action<object>? systemOneContentVariant2 = null,
            global::System.Action<global::System.Collections.Generic.IList<object>>? systemOneContentVariant3 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (SystemOneContentVariant1 is { } __value0)
            {
                systemOneContentVariant1?.Invoke(__value0);
            }
            else if (SystemOneContentVariant2 is { } __value1)
            {
                systemOneContentVariant2?.Invoke(__value1);
            }
            else if (SystemOneContentVariant3 is { } __value2)
            {
                systemOneContentVariant3?.Invoke(__value2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override int GetHashCode()
        {
            var fields = new object?[]
            {
                SystemOneContentVariant1,
                typeof(string),
                SystemOneContentVariant2,
                typeof(object),
                SystemOneContentVariant3,
                typeof(global::System.Collections.Generic.IList<object>),
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
        public bool Equals(SystemOneContent other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(SystemOneContentVariant1, other.SystemOneContentVariant1) &&
                global::System.Collections.Generic.EqualityComparer<object?>.Default.Equals(SystemOneContentVariant2, other.SystemOneContentVariant2) &&
                global::System.Collections.Generic.EqualityComparer<global::System.Collections.Generic.IList<object>?>.Default.Equals(SystemOneContentVariant3, other.SystemOneContentVariant3)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(SystemOneContent obj1, SystemOneContent obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<SystemOneContent>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(SystemOneContent obj1, SystemOneContent obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is SystemOneContent o && Equals(o);
        }
    }
}
