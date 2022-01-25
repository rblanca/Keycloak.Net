using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net.Model.Converters
{
    public class SamlSignatureKeyNameConverter : JsonEnumConverter<SamlSignatureKeyName>
    {
        private static readonly Dictionary<SamlSignatureKeyName, string> s_pairs = new Dictionary<SamlSignatureKeyName, string>
        {
            [SamlSignatureKeyName.None] = "NONE",
            [SamlSignatureKeyName.KeyId] = "KEY_ID",
            [SamlSignatureKeyName.CertSub] = "CERT_SUB"
        };

        protected override string EntityString => "SAML Signature Key Name ";

        protected override string ConvertToString(SamlSignatureKeyName value) => s_pairs[value];

        protected override SamlSignatureKeyName ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<SamlSignatureKeyName, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
