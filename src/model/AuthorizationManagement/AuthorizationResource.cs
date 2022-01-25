using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthorizationManagement
{
    /// <summary>
    /// One or more resources that the resource server manages as a set of protected resources.
    /// For more details, See <a href="https://docs.kantarainitiative.org/uma/draft-oauth-resource-reg.html#rfc.section.2.2">OAuth-resource-reg</a>. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/ResourceRepresentation.html
    /// </summary>
    public class AuthorizationResource
    {
        [JsonProperty("_id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("owner")]
        public AuthorizationOwner? Owner { get; set; }

        [JsonProperty("ownerManagedAccess")]
        public bool OwnerManagedAccess { get; set; }

        [JsonProperty("attributes")]
        public Dictionary<string, IEnumerable<string>>? Attributes { get; set; }

        [JsonProperty("uris")]
        public IEnumerable<string>? Uris { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<AuthorizationScope>? Scopes { get; set; }
    }
}
