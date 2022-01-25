using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Hostname
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public HostnameProviders Providers { get; set; }
    }
}