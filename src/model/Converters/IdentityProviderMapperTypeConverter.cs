using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.IdentityProviders;

namespace Keycloak.Net.Model.Converters
{
    public class IdentityProviderMapperTypeConverter : JsonEnumConverter<IdentityProviderMapperType>
    {
        private static readonly Dictionary<IdentityProviderMapperType, string> s_pairs = new()
        {
            [IdentityProviderMapperType.HardcodedUserSessionAttribute] = "hardcoded-user-session-attribute-idp-mapper",
            [IdentityProviderMapperType.HardcodedRole] = "oidc-hardcoded-role-idp-mapper",
            [IdentityProviderMapperType.AttributeImporter] = "facebook-user-attribute-mapper",
            [IdentityProviderMapperType.HardcodedAttribute] = "hardcoded-attribute-idp-mapper",
            [IdentityProviderMapperType.UsernameTemplateImporter] = "oidc-username-idp-mapper"
        };

        protected override string EntityString { get; } = nameof(IdentityProviderMapperType).ToLower();

        protected override string ConvertToString(IdentityProviderMapperType value) => s_pairs[value];

        protected override IdentityProviderMapperType ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<IdentityProviderMapperType, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
