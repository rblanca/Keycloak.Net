using Newtonsoft.Json;

namespace Keycloak.Net.Model.ProtocolMappers
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_protocolmapperrepresentation
    /// </summary>
    public class ProtocolConfig
    {
        [JsonProperty("access.token.claim")]
        public bool AccessTokenClaim { get; set; }

        [JsonProperty("access.tokenResponse.claim")]
        public bool AccessTokenResponseClaim { get; set; }

        [JsonProperty("attribute.name")]
        public string AttributeName { get; set; } = null!;

        [JsonProperty("attribute.nameformat")]
        public string AttributeNameFormat { get; set; } = null!;

        [JsonProperty("claim.name")]
        public string ClaimName { get; set; } = null!;

        [JsonProperty("claim.value")]
        public string ClaimValue { get; set; } = null!;

        [JsonProperty("friendly.name")]
        public string FriendlyName { get; set; } = null!;

        [JsonProperty("id.token.claim")]
        public bool IdTokenClaim { get; set; }

        [JsonProperty("jsonType.label")]
        public string JsonTypelabel { get; set; } = null!;

        [JsonProperty("multivalued")]
        public bool Multivalued { get; set; }

        [JsonProperty("single")]
        public bool Single { get; set; }

        [JsonProperty("user.attribute")]
        public string UserAttribute { get; set; } = null!;

        [JsonProperty("user.attribute.formatted")]
        public string UserAttributeFormatted { get; set; } = null!;

        [JsonProperty("user.attribute.country")]
        public string UserAttributeCountry { get; set; } = null!;

        [JsonProperty("user.attribute.postal_code")]
        public string UserAttributePostalCode { get; set; } = null!;

        [JsonProperty("user.attribute.street")]
        public string UserAttributeStreet { get; set; } = null!;

        [JsonProperty("user.attribute.region")]
        public string UserAttributeRegion { get; set; } = null!;

        [JsonProperty("user.attribute.locality")]
        public string UserAttributeLocality { get; set; } = null!;

        [JsonProperty("user.session.note")]
        public string UserSessionNote { get; set; } = null!;

        [JsonProperty("role")]
        public string Role { get; set; } = null!;

        [JsonProperty("new.role.name")]
        public string NewRoleName { get; set; } = null!;         

        [JsonProperty("included.client.audience")]
        public string IncludedClientAudience { get; set; } = null!;
        
        [JsonProperty("included.custom.audience")]
        public string IncludedCustomAudience { get; set; } = null!;

        [JsonProperty("userinfo.token.claim")]
        public bool UserInfoTokenClaim { get; set; }
    }
}