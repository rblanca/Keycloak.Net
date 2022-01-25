using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ClientAuthenticator
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ClientAuthenticatorProvider Providers { get; set; } = null!;
    }
}