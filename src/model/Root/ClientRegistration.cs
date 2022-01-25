using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ClientRegistration
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ClientRegistrationProviders? Providers { get; set; }
    }
}