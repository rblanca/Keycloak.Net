using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_realms_admin_resource
    /// </summary>
    public class AdminEvent
    {
        [JsonProperty("authDetails")]
        public AuthDetails? AuthDetails { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("operationType")]
        public string? OperationType { get; set; }

        [JsonProperty("realmId")]
        public string? RealmId { get; set; }

        [JsonProperty("representation")]
        public string? Representation { get; set; }

        [JsonProperty("resourcePath")]
        public string? ResourcePath { get; set; }

        [JsonProperty("resourceType")]
        public string? ResourceType { get; set; }

        [JsonProperty("time")]
        public long? Time { get; set; }
    }
}
