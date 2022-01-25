using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Port
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ExportProviders Providers { get; set; }
    }
}