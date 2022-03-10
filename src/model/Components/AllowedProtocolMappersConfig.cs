using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <remarks>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/services/src/main/java/org/keycloak/services/clientregistration/policy/ClientRegistrationPolicy.java
    /// </remarks>
    public class AllowedProtocolMappersConfig
    {
        /// <summary>
        /// The client allowed protocol mapper types.
        /// </summary>
        [JsonProperty("allowed-protocol-mapper-types")]
        public IEnumerable<string>? AllowedProtocolMapperTypes { get; set; }
    }
}
