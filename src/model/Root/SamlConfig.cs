using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class SamlConfig
    {
        [JsonProperty("attribute.nameformat")]
        public string AttributeNameformat { get; set; } = null!;
        
        [JsonProperty("user.attribute")]
        public string UserAttribute { get; set; } = null!;

        [JsonProperty("friendly.name")]
        public string FriendlyName { get; set; } = null!;

        [JsonProperty("attribute.name")]
        public string AttributeName { get; set; } = null!;

        [JsonProperty("single")]
        public bool Single { get; set; }
    }
}