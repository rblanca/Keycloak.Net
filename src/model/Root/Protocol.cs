using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(ProtocolConverter))]
    public enum Protocol
    {
        DockerV2, 
        OpenIdConnect, 
        Saml
    }
}