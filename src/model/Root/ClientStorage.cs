using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ClientStorage
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ClientStorageProviders? Providers { get; set; }
    }
}