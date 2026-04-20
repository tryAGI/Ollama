
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
        /// Optional fixed delay between retry attempts.
        /// </summary>
        public global::System.TimeSpan? Delay { get; set; }
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

        internal static async global::System.Threading.Tasks.Task DelayBeforeRetryAsync(
            global::Ollama.AutoSDKClientOptions clientOptions,
            global::Ollama.AutoSDKRequestOptions? requestOptions,
            global::System.Threading.CancellationToken cancellationToken)
        {
            var delay = requestOptions?.Retry?.Delay ??
                        clientOptions.Retry?.Delay;
            if (!delay.HasValue || delay.Value <= global::System.TimeSpan.Zero)
            {
                return;
            }

            await global::System.Threading.Tasks.Task.Delay(delay.Value, cancellationToken).ConfigureAwait(false);
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