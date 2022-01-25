using System;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class MtlsEndpoint : IMtlsEndpoint
    {
        [JsonProperty("authorization_endpoint")]
        public Uri? AuthorizationEndpoint { get; set; }

        [JsonProperty("token_endpoint")]
        public Uri? TokenEndpoint { get; set; }

        [JsonProperty("revocation_endpoint")]
        public Uri? RevocationEndpoint { get; set; }

        [JsonProperty("introspection_endpoint")]
        public Uri? IntrospectionEndpoint { get; set; }

        [JsonProperty("device_authorization_endpoint")]
        public Uri? DeviceAuthorizationEndpoint { get; set; }

        [JsonProperty("registration_endpoint")]
        public Uri? RegistrationEndpoint { get; set; }

        [JsonProperty("userinfo_endpoint")]
        public Uri? UserinfoEndpoint { get; set; }

        [JsonProperty("pushed_authorization_request_endpoint")]
        public string? PushedAuthorizationRequestEndpoint { get; set; }

        [JsonProperty("backchannel_authentication_endpoint")]
        public string? BackchannelAuthenticationEndpoint { get; set; }
    }
}
