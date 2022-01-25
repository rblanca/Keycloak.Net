using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Protocol mappers perform transformation on tokens and documents. They can do things like map user data into protocol claims, or just transform any requests going between the client and auth server. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_protocolmapperrepresentation
    /// </summary>
    public class ClientProtocolMapper
    {

        [JsonProperty("config")]
        public ClientConfig? Config { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        [JsonProperty("protocolMapper")]
        public string? ProtocolMapper { get; set; }
    }
}