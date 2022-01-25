using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ConnectionsJpaProviders
    {
        [JsonProperty("default")]
        public Default Default { get; set; }
    }
}