using Keycloak.Net.Model.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientpolicyconditionrepresentation
    /// </summary>
    public class ClientPolicyCondition
    {
        [JsonProperty("condition")]
        public string? Condition { get; set; }

        [JsonProperty("configuration")]
        public JsonNode? Configuration { get; set; }
    }
}
