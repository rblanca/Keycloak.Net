using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net.Model.Converters
{
    public class PolicyEnforcementModeConverter : JsonEnumConverter<PolicyEnforcementMode>
    {
        private static readonly Dictionary<PolicyEnforcementMode, string> SPairs = new()
        {
            [PolicyEnforcementMode.Enforcing] = "ENFORCING",
            [PolicyEnforcementMode.Permissive] = "PERMISSIVE",
            [PolicyEnforcementMode.Disabled] = "DISABLED"
        };

        protected override string EntityString => nameof(PolicyEnforcementMode);

        protected override string ConvertToString(PolicyEnforcementMode value) => SPairs[value];

        protected override PolicyEnforcementMode ConvertFromString(string s)
        {
            if (SPairs.Values.Contains(s.ToUpper()))
            {
                return SPairs.First(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Key;
            }

            throw new ArgumentException($"Unknown {EntityString}: {s}");
        }
    }
}