using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class CekManagement
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public CekManagementProviders Providers { get; set; } = null!;
    }
}