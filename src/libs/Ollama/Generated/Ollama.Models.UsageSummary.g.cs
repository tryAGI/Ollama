#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    public readonly partial struct UsageSummary : global::System.IEquatable<UsageSummary>
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
        public global::Ollama.UsageSummaryVariant2? UsageSummaryVariant2 { get; init; }
#else
        public global::Ollama.UsageSummaryVariant2? UsageSummaryVariant2 { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(UsageSummaryVariant2))]
#endif
        public bool IsUsageSummaryVariant2 => UsageSummaryVariant2 != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickUsageSummaryVariant2(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::Ollama.UsageSummaryVariant2? value)
        {
            value = UsageSummaryVariant2;
            return IsUsageSummaryVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public global::Ollama.UsageSummaryVariant2 PickUsageSummaryVariant2() => UsageSummaryVariant2 is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'UsageSummaryVariant2' but the value was {ToString()}.");
        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageSummary(global::Ollama.UsageMetrics value) => new UsageSummary((global::Ollama.UsageMetrics?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageMetrics?(UsageSummary @this) => @this.Metrics;

        /// <summary>
        ///
        /// </summary>
        public UsageSummary(global::Ollama.UsageMetrics? value)
        {
            Metrics = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageSummary FromMetrics(global::Ollama.UsageMetrics? value) => new UsageSummary(value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator UsageSummary(global::Ollama.UsageSummaryVariant2 value) => new UsageSummary((global::Ollama.UsageSummaryVariant2?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageSummaryVariant2?(UsageSummary @this) => @this.UsageSummaryVariant2;

        /// <summary>
        ///
        /// </summary>
        public UsageSummary(global::Ollama.UsageSummaryVariant2? value)
        {
            UsageSummaryVariant2 = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageSummary FromUsageSummaryVariant2(global::Ollama.UsageSummaryVariant2? value) => new UsageSummary(value);

        /// <summary>
        ///
        /// </summary>
        public UsageSummary(
            global::Ollama.UsageMetrics? metrics,
            global::Ollama.UsageSummaryVariant2? usageSummaryVariant2
            )
        {
            Metrics = metrics;
            UsageSummaryVariant2 = usageSummaryVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            UsageSummaryVariant2 as object ??
            Metrics as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            Metrics?.ToString() ??
            UsageSummaryVariant2?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsMetrics && IsUsageSummaryVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<global::Ollama.UsageMetrics, TResult>? metrics = null,
            global::System.Func<global::Ollama.UsageSummaryVariant2, TResult>? usageSummaryVariant2 = null,
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
            else if (UsageSummaryVariant2 is { } __value1 && usageSummaryVariant2 != null)
            {
                return usageSummaryVariant2(__value1);
            }

            return default(TResult);
        }

        /// <summary>
        ///
        /// </summary>
        public void Match(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,

            global::System.Action<global::Ollama.UsageSummaryVariant2>? usageSummaryVariant2 = null,
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
            else if (UsageSummaryVariant2 is { } __value1)
            {
                usageSummaryVariant2?.Invoke(__value1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Switch(
            global::System.Action<global::Ollama.UsageMetrics>? metrics = null,
            global::System.Action<global::Ollama.UsageSummaryVariant2>? usageSummaryVariant2 = null,
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
            else if (UsageSummaryVariant2 is { } __value1)
            {
                usageSummaryVariant2?.Invoke(__value1);
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
                UsageSummaryVariant2,
                typeof(global::Ollama.UsageSummaryVariant2),
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
        public bool Equals(UsageSummary other)
        {
            return
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageMetrics?>.Default.Equals(Metrics, other.Metrics) &&
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageSummaryVariant2?>.Default.Equals(UsageSummaryVariant2, other.UsageSummaryVariant2)
                ;
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator ==(UsageSummary obj1, UsageSummary obj2)
        {
            return global::System.Collections.Generic.EqualityComparer<UsageSummary>.Default.Equals(obj1, obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public static bool operator !=(UsageSummary obj1, UsageSummary obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        ///
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is UsageSummary o && Equals(o);
        }
    }
}
