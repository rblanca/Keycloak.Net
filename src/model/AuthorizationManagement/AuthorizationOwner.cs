using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthorizationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/ResourceOwnerRepresentation.html
    /// </summary>
    public class AuthorizationOwner
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
