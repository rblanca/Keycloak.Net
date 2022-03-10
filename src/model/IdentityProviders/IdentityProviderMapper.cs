using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_identityprovidermapperrepresentation
    /// </summary>
    public class IdentityProviderMapper
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("identityProviderAlias")]
        public string? IdentityProviderAlias { get; set; }

        [JsonProperty("identityProviderMapper")]
        public IdentityProviderMapperType MapperType { get; set; }

        /// <inheritdoc cref="IdentityProviderMapperConfig"/>
        [JsonProperty("config")]
        public IdentityProviderMapperConfig? Config { get; set; }
    }
}
