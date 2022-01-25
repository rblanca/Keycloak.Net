using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AuthorizationProviders
    {
        [JsonProperty("authorization")]
        public HasOrder Authorization { get; set; } = null!;
    }
}