using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage realm-level roles. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/roles <br/>
        /// Create a new role in this realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="role"></param>
        public async Task<bool> CreateRoleAsync(string realm, Role role)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles")
                .PostJsonAsync(role)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/roles <br/>
        /// Get all roles in this realm.
        /// </summary>
        public async Task<IEnumerable<Role>?> GetRolesAsync(
            string realm,
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
                .AppendPathSegment($"/admin/realms/{realm}/roles")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/roles/{roleName} <br/>
        /// Get a specific role's representation in this realm by name.
        /// </summary>
        public async Task<Role> GetRoleByNameAsync(string realm, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}")
                .GetJsonAsync<Role>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/roles/{roleName} <br/>
        /// Update a role in this realm by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="role"></param>
        public async Task<bool> UpdateRoleByNameAsync(string realm, string roleName, Role role)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}")
                .PutJsonAsync(role)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/roles/{roleName} <br/>
        /// Delete a role in this realm by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<bool> DeleteRoleByNameAsync(string realm, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/roles/{roleName}/composites <br/>
        /// Make the role a composite role by associating some child roles.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="roles">child roles to be added</param>
        public async Task<bool> AddCompositeRolesByNameAsync(string realm, string roleName, IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/composites")
                .PostJsonAsync(roles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/roles/{roleName}/composites <br/>
        /// Get child roles of this role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<IEnumerable<Role>> GetCompositeRolesByNameAsync(string realm, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/composites")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/roles/{roleName}/composites/realm <br/>
        /// Get realm-level child roles that are in the role's composite
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        public async Task<IEnumerable<Role>> GetCompositeRealmRolesByNameAsync(string realm, string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/composites/realm")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/roles/{roleName}/composites/clients/{refClientId} <br/>
        /// Get client-level child roles that are in the role's composite
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="refClientId">id of referenced client (not client-id)</param>
        public async Task<IEnumerable<Role>> GetCompositeClientRolesByNameAsync(string realm, string roleName, string refClientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/composites/clients/{refClientId}")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// DELETE /{realm}/roles/{roleName}/composites <br/>
        /// Remove a set of child roles from the role's composite by name.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">role's name (not id!)</param>
        /// <param name="roles">roles to remove</param>
        public async Task<bool> RemoveCompositeRolesByNameAsync(
            string realm,
            string roleName,
            IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/composites")
                .SendJsonAsync(HttpMethod.Delete, roles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
