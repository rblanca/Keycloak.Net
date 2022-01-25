using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ProtocolMapperTypes
    {
        [JsonProperty("saml")] 
        public IEnumerable<ProtocolMapperType> Saml { get; set; } = null!;

        [JsonProperty("docker-v2")]
        public IEnumerable<ProtocolMapperType> DockerV2 { get; set; } = null!;

        [JsonProperty("openid-connect")]
        public IEnumerable<ProtocolMapperType> OpenIdConnect { get; set; } = null!;
    }
}