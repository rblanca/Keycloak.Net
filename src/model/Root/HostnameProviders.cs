using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class HostnameProviders
    {
        [JsonProperty("request")]
        public HasOrder Request { get; set; }
    }
}