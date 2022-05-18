using System.Collections.Generic;
using Keycloak.Net.Model.ProtocolMappers;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.ClientScopes
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientscoperepresentation
    /// </summary>
    public class ClientScope
    {
        [JsonProperty("attributes")]
        public Attributes? Attributes { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        [JsonProperty("protocolMappers")]
        public IEnumerable<ProtocolMapper>? ProtocolMappers { get; set; } 
    }
}
