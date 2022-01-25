using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class TruststoreProviders
    {
        [JsonProperty("file")]
        public HasOrder File { get; set; }
    }
}