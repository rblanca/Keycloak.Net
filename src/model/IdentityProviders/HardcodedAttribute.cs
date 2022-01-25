using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/provider/HardcodedAttributeMapper.html
    /// </summary>
    public class HardcodedAttribute : IdentityProviderMapperConfig
    {
        /// <summary>
        /// Name of user attribute you want to hardcode.
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
