using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class CekManagementProviders
    {
        [JsonProperty("RSA-OAEP")]
        public HasOrder RsaOaep { get; set; } = null!;

        [JsonProperty("RSA-OAEP-256")]
        public HasOrder RsaOaep256 { get; set; } = null!;

        [JsonProperty("RSA1_5")]
        public HasOrder Rsa1_5 { get; set; } = null!;
    }
}