using System;
using Flurl;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Authentication
{
    /// <summary>
    /// The openid discovery endpoint that exposes the known authentication endpoints. <br/>
    /// See https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata
    /// </summary>
    public class OpenIdConfiguration : IMtlsEndpoint
    {
        /// <summary>
        /// REQUIRED. URL using the https scheme with no query or fragment component that the OP asserts as its Issuer Identifier. If Issuer discovery is supported, this value MUST be identical to the issuer value returned by WebFinger.
        /// This also MUST be identical to the iss Claim value in ID Tokens issued from this Issuer.
        /// </summary>
        [JsonProperty("issuer")]
        public Uri? Issuer { get; set; }

        /// <summary>
        /// REQUIRED. Discover the OAuth 2.0/OpenID Connect endpoints, capabilities, supported cryptographic algorithms and features.
        /// </summary>
        [JsonProperty("discovery_endpoint")]
        public Uri? DiscoveryEndpoint => new Uri(Url.Combine(Issuer!.AbsoluteUri, ".well-known/openid-configuration"));

        /// <summary>
        /// REQUIRED. URL of the OP's OAuth 2.0 <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">Authorization Endpoint</a>. The authorization endpoint is used to
        /// interact with the resource owner and obtain an authorization grant.
        /// </summary>
        [JsonProperty("authorization_endpoint")]
        public Uri? AuthorizationEndpoint { get; set; }

        /// <summary>
        /// OPTIONAL. URL of the OP's OAuth 2.0 <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">Token Endpoint</a>.
        /// Post an OAuth 2.0 grant (code, refresh token, resource owner password credentials, client credentials) to obtain an ID and / or access token.
        /// This is REQUIRED unless only the Implicit Flow is used.
        /// </summary>
        [JsonProperty("token_endpoint")]
        public Uri? TokenEndpoint { get; set; }

        /// <summary>
        /// Validate an access token and retrieve its underlying authorization (for resource servers).
        /// </summary>
        [JsonProperty("introspection_endpoint")]
        public Uri? IntrospectionEndpoint { get; set; }

        /// <summary>
        /// RECOMMENDED. URL of the OP's <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">UserInfo Endpoint</a>. This URL MUST use the https scheme and MAY contain port, path, and query parameter components.
        /// </summary>
        [JsonProperty("userinfo_endpoint")]
        public Uri? UserinfoEndpoint { get; set; }

        /// <summary>
        /// Sign out an end-user.
        /// </summary>
        [JsonProperty("end_session_endpoint")]
        public Uri? EndSessionEndpoint { get; set; }

        /// <summary>
        /// REQUIRED. Retrieve the public server <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWK">JSON Web Key Set [JWK]</a> to verify the signature of an issued token or to encrypt request objects to it.
        /// </summary>
        [JsonProperty("jwks_uri")]
        public Uri? JwksUri { get; set; }

        /// <summary>
        /// Poll the OpenID provider for changes of end-user authentication status.
        /// </summary>
        [JsonProperty("check_session_iframe")]
        public Uri? CheckSessionIframe { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the OAuth 2.0 Grant Type values that this OP supports.
        /// Dynamic OpenID Providers MUST support the <c>authorization_code</c> and <c>implicit</c> Grant Type values and MAY support other Grant Types.
        /// </summary>
        /// <example>["authorization_code", "implicit"]</example>
        [JsonProperty("grant_types_supported")]
        public string[]? GrantTypesSupported { get; set; }

        /// <summary>
        /// REQUIRED. JSON array containing a list of the OAuth 2.0 <c>response_type</c> values that this OP supports. Dynamic OpenID Providers MUST support the <c>code</c>, <c>id_token</c>, and the <c>token id_token</c> Response Type values.
        /// </summary>
        [JsonProperty("response_types_supported")]
        public string[]? ResponseTypesSupported { get; set; }

        /// <summary>
        /// REQUIRED. JSON array containing a list of the Subject Identifier types that this OP supports. Valid types include <c>pairwise</c> and <c>public</c>.
        /// </summary>
        [JsonProperty("subject_types_supported")]
        public string[]? SubjectTypesSupported { get; set; }

        /// <summary>
        /// REQUIRED. JSON array containing a list of the JWS signing algorithms (<c>alg</c> values) supported by the OP for the ID Token to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// The algorithm <c>RS256</c> MUST be included. The value <c>none</c> MAY be supported, but MUST NOT be used unless the Response Type used returns no ID Token from the Authorization Endpoint (such as when using the Authorization Code Flow).
        /// </summary>
        [JsonProperty("id_token_signing_alg_values_supported")]
        public string[]? IdTokenSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWE encryption algorithms (<c>alg</c> values) supported by the OP for the ID Token to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// </summary>
        [JsonProperty("id_token_encryption_alg_values_supported")]
        public string[]? IdTokenEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWE encryption algorithms (<c>enc</c> values) supported by the OP for the ID Token to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// </summary>
        [JsonProperty("id_token_encryption_enc_values_supported")]
        public string[]? IdTokenEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWS">[JWS]</a> signing algorithms (<c>alg</c> values)
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWA">[JWA]</a> supported by the UserInfo Endpoint to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// The value <c>none</c> MAY be included.
        /// </summary>
        [JsonProperty("userinfo_signing_alg_values_supported")]
        public string[]? UserinfoSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWE">[JWE]</a> encryption algorithms (<c>alg</c> values)
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWA">[JWA]</a> supported by the UserInfo Endpoint to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// </summary>
        [JsonProperty("userinfo_encryption_alg_values_supported")]
        public string[]? UserinfoEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWE encryption algorithms (<c>enc</c> values)
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWA">[JWA]</a> supported by the UserInfo Endpoint to encode the Claims in a <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a>.
        /// </summary>
        [JsonProperty("userinfo_encryption_enc_values_supported")]
        public string[]? UserinfoEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWS signing algorithms (<c>alg</c> values) supported by the OP for Request Objects,
        /// which are described in Section 6.1 of <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">OpenID Connect Core 1.0 [OpenID.Core]</a>.
        /// These algorithms are used both when the Request Object is passed by value (using the <c>request</c> parameter) and when it is passed by reference (using the <c>request_uri</c> parameter). Servers SHOULD support <c>none</c> and <c>RS256</c>.
        /// </summary>
        [JsonProperty("request_object_signing_alg_values_supported")]
        public string[]? RequestObjectSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWE encryption algorithms (<c>alg</c> values) supported by the OP for Request Objects.
        /// These algorithms are used both when the Request Object is passed by value and when it is passed by reference.
        /// </summary>
        [JsonProperty("request_object_encryption_alg_values_supported")]
        public string[]? RequestObjectEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWE encryption algorithms (<c>enc</c> values) supported by the OP for Request Objects. These algorithms are used both when the Request Object is passed by value and when it is passed by reference.
        /// </summary>
        [JsonProperty("request_object_encryption_enc_values_supported")]
        public string[]? RequestObjectEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the OAuth 2.0 <c>response_mode</c> values that this OP supports,
        /// as specified in <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OAuth.Responses">OAuth 2.0 Multiple Response Type Encoding Practices [OAuth.Responses]</a>. 
        /// </summary>
        /// <example>["query", "fragment"]</example>
        [JsonProperty("response_modes_supported")]
        public string[]? ResponseModesSupported { get; set; }

        /// <summary>
        /// RECOMMENDED. URL of the OP's Dynamic <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Registration">Client Registration Endpoint</a>.
        /// </summary>
        [JsonProperty("registration_endpoint")]
        public Uri? RegistrationEndpoint { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of Client Authentication methods supported by this Token Endpoint.
        /// The options are <c>client_secret_post</c>, <c>client_secret_basic</c>, <c>client_secret_jwt</c>, and <c>private_key_jwt</c>,
        /// as described in Section 9 of <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">OpenID Connect Core 1.0 [OpenID.Core]</a>.
        /// Other authentication methods MAY be defined by extensions. If omitted, the default is <c>client_secret_basic</c> --
        /// the HTTP Basic Authentication Scheme specified in Section 2.3.1 of <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#RFC6749">OAuth 2.0</a>.
        /// </summary>
        [JsonProperty("token_endpoint_auth_methods_supported")]
        public string[]? TokenEndpointAuthMethodsSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the JWS signing algorithms (<c>alg</c> values) supported by the Token Endpoint for the signature on the
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWT">JWT</a> used to authenticate the Client at the Token Endpoint for the <c>private_key_jwt</c> and <c>client_secret_jwt</c> authentication methods.
        /// Servers SHOULD support <c>RS256</c>. The value <c>none</c> MUST NOT be used.
        /// </summary>
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

        /// <summary>
        /// RECOMMENDED. JSON array containing a list of the Claim Names of the Claims that the OpenID Provider MAY be able to supply values for. Note that for privacy or other reasons, this might not be an exhaustive list.
        /// </summary>
        [JsonProperty("claims_supported")]
        public string[]? ClaimsSupported { get; set; }

        /// <summary>
        /// OPTIONAL. JSON array containing a list of the Claim Types that the OpenID Provider supports. These Claim Types are described in Section 5.6 of <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">OpenID.Core</a>.
        /// Values defined by this specification are <c>normal</c>, <c>aggregated</c>, and <c>distributed</c>. If omitted, the implementation supports only <c>normal</c> Claims.
        /// </summary>
        [JsonProperty("claim_types_supported")]
        public string[]? ClaimTypesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. Boolean value specifying whether the OP supports use of the claims parameter, with <c>true</c> indicating support. If omitted, the default value is <c>false</c>.
        /// </summary>
        [JsonProperty("claims_parameter_supported")]
        public bool ClaimsParameterSupported { get; set; }

        /// <summary>
        /// RECOMMENDED. JSON array containing a list of the <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#RFC6749">OAuth 2.0 [RFC6749]</a> scope values that this server supports.
        /// The server MUST support the <c>openid</c> scope value. Servers MAY choose not to advertise some supported scope values even when this parameter is used,
        /// although those defined in <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">OpenID.Core</a> SHOULD be listed, if supported.
        /// </summary>
        [JsonProperty("scopes_supported")]
        public string[]? ScopesSupported { get; set; }

        /// <summary>
        /// OPTIONAL. Boolean value specifying whether the OP supports use of the <c>request</c> parameter, with <c>true</c> indicating support. If omitted, the default value is <c>false</c>.
        /// </summary>
        [JsonProperty("request_parameter_supported")]
        public bool RequestParameterSupported { get; set; }

        /// <summary>
        /// OPTIONAL. Boolean value specifying whether the OP supports use of the <c>request_uri</c> parameter, with <c>true</c> indicating support. If omitted, the default value is <c>true</c>.
        /// </summary>
        [JsonProperty("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; }

        /// <summary>
        /// OPTIONAL. Boolean value specifying whether the OP requires any <c>request_uri</c> values used to be pre-registered using the <c>request_uris</c> registration parameter.
        /// Pre-registration is REQUIRED when the value is <c>true</c>. If omitted, the default value is <c>false</c>.
        /// </summary>
        [JsonProperty("require_request_uri_registration")]
        public bool RequireRequestUriRegistration { get; set; }

        [JsonProperty("code_challenge_methods_supported")]
        public string[]? CodeChallengeMethodsSupported { get; set; }

        [JsonProperty("tls_client_certificate_bound_access_tokens")]
        public bool TlsClientCertificateBoundAccessTokens { get; set; }

        /// <summary>
        /// Revoke an obtained access or refresh token.
        /// </summary>
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
