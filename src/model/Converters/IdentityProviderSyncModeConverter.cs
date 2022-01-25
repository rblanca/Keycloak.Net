using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.IdentityProviders;

namespace Keycloak.Net.Model.Converters
{
    public class IdentityProviderSyncModeConverter : JsonEnumConverter<IdentityProviderSyncMode>
    {
        private static readonly Dictionary<IdentityProviderSyncMode, string> s_pairs = new()
        {
            [IdentityProviderSyncMode.Inherit] = "INHERIT",
            [IdentityProviderSyncMode.Legacy] = "LEGACY",
            [IdentityProviderSyncMode.Import] = "IMPORT",
            [IdentityProviderSyncMode.Force] = "FORCE"
        };

        protected override string EntityString { get; } = nameof(IdentityProviderSyncMode).ToLower();

        protected override string ConvertToString(IdentityProviderSyncMode value) => s_pairs[value];

        protected override IdentityProviderSyncMode ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<IdentityProviderSyncMode, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
