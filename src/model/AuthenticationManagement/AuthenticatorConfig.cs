using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authenticatorconfigrepresentation
    /// </summary>
    public class AuthenticatorConfig
    {
        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("config")]
        public IDictionary<string, object>? Config { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
