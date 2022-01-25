using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_identityproviderrepresentation
    /// </summary>
    public class IdentityProvider
    {
        [JsonProperty("addReadTokenRoleOnCreate")]
        public bool? AddReadTokenRoleOnCreate { get; set; }

        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("authenticateByDefault")]
        public bool? AuthenticateByDefault { get; set; }

        [JsonProperty("config")]
        public IdentityProviderConfig? Config { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("firstBrokerLoginFlowAlias")]
        public string? FirstBrokerLoginFlowAlias { get; set; }

        [JsonProperty("internalId")]
        public string? InternalId { get; set; }

        [JsonProperty("linkOnly")]
        public bool? LinkOnly { get; set; }

        [JsonProperty("postBrokerLoginFlowAlias")]
        public string? PostBrokerLoginFlowAlias { get; set; }

        [JsonProperty("providerId")]
        public string? ProviderId { get; set; }

        [JsonProperty("storeToken")]
        public bool? StoreToken { get; set; }

        [JsonProperty("trustEmail")]
        public bool? TrustEmail { get; set; }

        [JsonProperty("updateProfileFirstLoginMode")]
        public string? UpdateProfileFirstLoginMode { get; set; }
    }
}