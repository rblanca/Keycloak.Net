using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientpolicyrepresentation
    /// </summary>
    public class ClientPolicy
    {
        [JsonProperty("conditions")]
        public ClientPolicyCondition[]? Conditions { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("profiles")]
        public IEnumerable<string>? Profiles { get; set; }
    }
}
