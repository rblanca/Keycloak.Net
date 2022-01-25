using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Authorization
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AuthorizationProviders Providers { get; set; } = null!;
    }
}