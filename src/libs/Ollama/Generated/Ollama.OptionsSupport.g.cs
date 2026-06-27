
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Global defaults applied to generated SDK requests.
    /// </summary>
    public sealed class AutoSDKClientOptions
    {
        /// <summary>
        /// Additional headers applied to every request after generated headers are set.
        /// Entries with the same key overwrite earlier header values.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string> Headers { get; } =
            new global::System.Collections.Generic.Dictionary<string, string>(global::System.StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Additional query parameters appended to every request.
        /// Request-level entries with the same key are appended after client defaults.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string> QueryParameters { get; } =
            new global::System.Collections.Generic.Dictionary<string, string>(global::System.StringComparer.Ordinal);

        /// <summary>
        /// Optional timeout applied to the full request execution.
        /// </summary>
        public global::System.TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Default retry behavior for generated HTTP requests.
        /// </summary>
        public global::Ollama.AutoSDKRetryOptions Retry { get; set; } = new global::Ollama.AutoSDKRetryOptions();

        /// <summary>
        /// Overrides the client-wide response buffering mode when set.
        /// </summary>
        public bool? ReadResponseAsString { get; set; }

        /// <summary>
        /// Reusable hooks invoked for every generated SDK request.
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.IAutoSDKHook> Hooks { get; } =
            new global::System.Collections.Generic.List<global::Ollama.IAutoSDKHook>();

        /// <summary>
        /// Registers a hook for all requests issued by this client.
        /// </summary>
        /// <param name="hook"></param>
        /// <returns>The current options instance.</returns>
        public global::Ollama.AutoSDKClientOptions AddHook(
            global::Ollama.IAutoSDKHook hook)
        {
            Hooks.Add(hook ?? throw new global::System.ArgumentNullException(nameof(hook)));
            return this;
        }

        /// <summary>
        /// Optional per-request authorization provider invoked before each request is sent.
        /// Set this when the client is registered as a singleton in DI but each call needs
        /// a fresh credential resolved from a provider, secret-store, or session — instead
        /// of mutating the shared <c>Authorizations</c> list at construction time.
        /// </summary>
        public global::Ollama.IAutoSDKAuthorizationProvider? AuthorizationProvider { get; set; }

        /// <summary>
        /// Convenience helper that registers <see cref="AutoSDKAuthorizationProviderHook"/>
        /// using <paramref name="provider"/> so request-level auth is resolved without
        /// touching shared client state.
        /// </summary>
        /// <param name="provider"></param>
        public global::Ollama.AutoSDKClientOptions UseAuthorizationProvider(
            global::Ollama.IAutoSDKAuthorizationProvider provider)
        {
            AuthorizationProvider = provider ?? throw new global::System.ArgumentNullException(nameof(provider));
            if (Hooks.Find(static x => x is global::Ollama.AutoSDKAuthorizationProviderHook) == null)
            {
                Hooks.Add(new global::Ollama.AutoSDKAuthorizationProviderHook());
            }

            return this;
        }
    }

    /// <summary>
    /// A request-level authorization value supplied by <see cref="IAutoSDKAuthorizationProvider"/>.
    /// Mirrors the runtime fields the SDK applies for HTTP / OAuth2 / API-key auth without
    /// requiring the consumer to construct the generated <c>EndPointAuthorization</c> type.
    /// </summary>
    public readonly struct AutoSDKAuthorizationValue
    {
        /// <summary>
        /// Initializes a new <see cref="AutoSDKAuthorizationValue"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scheme"></param>
        /// <param name="headerName"></param>
        /// <param name="location"></param>
        /// <param name="type"></param>
        public AutoSDKAuthorizationValue(
            string value,
            string scheme = "Bearer",
            string? headerName = null,
            string location = "Header",
            string type = "Http")
        {
            Value = value ?? string.Empty;
            Scheme = string.IsNullOrWhiteSpace(scheme) ? "Bearer" : scheme;
            HeaderName = headerName ?? string.Empty;
            Location = string.IsNullOrWhiteSpace(location) ? "Header" : location;
            Type = string.IsNullOrWhiteSpace(type) ? "Http" : type;
        }

        /// <summary>The credential value (token, API key, etc.).</summary>
        public string Value { get; }

        /// <summary>The HTTP authorization scheme — typically <c>Bearer</c>, <c>Basic</c>, or <c>Token</c>.</summary>
        public string Scheme { get; }

        /// <summary>The custom header name when <see cref="Type"/> is <c>ApiKey</c>; ignored for HTTP/OAuth2 auth.</summary>
        public string HeaderName { get; }

        /// <summary>The credential location — <c>Header</c>, <c>Query</c>, or <c>Cookie</c>.</summary>
        public string Location { get; }

        /// <summary>The auth type — <c>Http</c>, <c>OAuth2</c>, <c>OpenIdConnect</c>, or <c>ApiKey</c>.</summary>
        public string Type { get; }

        /// <summary>Convenience factory for a Bearer token.</summary>
        public static global::Ollama.AutoSDKAuthorizationValue Bearer(string token) => new(value: token, scheme: "Bearer");

        /// <summary>Convenience factory for an API-key header.</summary>
        public static global::Ollama.AutoSDKAuthorizationValue ApiKeyHeader(string name, string value) =>
            new(value: value, headerName: name, location: "Header", type: "ApiKey");
    }

    /// <summary>
    /// Resolves request-level authorization values without mutating the shared client
    /// authorization list. Implementations should be safe to invoke concurrently —
    /// the hook calls them once per outgoing request.
    /// </summary>
    public interface IAutoSDKAuthorizationProvider
    {
        /// <summary>
        /// Returns one or more <see cref="AutoSDKAuthorizationValue"/> values to apply to
        /// the current request, or an empty list / <c>null</c> to leave the request as-is.
        /// </summary>
        /// <param name="context"></param>
        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<global::Ollama.AutoSDKAuthorizationValue>?> ResolveAsync(
            global::Ollama.AutoSDKHookContext context);
    }

    /// <summary>
    /// Marker keys stamped onto outgoing <see cref="global::System.Net.Http.HttpRequestMessage"/>
    /// instances so consumer <see cref="global::System.Net.Http.DelegatingHandler"/>s — and any
    /// other transport-layer code that runs after AutoSDK's send pipeline — can observe whether
    /// the resolved Authorization is call-scoped and opt out of overwriting it with a
    /// rotation-aware account-level credential.
    /// </summary>
    public static class AutoSDKHttpRequestOptions
    {
        /// <summary>
        /// Key under which <see cref="StampAuthorizationOverride"/> records the marker. Exposed
        /// for handlers that target frameworks older than .NET 5 and need to read the value
        /// through the legacy <c>HttpRequestMessage.Properties</c> bag.
        /// </summary>
        public const string AuthorizationOverrideKey = "AutoSDK.AuthorizationOverride";

#if NET5_0_OR_GREATER
        /// <summary>
        /// Strongly-typed <see cref="global::System.Net.Http.HttpRequestOptionsKey{TValue}"/> for
        /// the call-scoped Authorization marker on .NET 5+ targets. Consumers should prefer this
        /// over the legacy <c>HttpRequestMessage.Properties</c> bag where available.
        /// </summary>
        public static readonly global::System.Net.Http.HttpRequestOptionsKey<bool> AuthorizationOverride =
            new global::System.Net.Http.HttpRequestOptionsKey<bool>(AuthorizationOverrideKey);
#endif

        /// <summary>
        /// Stamps the call-scoped Authorization marker on <paramref name="request"/>. AutoSDK's
        /// built-in <see cref="AutoSDKAuthorizationProviderHook"/> calls this whenever the
        /// resolved auth came from a per-request override or a client-level
        /// <see cref="IAutoSDKAuthorizationProvider"/>. Hand-written SDK extensions that set a
        /// non-default <c>Authorization</c> header (e.g. a session-scoped bearer returned by an
        /// upstream poll) should call this too so downstream rotation handlers know to skip the
        /// overwrite.
        /// </summary>
        /// <param name="request"></param>
        public static void StampAuthorizationOverride(
            global::System.Net.Http.HttpRequestMessage? request)
        {
            if (request is null)
            {
                return;
            }

#if NET5_0_OR_GREATER
            request.Options.Set(AuthorizationOverride, true);
#else
#pragma warning disable CS0618 // HttpRequestMessage.Properties is obsolete in NET5+, but the only option below it.
            request.Properties[AuthorizationOverrideKey] = true;
#pragma warning restore CS0618
#endif
        }

        /// <summary>
        /// Returns true when <see cref="StampAuthorizationOverride"/> previously marked the
        /// request as carrying a call-scoped Authorization.
        /// </summary>
        /// <param name="request"></param>
        public static bool HasAuthorizationOverride(
            global::System.Net.Http.HttpRequestMessage? request)
        {
            if (request is null)
            {
                return false;
            }

#if NET5_0_OR_GREATER
            return request.Options.TryGetValue(AuthorizationOverride, out var value) && value;
#else
#pragma warning disable CS0618
            return request.Properties.TryGetValue(AuthorizationOverrideKey, out var raw) &&
                   raw is bool flag &&
                   flag;
#pragma warning restore CS0618
#endif
        }
    }

    /// <summary>
    /// Built-in <see cref="IAutoSDKHook"/> that consults
    /// <see cref="AutoSDKClientOptions.AuthorizationProvider"/> before every outgoing
    /// request and stamps the resolved values onto the <see cref="global::System.Net.Http.HttpRequestMessage"/>.
    /// </summary>
    public sealed class AutoSDKAuthorizationProviderHook : global::Ollama.AutoSDKHook
    {
        /// <inheritdoc />
        public override async global::System.Threading.Tasks.Task OnBeforeRequestAsync(
            global::Ollama.AutoSDKHookContext context)
        {
            context = context ?? throw new global::System.ArgumentNullException(nameof(context));

            if (context.Request == null)
            {
                return;
            }

            var perRequest = context.RequestOptions?.Authorizations;
            if (perRequest != null && perRequest.Count > 0)
            {
                for (var index = 0; index < perRequest.Count; index++)
                {
                    ApplyAuthorization(context.Request, perRequest[index]);
                }

                global::Ollama.AutoSDKHttpRequestOptions.StampAuthorizationOverride(context.Request);
                return;
            }

            var provider = context.ClientOptions?.AuthorizationProvider;
            if (provider == null)
            {
                return;
            }

            var resolved = await provider.ResolveAsync(context).ConfigureAwait(false);
            if (resolved == null || resolved.Count == 0)
            {
                return;
            }

            for (var index = 0; index < resolved.Count; index++)
            {
                ApplyAuthorization(context.Request, resolved[index]);
            }

            global::Ollama.AutoSDKHttpRequestOptions.StampAuthorizationOverride(context.Request);
        }

        private static void ApplyAuthorization(
            global::System.Net.Http.HttpRequestMessage request,
            global::Ollama.AutoSDKAuthorizationValue authorization)
        {
            switch (authorization.Type)
            {
                case "Http":
                case "OAuth2":
                case "OpenIdConnect":
                    request.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: authorization.Scheme,
                        parameter: authorization.Value);
                    break;
                case "ApiKey":
                    if (string.Equals(authorization.Location, "Header", global::System.StringComparison.OrdinalIgnoreCase) &&
                        !string.IsNullOrEmpty(authorization.HeaderName))
                    {
                        request.Headers.Remove(authorization.HeaderName);
                        request.Headers.TryAddWithoutValidation(authorization.HeaderName, authorization.Value ?? string.Empty);
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Per-request overrides applied on top of <see cref="AutoSDKClientOptions"/>.
    /// </summary>
    public sealed class AutoSDKRequestOptions
    {
        /// <summary>
        /// Additional headers applied after generated and client-level headers.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string> Headers { get; } =
            new global::System.Collections.Generic.Dictionary<string, string>(global::System.StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Additional query parameters appended after generated and client-level query parameters.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string> QueryParameters { get; } =
            new global::System.Collections.Generic.Dictionary<string, string>(global::System.StringComparer.Ordinal);

        /// <summary>
        /// Optional timeout override for this request.
        /// </summary>
        public global::System.TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Optional retry override for this request.
        /// </summary>
        public global::Ollama.AutoSDKRetryOptions? Retry { get; set; }

        /// <summary>
        /// Overrides response buffering for this request when set.
        /// </summary>
        public bool? ReadResponseAsString { get; set; }

        /// <summary>
        /// Optional per-request authorization values. When non-empty, the built-in
        /// <see cref="AutoSDKAuthorizationProviderHook"/> applies these instead of consulting
        /// <see cref="AutoSDKClientOptions.AuthorizationProvider"/> for this request only.
        /// Useful for multi-tenant routing or "act-as" admin tooling that needs a different
        /// credential per call without mutating shared client state.
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Ollama.AutoSDKAuthorizationValue>? Authorizations { get; set; }
    }

    /// <summary>
    /// Retry settings for generated HTTP requests.
    /// </summary>
    public sealed class AutoSDKRetryOptions
    {
        /// <summary>
        /// Total number of attempts, including the initial request.
        /// Values less than 1 are normalized to 1.
        /// </summary>
        public int MaxAttempts { get; set; } = 1;

        /// <summary>
        /// Optional fixed delay between retry attempts. When set, this takes precedence over exponential backoff.
        /// </summary>
        public global::System.TimeSpan? Delay { get; set; }

        /// <summary>
        /// Initial exponential backoff delay used when <see cref="Delay"/> is not set.
        /// </summary>
        public global::System.TimeSpan InitialDelay { get; set; } = global::System.TimeSpan.FromSeconds(1);

        /// <summary>
        /// Maximum retry delay after applying retry headers, backoff, and jitter.
        /// </summary>
        public global::System.TimeSpan MaxDelay { get; set; } = global::System.TimeSpan.FromSeconds(30);

        /// <summary>
        /// Multiplier applied to exponential backoff after each failed attempt.
        /// Values below 1 are normalized to 1.
        /// </summary>
        public double BackoffMultiplier { get; set; } = 2D;

        /// <summary>
        /// Randomizes computed backoff by plus or minus this ratio. Values are clamped to 0..1.
        /// </summary>
        public double JitterRatio { get; set; } = 0.2D;

        /// <summary>
        /// Whether Retry-After response headers should control retry delay when present.
        /// </summary>
        public bool UseRetryAfterHeader { get; set; } = true;

        /// <summary>
        /// Whether a rate-limit reset response header should control retry delay when present.
        /// </summary>
        public bool UseRateLimitResetHeader { get; set; }

        /// <summary>
        /// Optional provider-specific rate-limit reset header name. Values may be Unix seconds or an HTTP date.
        /// </summary>
        public string? RateLimitResetHeaderName { get; set; } = "X-RateLimit-Reset";
    }


    /// <summary>
    /// Runtime hook interface for generated SDK lifecycle events.
    /// </summary>
    public interface IAutoSDKHook
    {
        /// <summary>
        /// Runs before a request is sent.
        /// </summary>
        /// <param name="context"></param>
        global::System.Threading.Tasks.Task OnBeforeRequestAsync(
            global::Ollama.AutoSDKHookContext context);

        /// <summary>
        /// Runs after a successful HTTP response is received.
        /// </summary>
        /// <param name="context"></param>
        global::System.Threading.Tasks.Task OnAfterSuccessAsync(
            global::Ollama.AutoSDKHookContext context);

        /// <summary>
        /// Runs after an error response or transport failure is observed.
        /// </summary>
        /// <param name="context"></param>
        global::System.Threading.Tasks.Task OnAfterErrorAsync(
            global::Ollama.AutoSDKHookContext context);
    }

    /// <summary>
    /// Convenience base type for request hooks with no-op defaults.
    /// </summary>
    public abstract class AutoSDKHook : global::Ollama.IAutoSDKHook
    {
        /// <inheritdoc />
        public virtual global::System.Threading.Tasks.Task OnBeforeRequestAsync(
            global::Ollama.AutoSDKHookContext context)
        {
            return global::System.Threading.Tasks.Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual global::System.Threading.Tasks.Task OnAfterSuccessAsync(
            global::Ollama.AutoSDKHookContext context)
        {
            return global::System.Threading.Tasks.Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual global::System.Threading.Tasks.Task OnAfterErrorAsync(
            global::Ollama.AutoSDKHookContext context)
        {
            return global::System.Threading.Tasks.Task.CompletedTask;
        }
    }

    /// <summary>
    /// Runtime metadata passed to generated SDK hooks.
    /// </summary>
    public sealed class AutoSDKHookContext
    {
        /// <summary>
        /// The source OpenAPI operation id or generated fallback id.
        /// </summary>
        public string OperationId { get; set; } = string.Empty;

        /// <summary>
        /// The generated C# method name.
        /// </summary>
        public string MethodName { get; set; } = string.Empty;

        /// <summary>
        /// The OpenAPI path template for the operation.
        /// </summary>
        public string PathTemplate { get; set; } = string.Empty;

        /// <summary>
        /// The HTTP method used for the request.
        /// </summary>
        public string HttpMethod { get; set; } = string.Empty;

        /// <summary>
        /// The client's resolved base URI.
        /// </summary>
        public global::System.Uri? BaseUri { get; set; }

        /// <summary>
        /// The outgoing HTTP request for the current attempt.
        /// </summary>
        public global::System.Net.Http.HttpRequestMessage Request { get; set; } = null!;

        /// <summary>
        /// The HTTP response when one was received.
        /// </summary>
        public global::System.Net.Http.HttpResponseMessage? Response { get; set; }

        /// <summary>
        /// The transport or processing exception when one was observed.
        /// </summary>
        public global::System.Exception? Exception { get; set; }

        /// <summary>
        /// The client-wide runtime options.
        /// </summary>
        public global::Ollama.AutoSDKClientOptions ClientOptions { get; set; } = null!;

        /// <summary>
        /// The per-request runtime options.
        /// </summary>
        public global::Ollama.AutoSDKRequestOptions? RequestOptions { get; set; }

        /// <summary>
        /// The current attempt number, starting at 1.
        /// </summary>
        public int Attempt { get; set; }

        /// <summary>
        /// The total number of attempts allowed for this request.
        /// </summary>
        public int MaxAttempts { get; set; }

        /// <summary>
        /// Indicates whether the generated client will retry after this hook invocation.
        /// </summary>
        public bool WillRetry { get; set; }

        /// <summary>
        /// The computed retry delay when <see cref="WillRetry"/> is true.
        /// </summary>
        public global::System.TimeSpan? RetryDelay { get; set; }

        /// <summary>
        /// A short retry reason such as exception or status:429.
        /// </summary>
        public string RetryReason { get; set; } = string.Empty;

        /// <summary>
        /// The effective cancellation token for the current request attempt.
        /// </summary>
        public global::System.Threading.CancellationToken CancellationToken { get; set; }
    }


    internal static class AutoSDKRequestOptionsSupport
    {
        internal static global::Ollama.AutoSDKHookContext CreateHookContext(
            string operationId,
            string methodName,
            string pathTemplate,
            string httpMethod,
            global::System.Uri? baseUri,
            global::System.Net.Http.HttpRequestMessage request,
            global::System.Net.Http.HttpResponseMessage? response,
            global::System.Exception? exception,
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            int attempt,
            int maxAttempts,
            bool willRetry,
            global::System.TimeSpan? retryDelay,
            string retryReason,
            global::System.Threading.CancellationToken cancellationToken)
        {
            return new global::Ollama.AutoSDKHookContext
            {
                OperationId = operationId ?? string.Empty,
                MethodName = methodName ?? string.Empty,
                PathTemplate = pathTemplate ?? string.Empty,
                HttpMethod = httpMethod ?? string.Empty,
                BaseUri = baseUri,
                Request = request,
                Response = response,
                Exception = exception,
                ClientOptions = clientOptions,
                RequestOptions = requestOptions,
                Attempt = attempt,
                MaxAttempts = maxAttempts,
                WillRetry = willRetry,
                RetryDelay = retryDelay,
                RetryReason = retryReason ?? string.Empty,
                CancellationToken = cancellationToken,
            };
        }

        internal static global::System.Threading.Tasks.Task OnBeforeRequestAsync(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKHookContext context)
        {
            return InvokeHooksAsync(clientOptions, static (hook, hookContext) => hook.OnBeforeRequestAsync(hookContext), context);
        }

        internal static global::System.Threading.Tasks.Task OnAfterSuccessAsync(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKHookContext context)
        {
            return InvokeHooksAsync(clientOptions, static (hook, hookContext) => hook.OnAfterSuccessAsync(hookContext), context);
        }

        internal static global::System.Threading.Tasks.Task OnAfterErrorAsync(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKHookContext context)
        {
            return InvokeHooksAsync(clientOptions, static (hook, hookContext) => hook.OnAfterErrorAsync(hookContext), context);
        }

        internal static bool GetReadResponseAsString(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            bool fallbackValue)
        {
            return requestOptions?.ReadResponseAsString ??
                   clientOptions.ReadResponseAsString ??
                   fallbackValue;
        }

        internal static global::System.Threading.CancellationTokenSource? CreateTimeoutCancellationTokenSource(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            global::System.Threading.CancellationToken cancellationToken)
        {
            var timeout = requestOptions?.Timeout ?? clientOptions.Timeout;
            if (!timeout.HasValue || timeout.Value <= global::System.TimeSpan.Zero)
            {
                return null;
            }

            var cancellationTokenSource = global::System.Threading.CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cancellationTokenSource.CancelAfter(timeout.Value);
            return cancellationTokenSource;
        }

        internal static int GetMaxAttempts(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            bool supportsRetry)
        {
            if (!supportsRetry)
            {
                return 1;
            }

            var maxAttempts = requestOptions?.Retry?.MaxAttempts ??
                              clientOptions.Retry?.MaxAttempts ??
                              1;
            return maxAttempts < 1 ? 1 : maxAttempts;
        }

        internal static global::System.TimeSpan GetRetryDelay(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            global::System.Net.Http.HttpResponseMessage? response,
            int attempt)
        {
            var retryOptions = requestOptions?.Retry ?? clientOptions.Retry ?? new global::Ollama.AutoSDKRetryOptions();

            if (retryOptions.UseRetryAfterHeader &&
                TryGetRetryAfterDelay(response, out var retryAfterDelay))
            {
                return ClampRetryDelay(retryAfterDelay, retryOptions);
            }

            if (retryOptions.UseRateLimitResetHeader &&
                TryGetRateLimitResetDelay(response, retryOptions.RateLimitResetHeaderName, out var rateLimitResetDelay))
            {
                return ClampRetryDelay(rateLimitResetDelay, retryOptions);
            }

            if (retryOptions.Delay.HasValue)
            {
                return ClampRetryDelay(retryOptions.Delay.Value, retryOptions);
            }

            var initialDelay = retryOptions.InitialDelay;
            if (initialDelay <= global::System.TimeSpan.Zero)
            {
                return global::System.TimeSpan.Zero;
            }

            var multiplier = retryOptions.BackoffMultiplier < 1D ? 1D : retryOptions.BackoffMultiplier;
            var exponent = attempt <= 1 ? 0 : attempt - 1;
            var delayMilliseconds = initialDelay.TotalMilliseconds * global::System.Math.Pow(multiplier, exponent);
            if (double.IsNaN(delayMilliseconds) || double.IsInfinity(delayMilliseconds) || delayMilliseconds < 0D)
            {
                delayMilliseconds = 0D;
            }

            var delay = global::System.TimeSpan.FromMilliseconds(delayMilliseconds);
            delay = ApplyJitter(delay, retryOptions.JitterRatio);
            return ClampRetryDelay(delay, retryOptions);
        }

        internal static async global::System.Threading.Tasks.Task DelayBeforeRetryAsync(
            global::System.TimeSpan retryDelay,
            global::System.Threading.CancellationToken cancellationToken)
        {
            if (retryDelay <= global::System.TimeSpan.Zero)
            {
                return;
            }

            await global::System.Threading.Tasks.Task.Delay(retryDelay, cancellationToken).ConfigureAwait(false);
        }

        private static bool TryGetRetryAfterDelay(
            global::System.Net.Http.HttpResponseMessage? response,
            out global::System.TimeSpan delay)
        {
            delay = global::System.TimeSpan.Zero;
            var retryAfter = response?.Headers.RetryAfter;
            if (retryAfter == null)
            {
                return false;
            }

            if (retryAfter.Delta.HasValue)
            {
                delay = retryAfter.Delta.Value;
                return delay > global::System.TimeSpan.Zero;
            }

            if (retryAfter.Date.HasValue)
            {
                delay = retryAfter.Date.Value - global::System.DateTimeOffset.UtcNow;
                return delay > global::System.TimeSpan.Zero;
            }

            return false;
        }

        private static bool TryGetRateLimitResetDelay(
            global::System.Net.Http.HttpResponseMessage? response,
            string? headerName,
            out global::System.TimeSpan delay)
        {
            delay = global::System.TimeSpan.Zero;
            if (response == null || string.IsNullOrWhiteSpace(headerName))
            {
                return false;
            }

            if (!response.Headers.TryGetValues(headerName, out var values) &&
                (response.Content?.Headers == null || !response.Content.Headers.TryGetValues(headerName, out values)))
            {
                return false;
            }

            var value = global::System.Linq.Enumerable.FirstOrDefault(values);
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();
            if (long.TryParse(
                value,
                global::System.Globalization.NumberStyles.Integer,
                global::System.Globalization.CultureInfo.InvariantCulture,
                out var unixSeconds))
            {
                delay = global::System.DateTimeOffset.FromUnixTimeSeconds(unixSeconds) - global::System.DateTimeOffset.UtcNow;
                return delay > global::System.TimeSpan.Zero;
            }

            if (global::System.DateTimeOffset.TryParse(
                value,
                global::System.Globalization.CultureInfo.InvariantCulture,
                global::System.Globalization.DateTimeStyles.AssumeUniversal | global::System.Globalization.DateTimeStyles.AdjustToUniversal,
                out var resetAt))
            {
                delay = resetAt - global::System.DateTimeOffset.UtcNow;
                return delay > global::System.TimeSpan.Zero;
            }

            return false;
        }

        private static global::System.TimeSpan ApplyJitter(
            global::System.TimeSpan delay,
            double jitterRatio)
        {
            if (delay <= global::System.TimeSpan.Zero || jitterRatio <= 0D)
            {
                return delay;
            }

            if (jitterRatio > 1D)
            {
                jitterRatio = 1D;
            }

            var sample = NextJitterSample();
            var multiplier = 1D - jitterRatio + (sample * jitterRatio * 2D);
            var milliseconds = delay.TotalMilliseconds * multiplier;
            if (double.IsNaN(milliseconds) || double.IsInfinity(milliseconds) || milliseconds < 0D)
            {
                milliseconds = 0D;
            }

            return global::System.TimeSpan.FromMilliseconds(milliseconds);
        }

        private static double NextJitterSample()
        {
            var bytes = new byte[8];
            using (var randomNumberGenerator = global::System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(bytes);
            }

            var value = global::System.BitConverter.ToUInt64(bytes, 0);
            return value / (double)ulong.MaxValue;
        }

        private static global::System.TimeSpan ClampRetryDelay(
            global::System.TimeSpan delay,
            global::Ollama.AutoSDKRetryOptions retryOptions)
        {
            if (delay <= global::System.TimeSpan.Zero)
            {
                return global::System.TimeSpan.Zero;
            }

            var maxDelay = retryOptions.MaxDelay;
            if (maxDelay > global::System.TimeSpan.Zero && delay > maxDelay)
            {
                return maxDelay;
            }

            return delay;
        }

        internal static bool ShouldRetryStatusCode(
            global::System.Net.HttpStatusCode statusCode)
        {
            return (int)statusCode switch
            {
                408 => true,
                429 => true,
                500 => true,
                502 => true,
                503 => true,
                504 => true,
                _ => false,
            };
        }

        internal static string AppendQueryParameters(
            string path,
            global::System.Collections.Generic.Dictionary<string, string> clientParameters,
            global::System.Collections.Generic.Dictionary<string, string>? requestParameters)
        {
            var hasClientParameters = clientParameters != null && clientParameters.Count > 0;
            var hasRequestParameters = requestParameters != null && requestParameters.Count > 0;
            if (!hasClientParameters && !hasRequestParameters)
            {
                return path;
            }

            var builder = new global::System.Text.StringBuilder(path ?? string.Empty);
            var hasQuery = builder.ToString().IndexOf("?", global::System.StringComparison.Ordinal) >= 0;
            AppendParameters(builder, clientParameters, ref hasQuery);
            AppendParameters(builder, requestParameters, ref hasQuery);
            return builder.ToString();
        }

        internal static void ApplyHeaders(
            global::System.Net.Http.HttpRequestMessage request,
            global::System.Collections.Generic.Dictionary<string, string> clientHeaders,
            global::System.Collections.Generic.Dictionary<string, string>? requestHeaders)
        {
            ApplyHeadersCore(request, clientHeaders);
            ApplyHeadersCore(request, requestHeaders);
        }

        private static void AppendParameters(
            global::System.Text.StringBuilder builder,
            global::System.Collections.Generic.Dictionary<string, string>? parameters,
            ref bool hasQuery)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return;
            }

            foreach (var parameter in parameters)
            {
                builder.Append(hasQuery ? '&' : '?');
                builder.Append(global::System.Uri.EscapeDataString(parameter.Key));
                builder.Append('=');
                builder.Append(global::System.Uri.EscapeDataString(parameter.Value ?? string.Empty));
                hasQuery = true;
            }
        }

        private static void ApplyHeadersCore(
            global::System.Net.Http.HttpRequestMessage request,
            global::System.Collections.Generic.Dictionary<string, string>? headers)
        {
            if (headers == null || headers.Count == 0)
            {
                return;
            }

            foreach (var header in headers)
            {
                request.Headers.Remove(header.Key);
                request.Content?.Headers.Remove(header.Key);

                if (!request.Headers.TryAddWithoutValidation(header.Key, header.Value ?? string.Empty) &&
                    request.Content != null)
                {
                    request.Content.Headers.TryAddWithoutValidation(header.Key, header.Value ?? string.Empty);
                }
            }
        }

        private static async global::System.Threading.Tasks.Task InvokeHooksAsync(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::System.Func<global::Ollama.IAutoSDKHook, global::Ollama.AutoSDKHookContext, global::System.Threading.Tasks.Task> callback,
            global::Ollama.AutoSDKHookContext context)
        {
            if (clientOptions.Hooks == null || clientOptions.Hooks.Count == 0)
            {
                return;
            }

            foreach (var hook in clientOptions.Hooks)
            {
                if (hook == null)
                {
                    continue;
                }

                await callback(hook, context).ConfigureAwait(false);
            }
        }
    }
}