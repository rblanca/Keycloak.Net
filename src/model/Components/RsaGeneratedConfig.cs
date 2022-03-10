using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/server-spi-private/src/main/java/org/keycloak/keys/KeyProvider.java
    /// </summary>
    public class RsaGeneratedConfig : ComponentConfig
    {
        [JsonProperty("keyUse")]
        public IEnumerable<string>? KeyUse { get; set; }
    }
}
