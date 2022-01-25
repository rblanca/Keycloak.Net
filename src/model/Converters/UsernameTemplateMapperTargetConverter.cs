using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.IdentityProviders;

namespace Keycloak.Net.Model.Converters
{
    public class UsernameTemplateMapperTargetConverter : JsonEnumConverter<UsernameTemplateMapperTarget>
    {
        private static readonly Dictionary<UsernameTemplateMapperTarget, string> s_pairs = new()
        {
            [UsernameTemplateMapperTarget.Local] = "LOCAL",
            [UsernameTemplateMapperTarget.BrokerId] = "BROKER_ID",
            [UsernameTemplateMapperTarget.BrokerUsername] = "BROKER_USERNAME"
        };

        protected override string EntityString { get; } = nameof(UsernameTemplateMapperTarget).ToLower();

        protected override string ConvertToString(UsernameTemplateMapperTarget value) => s_pairs[value];

        protected override UsernameTemplateMapperTarget ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<UsernameTemplateMapperTarget, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
