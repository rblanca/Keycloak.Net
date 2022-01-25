using Newtonsoft.Json;

namespace Keycloak.Net.Model.ClientInitialAccess
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientinitialaccesspresentation
    /// </summary>
    public class ClientInitialAccessPresentation : ClientInitialAccessCreatePresentation
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("remainingCount")]
        public int? RemainingCount { get; set; }

        [JsonProperty("timestamp")]
        public int? Timestamp { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
