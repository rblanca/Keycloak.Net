using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    public class IdentityProviderToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string RequestingPartyToken { get; set; }

        /// <summary>
        /// The token expiry time in milliseconds
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The refresh token expiry time in milliseconds
        /// </summary>
        [JsonProperty("refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("created_at")]
        public long? CreatedAt { get; set; }

        [JsonProperty("not-before-policy")]
        public int NotBeforePolicy { get; set; }
    }
}