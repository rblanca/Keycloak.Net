using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Keycloak.Net.Shared.Extensions
{
    public static class FlurlRequestExtensions
    {
        #region Public
        
        /// <summary>
        /// Configures the request to use OAuth Bearer Token authentication
        /// </summary>
        public static IFlurlRequest WithAuthentication(this IFlurlRequest request, Func<string>? getToken, string url, string realm, string clientId, string userName, string password, string? clientSecret)
        {
            string token;

            if (getToken != null)
            {
                token = getToken();
            }
            else if (clientSecret != null)
            {
                token = GetAccessToken(url, realm, clientId, clientSecret);
            }
            else
            {
                token = GetAccessToken(url, realm, clientId, userName, password);
            }

            return request.WithOAuthBearerToken(token);
        }

        public static IFlurlRequest WithForwardedHttpHeaders(this IFlurlRequest request, ForwardedHttpHeaders? forwardedHeaders)
        {
            forwardedHeaders ??= new ForwardedHttpHeaders();
            request.WithHeader("X-Forwarded-For", forwardedHeaders.ForwardedFor)
                .WithHeader("X-Forwarded-Proto", forwardedHeaders.ForwardedProto)
                .WithHeader("X-Forwarded-Host", forwardedHeaders.ForwardedHost);
            
            return request;
        }

        #endregion

        #region Private

        /// <summary>
        /// Get access token via password flow.
        /// </summary>
        private static async Task<string> GetAccessTokenAsync(string url, string realm, string clientId, string userName, string password)
        {
            var result = await url
                .AppendPathSegment($"/auth/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Accept", "application/json")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "password"),
                    new("username", userName),
                    new("password", password),
                    new("client_id", clientId)
                })
                .ReceiveJson().ConfigureAwait(false);

            string accessToken = result
                .access_token.ToString();

            return accessToken;
        }

        /// <summary>
        /// Get access token via client credentials flow
        /// </summary>
        private static async Task<string> GetAccessTokenAsync(string url, string realm, string clientId, string clientSecret)
        {
            var result = await url
                .AppendPathSegment($"/auth/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "client_credentials"),
                    new("client_secret", clientSecret),
                    new("client_id", clientId)
                })
                .ReceiveJson().ConfigureAwait(false);

            string accessToken = result
                .access_token.ToString();

            return accessToken;
        }

        /// <inheritdoc cref="GetAccessTokenAsync(string,string,string,string,string)"/>
        private static string GetAccessToken(string url, string realm, string clientId, string userName, string password)
        {
            return GetAccessTokenAsync(url, realm, clientId, userName, password).GetAwaiter().GetResult();
        }

        /// <inheritdoc cref="GetAccessTokenAsync(string,string,string,string)"/>
        private static string GetAccessToken(string url, string realm, string clientId, string clientSecret)
        {
            return GetAccessTokenAsync(url, realm, clientId, clientSecret).GetAwaiter().GetResult();
        }


        #endregion
    }
}
