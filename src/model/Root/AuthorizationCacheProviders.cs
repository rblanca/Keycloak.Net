using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AuthorizationCacheProviders
    {
        [JsonProperty("default")]
        public HasOrder Default { get; set; } = null!;
    }
}