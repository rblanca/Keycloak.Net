using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class HasOrder
    {
        [JsonProperty("order")]
        public int Order { get; set; }
    }
}