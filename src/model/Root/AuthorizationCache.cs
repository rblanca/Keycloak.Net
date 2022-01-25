using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AuthorizationCache
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AuthorizationCacheProviders Providers { get; set; } = null!;
    }
}