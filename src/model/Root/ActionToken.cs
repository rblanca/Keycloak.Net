using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ActionToken
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ActionTokenProviders Providers { get; set; } = null!;
    }
}