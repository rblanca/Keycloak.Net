using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage user credentials. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_users_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/users/{userId}/configured-user-storage-credential-types <br/>
        /// Return credential types, which are provided by the user storage where user is stored.
        /// </summary>
        /// <remarks>
        /// Returned values can contain for example "password", "otp" etc. This will always return empty list for "local" users, which are not backed by any user storage
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<string> GetUserCredentialTypesAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/configured-user-storage-credential-types")
                .GetStringAsync()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/credentials <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<IEnumerable<Credential>?> GetUserCredentials(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials")
                .GetJsonAsync<IEnumerable<Credential>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId}/credentials/{credentialId}
        /// Remove a credential for a user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="credentialId"></param>
        public async Task<bool> DeleteUserCredential(string realm, string userId, string credentialId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/users/{userId}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId} <br/>
        /// Move a credential to a position behind another credential.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="credentialId">The credential to move</param>
        /// <param name="newPreviousCredentialId">The credential that will be the previous element in the list. If set to null, the moved credential will be the first element in the list.</param>
        public async Task<bool> MoveUserCredentialToBehind(string realm, string userId, string credentialId, string newPreviousCredentialId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}")
                .PostAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/users/{userId}/credentials/{credentialId}/moveToFirst <br/>
        /// Move a credential to a first position in the credentials list of the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="credentialId">The credential to move</param>
        public async Task<bool> MoveUserCredentialToFirst(string realm, string userId, string credentialId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}/moveToFirst")
                .PostAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/credentials/{credentialId}/userLabel <br/>
        /// Update a credential label for a user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="credentialId"></param>
        /// <param name="userLabel"></param>
        public async Task<bool> UpdateUserCredentialLabel(
            string realm,
            string userId,
            string credentialId,
            string userLabel)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}/userLabel")
                .PutStringAsync(userLabel)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/disable-credential-types <br/>
        /// Disable all credentials for a user of a specific type.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="credentialTypes"></param>
        public async Task<bool> DisableUserCredentialsAsync(string realm, string userId, IEnumerable<string> credentialTypes)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/disable-credential-types")
                .PutJsonAsync(credentialTypes)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/reset-password <br/> 
        /// Set up a new password for the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="cred">The representation must contain a rawPassword with the plain-text password</param>
        public async Task<bool> ResetUserPasswordAsync(string realm, string userId, Credential cred)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/reset-password")
                .PutJsonAsync(cred)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
