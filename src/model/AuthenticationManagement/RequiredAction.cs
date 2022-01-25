using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_registerrequiredaction
    /// </summary>
    public class RequiredAction
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("providerId")]
        public string? ProviderId { get; set; }
    }
}
