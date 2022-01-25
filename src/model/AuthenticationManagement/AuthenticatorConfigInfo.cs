using System.Collections.Generic;
using Keycloak.Net.Model.Common;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authenticatorconfiginforepresentation
    /// </summary>
    public class AuthenticatorConfigInfo
    {
        [JsonProperty("helpText")]
        public string? HelpText { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty>? Properties { get; set; }

        [JsonProperty("providerId")]
        public string? ProviderId { get; set; }
    }
}
