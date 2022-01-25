using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class FormAction
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public FormActionProviders Providers { get; set; }
    }
}