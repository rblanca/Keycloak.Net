using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    public class AuthenticationFlowExecution
    {
        [JsonProperty("provider")]
        public string? Provider { get; set; }
    }
}
