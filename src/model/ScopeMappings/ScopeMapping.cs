using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.ScopeMappings
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_scopemappingrepresentation
    /// </summary>
    public class ScopeMapping
    {
        [JsonProperty("client")]
        public string? Client { get; set; }

        [JsonProperty("clientScope")]
        public string? ClientScope { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<string>? Roles { get; set; }

        [JsonProperty("self")]
        public string? Self { get; set; }
    }
}
