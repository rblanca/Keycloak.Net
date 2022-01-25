using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    public class IdentityProviderInfo
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
