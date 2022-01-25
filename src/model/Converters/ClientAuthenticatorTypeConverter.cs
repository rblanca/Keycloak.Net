using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net.Model.Converters
{
    public class ClientAuthenticatorTypeConverter : JsonEnumConverter<ClientAuthenticatorType>
    {
        private static readonly Dictionary<ClientAuthenticatorType, string> s_pairs = new Dictionary<ClientAuthenticatorType, string>
        {
            [ClientAuthenticatorType.ClientJwt] = "client-jwt",
            [ClientAuthenticatorType.ClientSecret] = "client-secret",
            [ClientAuthenticatorType.ClientX509] = "client-x509",
            [ClientAuthenticatorType.ClientSecretJwt] = "client-secret-jwt"
        };

        protected override string EntityString => nameof(ClientAuthenticatorType);

        protected override string ConvertToString(ClientAuthenticatorType value) => s_pairs[value];

        protected override ClientAuthenticatorType ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<ClientAuthenticatorType, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
