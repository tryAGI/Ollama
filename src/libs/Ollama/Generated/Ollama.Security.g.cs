#nullable enable

namespace Ollama
{
    internal sealed class EndPointAuthorizationRequirement
    {
        internal string Type { get; set; } = string.Empty;

        internal string SchemeId { get; set; } = string.Empty;

        internal string Location { get; set; } = string.Empty;

        internal string Name { get; set; } = string.Empty;

        internal string FriendlyName { get; set; } = string.Empty;
    }

    internal sealed class EndPointSecurityRequirement
    {
        internal global::System.Collections.Generic.IReadOnlyList<EndPointAuthorizationRequirement> Authorizations { get; set; } =
            global::System.Array.Empty<EndPointAuthorizationRequirement>();
    }

    internal static class EndPointSecurityResolver
    {
        internal static global::System.Collections.Generic.List<EndPointAuthorization> ResolveAuthorizations(
            global::System.Collections.Generic.IReadOnlyList<EndPointAuthorization> availableAuthorizations,
            global::System.Collections.Generic.IReadOnlyList<EndPointSecurityRequirement> securityRequirements,
            string operationName)
        {
            availableAuthorizations = availableAuthorizations ?? throw new global::System.ArgumentNullException(nameof(availableAuthorizations));
            securityRequirements = securityRequirements ?? throw new global::System.ArgumentNullException(nameof(securityRequirements));
            operationName = operationName ?? throw new global::System.ArgumentNullException(nameof(operationName));

            if (securityRequirements.Count == 0)
            {
                return new global::System.Collections.Generic.List<EndPointAuthorization>();
            }

            var allowsAnonymous = false;

            foreach (var requirement in securityRequirements)
            {
                if (requirement.Authorizations.Count == 0)
                {
                    allowsAnonymous = true;
                    continue;
                }

                var selected = new global::System.Collections.Generic.List<EndPointAuthorization>(requirement.Authorizations.Count);
                var satisfied = true;

                foreach (var requiredAuthorization in requirement.Authorizations)
                {
                    var found = false;

                    for (var i = 0; i < availableAuthorizations.Count; i++)
                    {
                        if (!Matches(availableAuthorizations[i], requiredAuthorization))
                        {
                            continue;
                        }

                        selected.Add(availableAuthorizations[i]);
                        found = true;
                        break;
                    }

                    if (!found)
                    {
                        satisfied = false;
                        break;
                    }
                }

                if (satisfied)
                {
                    return selected;
                }
            }

            if (allowsAnonymous)
            {
                return new global::System.Collections.Generic.List<EndPointAuthorization>();
            }

            throw new global::System.InvalidOperationException(
                $"Operation '{operationName}' requires one of the configured security alternatives: {DescribeRequirements(securityRequirements)}.");
        }

        private static bool Matches(
            EndPointAuthorization availableAuthorization,
            EndPointAuthorizationRequirement requiredAuthorization)
        {
            if (!string.Equals(availableAuthorization.Type, requiredAuthorization.Type, global::System.StringComparison.Ordinal))
            {
                return false;
            }

            return requiredAuthorization.Type switch
            {
                "OAuth2" => string.Equals(
                    availableAuthorization.SchemeId,
                    requiredAuthorization.SchemeId,
                    global::System.StringComparison.Ordinal),
                "OpenIdConnect" => string.Equals(
                    availableAuthorization.SchemeId,
                    requiredAuthorization.SchemeId,
                    global::System.StringComparison.Ordinal),
                "MutualTLS" => string.Equals(
                    availableAuthorization.SchemeId,
                    requiredAuthorization.SchemeId,
                    global::System.StringComparison.Ordinal),
                "Http" => string.Equals(
                    availableAuthorization.Name,
                    requiredAuthorization.Name,
                    global::System.StringComparison.Ordinal),
                "ApiKey" => string.Equals(
                        availableAuthorization.Location,
                        requiredAuthorization.Location,
                        global::System.StringComparison.Ordinal) &&
                    string.Equals(
                        availableAuthorization.Name,
                        requiredAuthorization.Name,
                        global::System.StringComparison.Ordinal),
                _ => string.Equals(
                        availableAuthorization.Location,
                        requiredAuthorization.Location,
                        global::System.StringComparison.Ordinal) &&
                    string.Equals(
                        availableAuthorization.Name,
                        requiredAuthorization.Name,
                        global::System.StringComparison.Ordinal),
            };
        }

        private static string DescribeRequirements(
            global::System.Collections.Generic.IReadOnlyList<EndPointSecurityRequirement> securityRequirements)
        {
            var parts = new global::System.Collections.Generic.List<string>(securityRequirements.Count);

            foreach (var requirement in securityRequirements)
            {
                if (requirement.Authorizations.Count == 0)
                {
                    parts.Add("anonymous");
                    continue;
                }

                parts.Add(string.Join(
                    " + ",
                    global::System.Linq.Enumerable.Select(requirement.Authorizations, static x => x.FriendlyName)));
            }

            return string.Join(" or ", parts);
        }
    }
}