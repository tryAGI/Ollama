using System.Net.Http.Headers;

namespace Ollama;

public sealed partial class OllamaClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request)
    {
        foreach (var authorization in Authorizations)
        {
            if (!string.Equals(authorization.Location, "Header", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (string.Equals(authorization.Type, "ApiKey", StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(authorization.Name) &&
                !request.Headers.Contains(authorization.Name))
            {
                request.Headers.TryAddWithoutValidation(authorization.Name, authorization.Value);
            }
            else if ((string.Equals(authorization.Type, "Http", StringComparison.OrdinalIgnoreCase) ||
                      string.Equals(authorization.Type, "OAuth2", StringComparison.OrdinalIgnoreCase)) &&
                     request.Headers.Authorization is null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    authorization.SchemeId,
                    authorization.Value);
            }
        }
    }
}
