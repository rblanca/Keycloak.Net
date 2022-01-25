using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/oidc/mappers/AbstractJsonUserAttributeMapper.html
    /// </summary>
    public class AttributeImporter : IdentityProviderMapperConfig
    {
        /// <summary>
        /// Path of field in Social provider User Profile JSON data to get value from.
        /// You can use dot notation for nesting and square brackets for array index. Eg. '<c>contact.address[0].country</c>'.
        /// </summary>
        [JsonProperty("jsonField")]
        public string? JsonField { get; set; }

        /// <summary>
        /// User attribute name to store information into.
        /// </summary>
        [JsonProperty("userAttribute")]
        public string? UserAttribute { get; set; }
    }
}
