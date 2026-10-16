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
        public global::Ollama.UsageSummary? Summary { get; init; }
#else
        public global::Ollama.UsageSummary? Summary { get; }
#endif

        /// <summary>
        ///
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Summary))]
#endif
        public bool IsSummary => Summary != null;

        /// <summary>
        ///
        /// </summary>
        public bool TryPickSummary(
#if NET6_0_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
            out global::Ollama.UsageSummary? value)
        {
            value = Summary;
            return IsSummary;
        }

        /// <summary>
        ///
        /// </summary>
        public global::Ollama.UsageSummary PickSummary() => Summary is { } value
            ? value
            : throw new global::System.InvalidOperationException($"Expected union variant 'Summary' but the value was {ToString()}.");

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
        public static implicit operator UsageBucket(global::Ollama.UsageSummary value) => new UsageBucket((global::Ollama.UsageSummary?)value);

        /// <summary>
        ///
        /// </summary>
        public static implicit operator global::Ollama.UsageSummary?(UsageBucket @this) => @this.Summary;

        /// <summary>
        ///
        /// </summary>
        public UsageBucket(global::Ollama.UsageSummary? value)
        {
            Summary = value;
        }

        /// <summary>
        ///
        /// </summary>
        public static UsageBucket FromSummary(global::Ollama.UsageSummary? value) => new UsageBucket(value);

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
            global::Ollama.UsageSummary? summary,
            global::Ollama.UsageBucketVariant2? usageBucketVariant2
            )
        {
            Summary = summary;
            UsageBucketVariant2 = usageBucketVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public object? Object =>
            UsageBucketVariant2 as object ??
            Summary as object
            ;

        /// <summary>
        ///
        /// </summary>
        public override string? ToString() =>
            Summary?.ToString() ??
            UsageBucketVariant2?.ToString()
            ;

        /// <summary>
        ///
        /// </summary>
        public bool Validate()
        {
            return IsSummary && IsUsageBucketVariant2;
        }

        /// <summary>
        ///
        /// </summary>
        public TResult? Match<TResult>(
            global::System.Func<global::Ollama.UsageSummary?, TResult>? summary = null,
            global::System.Func<global::Ollama.UsageBucketVariant2, TResult>? usageBucketVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Summary is { } __value0 && summary != null)
            {
                return summary(__value0);
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
            global::System.Action<global::Ollama.UsageSummary?>? summary = null,

            global::System.Action<global::Ollama.UsageBucketVariant2>? usageBucketVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Summary is { } __value0)
            {
                summary?.Invoke(__value0);
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
            global::System.Action<global::Ollama.UsageSummary?>? summary = null,
            global::System.Action<global::Ollama.UsageBucketVariant2>? usageBucketVariant2 = null,
            bool validate = true)
        {
            if (validate)
            {
                Validate();
            }

            if (Summary is { } __value0)
            {
                summary?.Invoke(__value0);
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
                Summary,
                typeof(global::Ollama.UsageSummary),
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
                global::System.Collections.Generic.EqualityComparer<global::Ollama.UsageSummary?>.Default.Equals(Summary, other.Summary) &&
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
