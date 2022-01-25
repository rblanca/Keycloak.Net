using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Authenticator
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AuthenticatorProviders Providers { get; set; } = null!;
    }
}