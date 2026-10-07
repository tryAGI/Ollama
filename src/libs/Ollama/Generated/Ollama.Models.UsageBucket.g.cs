#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public readonly partial struct UsageBucket : global::System.IEquatable<UsageBucket>
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
        public global::Ollama.UsageBucketVariant2? UsageBucketVariant2 { get; init; }
#else
        public global::Ollama.UsageBucketVariant2? UsageBucketVariant2 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(UsageBucketVariant2))]
#endif
        public bool IsUsageBucketVariant2 => UsageBucketVariant2 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickUsageBucketVariant2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::Ollama.UsageBucketVariant2? value)
        {
            value = UsageBucketVariant2;
            return IsUsageBucketVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public global::Ollama.UsageBucketVariant2 PickUsageBucketVariant2() => UsageBucketVariant2 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'UsageBucketVariant2' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageBucket(global::Ollama.UsageMetrics value) => new UsageBucket((global::Ollama.UsageMetrics?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageMetrics?(UsageBucket @this) => @this.Metrics;

        /// <summary>
        ///
        /// </summary>
        public UsageBucket(global::Ollama.UsageMetrics? value)
        {
            Metrics = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageBucket FromMetrics(global::Ollama.UsageMetrics? value) => new UsageBucket(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageBucket(global::Ollama.UsageBucketVariant2 value) => new UsageBucket((global::Ollama.UsageBucketVariant2?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageBucketVariant2?(UsageBucket @this) => @this.UsageBucketVariant2;

        /// <summary>
        ///
        /// </summary>
        public UsageBucket(global::Ollama.UsageBucketVariant2? value)
        {
            UsageBucketVariant2 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageBucket FromUsageBucketVariant2(global::Ollama.UsageBucketVariant2? value) => new UsageBucket(value);

        /// <summary>
        ///
        /// </summary>
        public UsageBucket(
            global::Ollama.UsageMetrics? metrics,
            global::Ollama.UsageBucketVariant2? usageBucketVariant2
            )
        {
            Metrics = metrics;
            UsageBucketVariant2 = usageBucketVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            UsageBucketVariant2 as object ??
            Metrics as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            Metrics?.ToString() ??
            UsageBucketVariant2?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsMetrics && IsUsageBucketVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<global::Ollama.UsageMetrics, TResult>? metrics = null,
            global::System.Func<global::Ollama.UsageBucketVariant2, TResult>? usageBucketVariant2 = null,
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
            else if (UsageBucketVariant2 is { } __value1 && usageBucketVariant2 != null)
            {
                return usageBucketVariant2(__value1);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,

            global::System.Action<global::Ollama.UsageBucketVariant2>? usageBucketVariant2 = null,
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
            else if (UsageBucketVariant2 is { } __value1)
            {
                usageBucketVariant2?.Invoke(__value1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,
            global::System.Action<global::Ollama.UsageBucketVariant2>? usageBucketVariant2 = null,
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
            else if (UsageBucketVariant2 is { } __value1)
            {
                usageBucketVariant2?.Invoke(__value1);
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
                UsageBucketVariant2,
                typeof(global::Ollama.UsageBucketVariant2),
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
        public bool Equals(UsageBucket other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageMetrics?>.Default.Equals(Metrics, other.Metrics) &&
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageBucketVariant2?>.Default.Equals(UsageBucketVariant2, other.UsageBucketVariant2)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(UsageBucket obj1, UsageBucket obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<UsageBucket>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(UsageBucket obj1, UsageBucket obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is UsageBucket o && Equals(o);
        }
    }
}
