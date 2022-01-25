using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Account
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AccountProviders Providers { get; set; } = null!;
    }
}