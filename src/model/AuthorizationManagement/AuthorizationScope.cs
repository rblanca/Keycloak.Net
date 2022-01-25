using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthorizationManagement
{
    /// <summary>
    /// A bounded extent of access that is possible to perform on a resource set. In authorization policy terminology, a scope is one of the potentially many "verbs" that can logically apply to a resource set ("object").
    /// For more details, See <a href="https://docs.kantarainitiative.org/uma/draft-oauth-resource-reg.html#rfc.section.2.1">OAuth-resource-reg</a>. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/ScopeRepresentation.html
    /// </summary>
    public class AuthorizationScope
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
