using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ActionTokenProviders
    {
        [JsonProperty("infinispan")]
        public HasOrder Infinispan { get; set; } = null!;
    }
}