using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authenticationexecutionrepresentation
    /// </summary>
    public class AuthenticationExecution
    {
        [JsonProperty("authenticator")]
        public string? Authenticator { get; set; }

        [JsonProperty("authenticatorConfig")]
        public string? AuthenticatorConfig { get; set; }

        [JsonProperty("authenticatorFlow")]
        public bool? AuthenticatorFlow { get; set; }

        [JsonProperty("flowId")]
        public string? FlowId { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("parentFlow")]
        public string? ParentFlow { get; set; }
        
        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("requirement")]
        public string? Requirement { get; set; }
    }
}