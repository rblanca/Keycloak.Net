using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AccountProviders
    {
        [JsonProperty("freemarker")]
        public HasOrder Freemarker { get; set; } = null!;

        [JsonProperty("authorization")]
        public HasOrder Authorization { get; set; } = null!;

    }
}