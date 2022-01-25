using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_userfederationmapperrepresentation
    /// </summary>
    public class UserFederationMapper
    {
        [JsonProperty("config")]
        public IDictionary<string, object>? Config { get; set; }

        [JsonProperty("federationMapperType")]
        public string? FederationMapperType { get; set; }

        [JsonProperty("federationProviderDisplayName")]
        public string? FederationProviderDisplayName { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
