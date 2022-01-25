using System;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// The User-Managed Access 2.0 discovery endpoint that exposes the known authentication endpoints. <br/>
    /// See https://docs.kantarainitiative.org/uma/wg/rec-oauth-uma-grant-2.0.html
    /// </summary>
    public class Uma2Configuration : IMtlsEndpoint
    {
        [JsonProperty("issuer")]
        public Uri? Issuer { get; set; }

        [JsonProperty("discovery_endpoint")]
        public Uri? DiscoveryEndpoint => new Uri(Issuer!, ".well-known/uma2-configuration");

        [JsonProperty("authorization_endpoint")]
        public Uri? AuthorizationEndpoint { get; set; }

        [JsonProperty("token_endpoint")]
        public Uri? TokenEndpoint { get; set; }

        [JsonProperty("introspection_endpoint")]
        public Uri? IntrospectionEndpoint { get; set; }
        
        [JsonProperty("end_session_endpoint")]
        public Uri? EndSessionEndpoint { get; set; }

        [JsonProperty("jwks_uri")]
        public Uri? JwksUri { get; set; }

        [JsonProperty("grant_types_supported")]
        public string[]? GrantTypesSupported { get; set; }

        [JsonProperty("response_types_supported")]
        public string[]? ResponseTypesSupported { get; set; }

        [JsonProperty("response_modes_supported")]
        public string[]? ResponseModesSupported { get; set; }

        [JsonProperty("registration_endpoint")]
        public Uri? RegistrationEndpoint { get; set; }

        [JsonProperty("token_endpoint_auth_methods_supported")]
        public string[]? TokenEndpointAuthMethodsSupported { get; set; }

        [JsonProperty("token_endpoint_auth_signing_alg_values_supported")]
        public string[]? TokenEndpointAuthSigningAlgValuesSupported { get; set; }

        [JsonProperty("scopes_supported")]
        public string[]? ScopesSupported { get; set; }

        [JsonProperty("resource_registration_endpoint")]
        public Uri? ResourceRegistrationEndpoint { get; set; }
        
        [JsonProperty("permission_endpoint")]
        public Uri? PermissionEndpoint { get; set; }

        [JsonProperty("policy_endpoint")] 
        public Uri? PolicyEndpoint { get; set; }
    }
}
