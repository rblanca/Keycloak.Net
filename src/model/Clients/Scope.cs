using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_scoperepresentation
    /// </summary>
    public class Scope
    {
        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("iconUri")]
        public string? IconUri { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<Policy>? Policies { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<Resource>? Resources { get; set; }
    }
}
