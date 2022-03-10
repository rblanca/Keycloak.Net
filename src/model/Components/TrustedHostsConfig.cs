using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/services/src/main/java/org/keycloak/services/clientregistration/policy/ClientRegistrationPolicy.java
    /// </summary>
    public class TrustedHostsConfig : ComponentConfig
    {
        [JsonProperty("host-sending-registration-request-must-match")]
        public IEnumerable<bool>? HostSendingRegistrationRequestMustMatch { get; set; }

        [JsonProperty("client-uris-must-match")]
        public IEnumerable<bool>? ClientUrisMustMatch { get; set; }
    }
}
