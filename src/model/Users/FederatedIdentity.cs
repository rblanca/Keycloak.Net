using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_credentialrepresentation
    /// </summary>
    public class FederatedIdentity
    {
        [JsonProperty("identityProvider")]
        public string? IdentityProvider { get; set; }

        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("userName")]
        public string? UserName { get; set; }
    }
}
