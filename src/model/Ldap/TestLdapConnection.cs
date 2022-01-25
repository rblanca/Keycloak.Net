using Newtonsoft.Json;

namespace Keycloak.Net.Model.Ldap
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_testldapconnectionrepresentation
    /// </summary>
    public class TestLdapConnection
    {
        [JsonProperty("action")]
        public string? Action { get; set; }

        [JsonProperty("authType")]
        public string? AuthType { get; set; }

        [JsonProperty("bindCredential")]
        public string? BindCredential { get; set; }

        [JsonProperty("bindDn")]
        public string? BindDn { get; set; }

        [JsonProperty("componentId")]
        public string? ComponentId { get; set; }

        [JsonProperty("connectionTimeout")]
        public string? ConnectionTimeout { get; set; }

        [JsonProperty("connectionUrl")]
        public string? ConnectionUrl { get; set; }

        [JsonProperty("startTls")]
        public string? StartTls { get; set; }

        [JsonProperty("useTruststoreSpi")]
        public string? UseTruststoreSpi { get; set; }
    }
}
