using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_userfederationproviderrepresentation
    /// </summary>
    public class UserFederationProvider
    {
        [JsonProperty("changedSyncPeriod")]
        public int? ChangedSyncPeriod { get; set; }

        [JsonProperty("config")]
        public IDictionary<string, object>? Config { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("fullSyncPeriod")]
        public int? FullSyncPeriod { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("lastSync")]
        public int? LastSync { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("providerName")]
        public string? ProviderName { get; set; }
    }
}
