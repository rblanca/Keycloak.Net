using Newtonsoft.Json;

namespace Keycloak.Net.Model.ProtocolMappers
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_protocolmapperrepresentation
    /// </summary>
    public class ProtocolMapper
    {
        [JsonProperty("config")]
        public ProtocolConfig? Config { get; set; }

        [JsonProperty("consentRequired")]
        public bool? ConsentRequired { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        [JsonProperty("protocolMapper")]
        // Default to Claim Param Token protocolMapper
        public string? _ProtocolMapper { get; set; } = ClaimMapperTypes.OidcClaimsParam;
    }
}