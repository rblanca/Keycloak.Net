using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class CredentialProviders
    {
        [JsonProperty("keycloak-otp")]
        public HasOrder KeycloakOtp { get; set; }

        [JsonProperty("keycloak-password")]
        public HasOrder KeycloakPassword { get; set; }
    }
}