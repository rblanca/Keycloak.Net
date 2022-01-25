using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ConnectionsJpa
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ConnectionsJpaProviders Providers { get; set; }
    }
}