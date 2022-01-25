using Newtonsoft.Json;

namespace Keycloak.Net.Model.ClientInitialAccess
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientinitialaccesscreatepresentation
    /// </summary>
    public class ClientInitialAccessCreatePresentation
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("expiration")]
        public int? Expiration { get; set; }
    }
}
