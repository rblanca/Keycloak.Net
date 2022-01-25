using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authenticationexecutionexportrepresentation
    /// </summary>
    public class AuthenticationExecutionExport
    {
        [JsonProperty("authenticator")]
        public string? Authenticator { get; set; }

        [JsonProperty("authenticatorConfig")]
        public string? AuthenticatorConfig { get; set; }

        [JsonProperty("authenticatorFlow")]
        public bool? AuthenticatorFlow { get; set; }

        [JsonProperty("flowAlias")]
        public string? FlowAlias { get; set; }
        
        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("requirement")]
        public string? Requirement { get; set; }

        [JsonProperty("userSetupAllowed")]
        public bool? UserSetupAllowed { get; set; }
    }
}
