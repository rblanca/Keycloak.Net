using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Theme
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ThemeProviders Providers { get; set; }
    }
}