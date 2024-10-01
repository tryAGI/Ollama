using System.Linq;

#nullable enable

namespace Ollama
{
    /// <summary>
    /// A helper class to build URL paths with optional and required parameters.
    /// </summary>
    public class PathBuilder
    {
        private readonly global::System.Text.StringBuilder _stringBuilder =
            new global::System.Text.StringBuilder(capacity: 256);
        private bool _firstParameter = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathBuilder"/> class.
        /// </summary>
        /// <param name="path">The base path for the URL.</param>
        /// <param name="baseUri">The base URI to prepend to the path, if any.</param>
        public PathBuilder(
            string path,
            global::System.Uri? baseUri = null)
        {
            if (baseUri is not null)
            {
                _stringBuilder.Append(baseUri.AbsoluteUri.TrimEnd('/'));
            }

            _stringBuilder.Append(path);
        }

        /// <summary>
        /// Adds a required parameter to the URL.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddRequiredParameter(
            string name,
            string value)
        {
            if (_firstParameter)
            {
                _stringBuilder.Append('?');
                _firstParameter = false;
            }
            else
            {
                _stringBuilder.Append('&');
            }

            _stringBuilder.Append(global::System.Uri.EscapeDataString(name));
            _stringBuilder.Append('=');
            _stringBuilder.Append(global::System.Uri.EscapeDataString(value));

            return this;
        }

        /// <summary>
        /// Adds a required parameter with multiple values to the URL.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The values of the parameter.</param>
        /// <param name="delimiter">The delimiter to use between values.</param>
        /// <param name="explode">Whether to explode the values into separate parameters.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddRequiredParameter(
            string name,
            global::System.Collections.Generic.IEnumerable<string> value,
            string delimiter = ",",
            bool explode = false)
        {
            if (explode)
            {
                foreach (var item in value)
                {
                    AddRequiredParameter($"{name}", item);
                }

                return this;
            }

            AddRequiredParameter(name, string.Join(delimiter, value));

            return this;
        }

        /// <summary>
        /// Adds a required parameter with multiple values to the URL, using a selector function.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The values of the parameter.</param>
        /// <param name="selector">The function to select the string representation of each value.</param>
        /// <param name="delimiter">The delimiter to use between values.</param>
        /// <param name="explode">Whether to explode the values into separate parameters.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddRequiredParameter<T>(
            string name,
            global::System.Collections.Generic.IEnumerable<T> value,
            global::System.Func<T, string> selector,
            string delimiter = ",",
            bool explode = false)
        {
            AddRequiredParameter(name, value.Select(selector).ToArray(), delimiter, explode);

            return this;
        }

        /// <summary>
        /// Adds an optional parameter to the URL.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not present.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddOptionalParameter(
            string name,
            string? value)
        {
            if (value is not null)
            {
                AddRequiredParameter(name, value);
            }

            return this;
        }

        /// <summary>
        /// Adds an optional parameter with multiple values to the URL.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The values of the parameter, or null if not present.</param>
        /// <param name="delimiter">The delimiter to use between values.</param>
        /// <param name="explode">Whether to explode the values into separate parameters.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddOptionalParameter(
            string name,
            global::System.Collections.Generic.IEnumerable<string>? value,
            string delimiter = ",",
            bool explode = false)
        {
            if (value is not null)
            {
                AddRequiredParameter(name, value, delimiter, explode);
            }

            return this;
        }

        /// <summary>
        /// Adds an optional parameter with multiple values to the URL, using a selector function.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The values of the parameter, or null if not present.</param>
        /// <param name="selector">The function to select the string representation of each value.</param>
        /// <param name="delimiter">The delimiter to use between values.</param>
        /// <param name="explode">Whether to explode the values into separate parameters.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddOptionalParameter<T>(
            string name,
            global::System.Collections.Generic.IEnumerable<T>? value,
            global::System.Func<T, string> selector,
            string delimiter = ",",
            bool explode = false)
        {
            if (value is not null)
            {
                AddRequiredParameter(name, value.Select(selector).ToArray(), delimiter, explode);
            }

            return this;
        }

        /// <summary>
        /// Adds a required parameter to the URL, using a formattable value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="format">The format string.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddRequiredParameter<T>(
            string name,
            T value,
            string? format = null,
            global::System.IFormatProvider? formatProvider = null)
            where T : global::System.IFormattable
        {
            AddRequiredParameter(name, value.ToString(format, formatProvider));

            return this;
        }

        /// <summary>
        /// Adds an optional parameter to the URL, using a formattable value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not present.</param>
        /// <param name="format">The format string.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The current <see cref="PathBuilder"/> instance.</returns>
        public PathBuilder AddOptionalParameter<T>(
            string name,
            T? value,
            string? format = null,
            global::System.IFormatProvider? formatProvider = null)
            where T : global::System.IFormattable
        {
            if (value is not null)
            {
                AddOptionalParameter(name, value.ToString(format, formatProvider));
            }

            return this;
        }

        /// <summary>
        /// Returns the constructed URL as a string.
        /// </summary>
        /// <returns>The constructed URL.</returns>
        public override string ToString() => _stringBuilder.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public class EndPointAuthorization
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}