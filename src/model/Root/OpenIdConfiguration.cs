using System;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// The openid discovery endpoint that exposes the known authentication endpoints. <br/>
    /// See https://openid.net/specs/openid-connect-discovery-1_0.html
    /// </summary>
    public class OpenIdConfiguration : IMtlsEndpoint
    {
        [JsonProperty("issuer")]
        public Uri? Issuer { get; set; }

        [JsonProperty("discovery_endpoint")]
        public Uri? DiscoveryEndpoint => new Uri(Issuer!, ".well-known/openid-configuration");
        
        [JsonProperty("authorization_endpoint")]
        public Uri? AuthorizationEndpoint { get; set; }

        [JsonProperty("token_endpoint")]
        public Uri? TokenEndpoint { get; set; }

        [JsonProperty("introspection_endpoint")]
        public Uri? IntrospectionEndpoint { get; set; }
        
        [JsonProperty("userinfo_endpoint")]
        public Uri? UserinfoEndpoint { get; set; }

        [JsonProperty("end_session_endpoint")]
        public Uri? EndSessionEndpoint { get; set; }

        [JsonProperty("jwks_uri")]
        public Uri? JwksUri { get; set; }

        [JsonProperty("check_session_iframe")]
        public Uri? CheckSessionIframe { get; set; }

        [JsonProperty("grant_types_supported")]
        public string[]? GrantTypesSupported { get; set; }

        [JsonProperty("response_types_supported")]
        public string[]? ResponseTypesSupported { get; set; }

        [JsonProperty("subject_types_supported")]
        public string[]? SubjectTypesSupported { get; set; }

        [JsonProperty("id_token_signing_alg_values_supported")]
        public string[]? IdTokenSigningAlgValuesSupported { get; set; }

        [JsonProperty("id_token_encryption_alg_values_supported")]
        public string[]? IdTokenEncryptionAlgValuesSupported { get; set; }

        [JsonProperty("id_token_encryption_enc_values_supported")]
        public string[]? IdTokenEncryptionEncValuesSupported { get; set; }

        [JsonProperty("userinfo_signing_alg_values_supported")]
        public string[]? UserinfoSigningAlgValuesSupported { get; set; }

        [JsonProperty("request_object_signing_alg_values_supported")]
        public string[]? RequestObjectSigningAlgValuesSupported { get; set; }

        [JsonProperty("request_object_encryption_alg_values_supported")]
        public string[]? RequestObjectEncryptionAlgValuesSupported { get; set; }

        [JsonProperty("request_object_encryption_enc_values_supported")]
        public string[]? RequestObjectEncryptionEncValuesSupported { get; set; }

        [JsonProperty("response_modes_supported")]
        public string[]? ResponseModesSupported { get; set; }

        [JsonProperty("registration_endpoint")]
        public Uri? RegistrationEndpoint { get; set; }

        [JsonProperty("token_endpoint_auth_methods_supported")]
        public string[]? TokenEndpointAuthMethodsSupported { get; set; }

        [JsonProperty("token_endpoint_auth_signing_alg_values_supported")]
        public string[]? TokenEndpointAuthSigningAlgValuesSupported { get; set; }

        [JsonProperty("introspection_endpoint_auth_methods_supported")]
        public string[]? IntrospectionEndpointAuthMethodsSupported { get; set; }

        [JsonProperty("introspection_endpoint_auth_signing_alg_values_supported")]
        public string[]? IntrospectionEndpointAuthSigningAlgValuesSupported { get; set; }

        [JsonProperty("authorization_signing_alg_values_supported")]
        public string[]? AuthorizationSigningAlgValuesSupported { get; set; }

        [JsonProperty("authorization_encryption_alg_values_supported")]
        public string[]? AuthorizationEncryptionAlgValuesSupported { get; set; }

        [JsonProperty("authorization_encryption_enc_values_supported")]
        public string[]? AuthorizationEncryptionEncValuesSupported { get; set; }

        [JsonProperty("claims_supported")]
        public string[]? ClaimsSupported { get; set; }

        [JsonProperty("claim_types_supported")]
        public string[]? ClaimTypesSupported { get; set; }

        [JsonProperty("claims_parameter_supported")]
        public bool ClaimsParameterSupported { get; set; }

        [JsonProperty("scopes_supported")]
        public string[]? ScopesSupported { get; set; }

        [JsonProperty("request_parameter_supported")]
        public bool RequestParameterSupported { get; set; }

        [JsonProperty("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; }

        [JsonProperty("require_request_uri_registration")]
        public bool RequireRequestUriRegistration { get; set; }

        [JsonProperty("code_challenge_methods_supported")]
        public string[]? CodeChallengeMethodsSupported { get; set; }

        [JsonProperty("tls_client_certificate_bound_access_tokens")]
        public bool TlsClientCertificateBoundAccessTokens { get; set; }

        [JsonProperty("revocation_endpoint")]
        public Uri? RevocationEndpoint { get; set; }

        [JsonProperty("revocation_endpoint_auth_methods_supported")]
        public string[]? RevocationEndpointAuthMethodsSupported { get; set; }

        [JsonProperty("revocation_endpoint_auth_signing_alg_values_supported")]
        public string[]? RevocationEndpointAuthSigningAlgValuesSupported { get; set; }

        [JsonProperty("backchannel_logout_supported")]
        public bool BackchannelLogoutSupported { get; set; }

        [JsonProperty("backchannel_logout_session_supported")]
        public bool BackchannelLogoutSessionSupported { get; set; }

        [JsonProperty("device_authorization_endpoint")]
        public Uri? DeviceAuthorizationEndpoint { get; set; }

        [JsonProperty("backchannel_token_delivery_modes_supported")]
        public string[]? BackchannelTokenDeliveryModesSupported { get; set; }

        [JsonProperty("backchannel_authentication_endpoint")]
        public string? BackchannelAuthenticationEndpoint { get; set; }

        [JsonProperty("backchannel_authentication_request_signing_alg_values_supported")]
        public string[]? BackchannelAuthenticationRequestSigningAlgValuesSupported { get; set; }

        [JsonProperty("require_pushed_authorization_requests")]
        public bool RequirePushedAuthorizationRequests { get; set; }

        [JsonProperty("pushed_authorization_request_endpoint")]
        public string? PushedAuthorizationRequestEndpoint { get; set; }

        [JsonProperty("mtls_endpoint_aliases")]
        public MtlsEndpoint? MtlsEndpointAliases { get; set; }
    }
}
