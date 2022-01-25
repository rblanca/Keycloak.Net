using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_addexecutionflow
    /// </summary>
    public class AuthenticationFlowWithExecution
    {
        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("provider")]
        public string? Provider { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
