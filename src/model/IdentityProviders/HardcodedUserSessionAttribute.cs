using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/provider/HardcodedUserSessionAttributeMapper.html
    /// </summary>
    public class HardcodedUserSessionAttribute : IdentityProviderMapperConfig
    {
        /// <summary>
        /// Name of user session attribute you want to hardcode.
        /// </summary>
        [JsonProperty("attribute")]
        public string? Attribute { get; set; }

        /// <summary>
        /// Value you want to hardcode.
        /// </summary>
        [JsonProperty("attribute.value")]
        public string? AttributeValue { get; set; }
    }
}
