using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_userconsentrepresentation
    /// </summary>
    public class UserConsent
    {
        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("createdDate")]
        public long? CreatedDate { get; set; }

        [JsonProperty("grantedClientScopes")]
        public IEnumerable<string>? GrantedClientScopes { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public long? LastUpdatedDate { get; set; }
    }
}
