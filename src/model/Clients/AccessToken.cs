using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken
    /// </summary>
    public class AccessToken : IdToken
    {
        [JsonProperty("allowed-origins")]
        public IEnumerable<string>? AllowedOrigins { get; set; }

        /// <inheritdoc cref="IdToken.Aud"/>
        [JsonProperty("aud")]
        public new IEnumerable<string>? Aud { get; set; }

        [JsonProperty("authorization")]
        public AccessTokenAuthorization? Authorization { get; set; }
        
        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/cnf">Cnf</a> is the Confirmation Claim within JSON Web Token Claims.
        /// </summary>
        [JsonProperty("cnf")]
        public AccessTokenCertConf? Cnf { get; set; }

        /// <summary>
        /// Keycloak's custom claim used to define information about user access in this realm.
        /// </summary>
        [JsonProperty("realm_access")]
        public AccessTokenAccess? RealmAccess { get; set; }

        [JsonProperty("resource_access")]
        public IDictionary<string, AccessTokenAccess>? ResourceAccess { get; set; }

        /// <summary>
        /// The <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">scopes</a> associated with Access Tokens determine what resources will be available when they are used to access OAuth 2.0 protected endpoints.
        /// Protected Resource endpoints MAY perform different actions and return different information based on the scope values and other parameters used when requesting the presented Access Token.
        /// </summary>
        [JsonProperty("scope")]
        public string? Scope { get; set; }

        [JsonProperty("trusted-certs")]
        public IEnumerable<string>? TrustedCerts { get; set; }
    }
}
