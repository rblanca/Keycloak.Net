using Keycloak.Net.Model.ProtocolMappers;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Saml
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("protocol")]
        public Protocol Protocol { get; set; }

        [JsonProperty("protocolMapper")]
        public string ProtocolMapper { get; set; } = null!;

        [JsonProperty("consentRequired")]
        public bool ConsentRequired { get; set; }

        [JsonProperty("config")]
        public ProtocolConfig Config { get; set; } = null!;
    }
}