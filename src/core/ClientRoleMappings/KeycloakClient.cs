using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        #region Group-Role Mappings

        /// <summary>
        /// POST /{realm}/groups/{groupId}/role-mappings/clients/{clientId} <br/>
        /// Add client-level roles to the group role mapping.
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="groupId"></param>
        /// <param name="clientId">realm name (not id!)</param>
        /// <param name="roles"></param>
        public async Task<bool> AddClientRoleMappingsToGroupAsync(
            string realm, 
            string groupId, 
            string clientId,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
                .PostJsonAsync(roles)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/groups/{groupId}/role-mappings/clients/{clientId}
        /// Get client-level role mappings for the group, and the app.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="clientId"></param>
        public async Task<IEnumerable<Role>> GetClientRoleMappingsForGroupAsync(string realm, string groupId,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/groups/{groupId}/role-mappings/clients/{clientId} <br/>
        /// Delete client-level roles from group role mapping.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="clientId"></param>
        /// <param name="roles"></param>
        public async Task<bool> DeleteClientRoleMappingsFromGroupAsync(
            string realm, 
            string groupId, 
            string clientId,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
                .SendJsonAsync(HttpMethod.Delete, roles)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/groups/{groupId}/role-mappings/clients/{clientId}/available <br/>
        /// Get available client-level roles that can be mapped to the group.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="clientId"></param>
        public async Task<IEnumerable<Role>> GetAvailableClientRoleMappingsForGroupAsync(
            string realm, 
            string groupId,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}/available")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/groups/{groupId}/role-mappings/clients/{clientId}/composite <br/>
        /// Get effective client-level role mappings for group. This include any composite roles.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="clientId"></param>
        /// <param name="briefRepresentation">if false, return roles with their attributes</param>
        public async Task<IEnumerable<Role>> GetEffectiveClientRoleMappingsForGroupAsync(
            string realm,
            string groupId,
            string clientId,
            bool? briefRepresentation = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(briefRepresentation)] = briefRepresentation
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}/composite")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        #endregion

        #region User-Role Mappings

        /// <summary>
        /// POST /{realm}/users/{userId}/role-mappings/clients/{clientId} <br/>
        /// Add client-level roles to the user role mapping.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId"></param>
        /// <param name="roles"></param>
        public async Task<bool> AddClientRoleMappingsToUserAsync(string realm, string userId, string clientId,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
                .PostJsonAsync(roles)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/role-mappings/clients/{clientId}
        /// Get client-level role mappings for the user, and the app.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId"></param>
        public async Task<IEnumerable<Role>> GetClientRoleMappingsForUserAsync(string realm, string userId,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId}/role-mappings/clients/{clientId} <br/>
        /// Delete client-level roles from user role mapping.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId"></param>
        /// <param name="roles"></param>
        public async Task<bool> DeleteClientRoleMappingsFromUserAsync(string realm, string userId, string clientId,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
                .SendJsonAsync(HttpMethod.Delete, roles)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/role-mappings/clients/{clientId}/available <br/>
        /// Get available client-level roles that can be mapped to the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        public async Task<IEnumerable<Role>> GetAvailableClientRoleMappingsForUserAsync(string realm, string userId,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}/available")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/role-mappings/clients/{clientId}/composite <br/>
        /// Get effective client-level role mappings. This include any composite roles.
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        public async Task<IEnumerable<Role>> GetEffectiveClientRoleMappingsForUserAsync(string realm, string userId,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}/composite")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

        #endregion
    }
}