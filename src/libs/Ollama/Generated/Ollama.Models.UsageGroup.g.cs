#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public readonly partial struct UsageGroup : global::System.IEquatable<UsageGroup>
    {
        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public global::Ollama.UsageMetrics? Metrics { get; init; }
#else
        public global::Ollama.UsageMetrics? Metrics { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Metrics))]
#endif
        public bool IsMetrics => Metrics != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickMetrics(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::Ollama.UsageMetrics? value)
        {
            value = Metrics;
            return IsMetrics;
        }

        /// <summary>
        ///
        /// </summary>
        public global::Ollama.UsageMetrics PickMetrics() => Metrics is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'Metrics' but the value was {ToString()}.");

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        public global::Ollama.UsageGroupVariant2? UsageGroupVariant2 { get; init; }
#else
        public global::Ollama.UsageGroupVariant2? UsageGroupVariant2 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(UsageGroupVariant2))]
#endif
        public bool IsUsageGroupVariant2 => UsageGroupVariant2 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickUsageGroupVariant2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::Ollama.UsageGroupVariant2? value)
        {
            value = UsageGroupVariant2;
            return IsUsageGroupVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public global::Ollama.UsageGroupVariant2 PickUsageGroupVariant2() => UsageGroupVariant2 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'UsageGroupVariant2' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageGroup(global::Ollama.UsageMetrics value) => new UsageGroup((global::Ollama.UsageMetrics?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageMetrics?(UsageGroup @this) => @this.Metrics;

        /// <summary>
        ///
        /// </summary>
        public UsageGroup(global::Ollama.UsageMetrics? value)
        {
            Metrics = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageGroup FromMetrics(global::Ollama.UsageMetrics? value) => new UsageGroup(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageGroup(global::Ollama.UsageGroupVariant2 value) => new UsageGroup((global::Ollama.UsageGroupVariant2?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageGroupVariant2?(UsageGroup @this) => @this.UsageGroupVariant2;

        /// <summary>
        ///
        /// </summary>
        public UsageGroup(global::Ollama.UsageGroupVariant2? value)
        {
            UsageGroupVariant2 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageGroup FromUsageGroupVariant2(global::Ollama.UsageGroupVariant2? value) => new UsageGroup(value);

        /// <summary>
        ///
        /// </summary>
        public UsageGroup(
            global::Ollama.UsageMetrics? metrics,
            global::Ollama.UsageGroupVariant2? usageGroupVariant2
            )
        {
            Metrics = metrics;
            UsageGroupVariant2 = usageGroupVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            UsageGroupVariant2 as object ??
            Metrics as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            Metrics?.ToString() ??
            UsageGroupVariant2?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsMetrics && IsUsageGroupVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<global::Ollama.UsageMetrics, TResult>? metrics = null,
            global::System.Func<global::Ollama.UsageGroupVariant2, TResult>? usageGroupVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Metrics is { } __value0 && metrics != null)
            {
                return metrics(__value0);
            }
            else if (UsageGroupVariant2 is { } __value1 && usageGroupVariant2 != null)
            {
                return usageGroupVariant2(__value1);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,

            global::System.Action<global::Ollama.UsageGroupVariant2>? usageGroupVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Metrics is { } __value0)
            {
                metrics?.Invoke(__value0);
            }
            else if (UsageGroupVariant2 is { } __value1)
            {
                usageGroupVariant2?.Invoke(__value1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,
            global::System.Action<global::Ollama.UsageGroupVariant2>? usageGroupVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Metrics is { } __value0)
            {
                metrics?.Invoke(__value0);
            }
            else if (UsageGroupVariant2 is { } __value1)
            {
                usageGroupVariant2?.Invoke(__value1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override int GetHashCode()
        {
            var fields = new object?[]
            {
                Metrics,
                typeof(global::Ollama.UsageMetrics),
                UsageGroupVariant2,
                typeof(global::Ollama.UsageGroupVariant2),
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
        public bool Equals(UsageGroup other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageMetrics?>.Default.Equals(Metrics, other.Metrics) &&
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageGroupVariant2?>.Default.Equals(UsageGroupVariant2, other.UsageGroupVariant2)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(UsageGroup obj1, UsageGroup obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<UsageGroup>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(UsageGroup obj1, UsageGroup obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is UsageGroup o && Equals(o);
        }
    }
}
