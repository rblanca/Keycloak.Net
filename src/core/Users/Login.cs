using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_users_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/users/{userId}/consents <br/>
        /// Get consents granted by the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<string> GetUserConsentsAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents")
                .GetStringAsync()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId}/consents/{clientId} <br/>
        /// Revoke consent and offline tokens for particular client from user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId">client id</param>
        public async Task<bool> RevokeUserConsentAndOfflineTokensAsync(string realm, string userId, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents/{clientId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/federated-identity <br/>
        /// Get social logins associated with the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<IEnumerable<FederatedIdentity>?> GetUserSocialLoginsAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity")
                .GetJsonAsync<IEnumerable<FederatedIdentity>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/users/{userId}/federated-identity/{provider} <br/>
        /// Add a social login provider to the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="provider">Social login provider id</param>
        /// <param name="federatedIdentity"></param>
        public async Task<bool> AddUserSocialLoginProviderAsync(
            string realm,
            string userId,
            string provider,
            FederatedIdentity federatedIdentity)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
                .PostJsonAsync(federatedIdentity)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId}/federated-identity/{provider} <br/>
        /// Remove a social login provider from user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="provider">Social login provider id</param>
        public async Task<bool> RemoveUserSocialLoginProviderAsync(string realm, string userId, string provider)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/users/{userId}/impersonation <br/>
        /// Login as this user. If user is in same realm as you, your current login session will be logged out before you are logged in as this user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<IDictionary<string, object>> ImpersonateUserAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/impersonation")
                .PostAsync(new StringContent(""))
                .ReceiveJson<IDictionary<string, object>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/users/{userId}/logout <br/>
        /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<bool> RemoveUserSessionsAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/logout")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/offline-sessions/{clientId} <br/>
        /// Get offline sessions associated with the user and client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId">client id</param>
        public async Task<IEnumerable<UserSession>?> GetUserOfflineSessionsAsync(string realm, string userId, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/offline-sessions/{clientId}")
                .GetJsonAsync<IEnumerable<UserSession>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/{id}/sessions <br/>
        /// Get sessions associated with the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<IEnumerable<UserSession>?> GetUserSessionsAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/sessions")
                .GetJsonAsync<IEnumerable<UserSession>>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
