using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Authentication;
using Keycloak.Net.Model.IdentityProviders;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// Get <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">Open Connect Id</a> configurations.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<OpenIdConfiguration> GetOpenIdConfigurationAsync(string realm)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/.well-known/openid-configuration")
                .GetJsonAsync<OpenIdConfiguration>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Retrieve the public server <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#JWK">JSON Web Key Set [JWK]</a> to verify the signature of an issued token or to encrypt request objects to it.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<Jwks> GetJwksAsync(string realm)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/certs")
                .GetJsonAsync<Jwks>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Sign out an end-user for the current session.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> EndsessionAsync(string realm)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/logout")
                .GetAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get the <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#OpenID.Core">UserInfo</a> for the current session.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IDictionary<string, object?>> GetUserinfoAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/userinfo")
                .GetJsonAsync<IDictionary<string, object?>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Retrieve an access token via client credentials flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">the client id</param>
        /// <param name="clientSecret">the client secret</param>
        public async Task<IdentityProviderToken> GetClientCredentialsToken(
            string realm,
            string clientId,
            string clientSecret)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "client_credentials"),
                    new("client_id", clientId),
                    new("client_secret", clientSecret)
                })
                .ReceiveJson<IdentityProviderToken>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Retrieve an access token via password flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="username">the username</param>
        /// <param name="password">the password</param>
        /// <param name="clientId">the client to get token from.</param>
        public async Task<IdentityProviderToken> GetPasswordToken(
            string realm,
            string clientId,
            string username,
            string password)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "password"),
                    new("client_id", clientId),
                    new("username", username),
                    new("password", password),
                })
                .ReceiveJson<IdentityProviderToken>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
