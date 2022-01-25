using Keycloak.Net.Model.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientpolicyexecutorrepresentation
    /// </summary>
    public class ClientPolicyExecutor
    {
        [JsonProperty("configuration")]
        public JsonNode? Configuration { get; set; }

        [JsonProperty("executor")]
        public string? Executor { get; set; }
    }
}
