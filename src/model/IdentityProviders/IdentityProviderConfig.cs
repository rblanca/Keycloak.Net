using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_identityproviderrepresentation
    /// </summary>
    public class IdentityProviderConfig
    {
        [JsonProperty("clientSecret")]
        public string? ClientSecret { get; set; }

        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("disableUserInfo")]
        public string? DisableUserInfo { get; set; }

        [JsonProperty("hideOnLoginPage")]
        public string? HideOnLoginPage { get; set; }

        [JsonProperty("useJwksUrl")]
        public string? UseJwksUrl { get; set; }
    }
}