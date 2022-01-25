using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage client-level roles. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/roles <br/>
        /// Create a new client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="role"></param>
        public async Task<bool> CreateClientRoleAsync(string realm, string clientId, Role role)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles")
                .PostJsonAsync(role)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles <br/>
        /// Get all roles for the specified client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="briefRepresentation"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="search"></param>
        public async Task<IEnumerable<Role>> GetClientRolesAsync(
            string realm,
            string clientId,
            bool? briefRepresentation = null,
            int? first = null,
            int? max = null,
            string? search = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(briefRepresentation)] = briefRepresentation,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(search)] = search
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles/{roleName} <br/>
        /// Get a client role by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<Role> GetClientRoleByNameAsync(string realm, string clientId, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}")
                .GetJsonAsync<Role>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/roles/{roleName} <br/>
        /// Update a client role by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="role"></param>
        public async Task<bool> UpdateClientRoleByNameAsync(
            string realm,
            string clientId,
            string roleName,
            Role role)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}")
                .PutJsonAsync(role)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/roles/{roleName} <br/>
        /// Delete a client role by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<bool> DeleteClientRoleByNameAsync(string realm, string clientId, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clients/{clientId}/roles/{roleName}/composites <br/>
        /// Add child roles to this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="roles">child roles to be added</param>
        public async Task<bool> AddCompositeRolesByNameAsync(string realm, string clientId, string roleName,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/composites")
                .PostJsonAsync(roles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles/{roleName}/composites <br/>
        /// Get child roles for this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName"></param>
        public async Task<IEnumerable<Role>> GetCompositeRolesByNameAsync(string realm, string clientId, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/composites")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles/{roleName}/composites/realm <br/>
        /// Get realm-level child roles for this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<IEnumerable<Role>> GetCompositeRealmRolesByNameAsync(string realm, string clientId, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/composites/realm")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles/{roleName}/composites/clients/{refClientId} <br/>
        /// Get client-level child roles for this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="refClientId">id of referenced client (not client-id)</param>
        public async Task<IEnumerable<Role>> GetCompositeClientRolesByNameAsync(
            string realm,
            string clientId,
            string roleName,
            string refClientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/composites/clients/{refClientId}")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/roles/{roleName}/composites <br/>
        /// Remove child roles from this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="roles">roles to remove</param>
        public async Task<bool> RemoveCompositeRolesByNameAsync(
            string realm,
            string clientId,
            string roleName,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/composites")
                .SendJsonAsync(HttpMethod.Delete, roles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
