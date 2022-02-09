using System;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Authentication
{
    /// <inheritdoc cref="IMtlsEndpoint"/>
    public class MtlsEndpoint : IMtlsEndpoint
    {
        /// <summary>
        /// The authorization endpoint
        /// </summary>
        [JsonProperty("authorization_endpoint")]
        public Uri? AuthorizationEndpoint { get; set; }

        /// <summary>
        /// The token endpoint
        /// </summary>
        [JsonProperty("token_endpoint")]
        public Uri? TokenEndpoint { get; set; }

        /// <summary>
        /// The revocation endpoint
        /// </summary>
        [JsonProperty("revocation_endpoint")]
        public Uri? RevocationEndpoint { get; set; }
        
        /// <summary>
        /// The introspection endpoint
        /// </summary>
        [JsonProperty("introspection_endpoint")]
        public Uri? IntrospectionEndpoint { get; set; }

        /// <summary>
        /// The device authorization endpoint
        /// </summary>
        [JsonProperty("device_authorization_endpoint")]
        public Uri? DeviceAuthorizationEndpoint { get; set; }

        /// <summary>
        /// The client registration endpoint
        /// </summary>
        [JsonProperty("registration_endpoint")]
        public Uri? RegistrationEndpoint { get; set; }

        /// <summary>
        /// The userinfo endpoint
        /// </summary>
        [JsonProperty("userinfo_endpoint")]
        public Uri? UserinfoEndpoint { get; set; }

        /// <summary>
        /// The pushed authorization request endpoint
        /// </summary>
        [JsonProperty("pushed_authorization_request_endpoint")]
        public string? PushedAuthorizationRequestEndpoint { get; set; }

        /// <summary>
        /// The backchannel authentication endpoint
        /// </summary>
        [JsonProperty("backchannel_authentication_endpoint")]
        public string? BackchannelAuthenticationEndpoint { get; set; }
    }
}
