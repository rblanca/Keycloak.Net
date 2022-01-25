using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_serverinforepresentation
    /// </summary>
    public class ClientInstallations
    {
        [JsonProperty("docker-v2")]
        public IEnumerable<ClientInstallation> DockerV2 { get; set; } = null!;

        [JsonProperty("saml")]
        public IEnumerable<ClientInstallation> Saml { get; set; } = null!;

        [JsonProperty("openid-connect")]
        public IEnumerable<ClientInstallation> OpenIdConnect { get; set; } = null!;
    }
}