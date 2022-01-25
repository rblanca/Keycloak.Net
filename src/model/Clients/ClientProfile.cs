using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientprofilerepresentation
    /// </summary>
    public class ClientProfile
    {
        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("executors")]
        public IEnumerable<ClientPolicyExecutor>? Executors { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
