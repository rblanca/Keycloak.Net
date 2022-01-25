using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class JtaLookup
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public JtaLookupProviders Providers { get; set; }
    }
}