using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientpoliciesrepresentation
    /// </summary>
    public class ClientPolicies
    {
        [JsonProperty("policies")]
        public IEnumerable<ClientPolicy>? Policies { get; set; }
    }
}
