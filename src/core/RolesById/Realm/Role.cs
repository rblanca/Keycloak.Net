using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Content;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/roles-by-id/{roleId} <br/>
        /// Get a specific role's representation in this realm by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        public async Task<Role> GetRoleByIdAsync(string realm, string roleId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
                .GetJsonAsync<Role>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/roles-by-id/{roleId} <br/>
        /// Update the role in this realm by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        /// <param name="role"></param>
        public async Task<bool> UpdateRoleByIdAsync(string realm, string roleId, Role role)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
                .PutJsonAsync(role)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/roles-by-id/{roleId} <br/>
        /// Delete the role in this realm by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        public async Task<bool> DeleteRoleByIdAsync(string realm, string roleId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/roles-by-id/{roleId}/composites <br/>
        /// Make the role a composite role by associating some child roles by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        /// <param name="roles">child roles to be added</param>
        public async Task<bool> AddCompositeRolesByIdAsync(string realm, string roleId, IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
                .PostJsonAsync(roles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/roles-by-id/{roleId}/composites <br/>
        /// Get child roles of this realm role by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        /// <returns>Returns a set of role's children provided the role is a composite.</returns>
        public async Task<IEnumerable<Role>> GetCompositeRolesByIdAsync(string realm, string roleId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/roles-by-id/{roleId}/composites/realm <br/>
        /// Get realm-level roles that are in the role's composite
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        public async Task<IEnumerable<Role>> GetCompositeRealmRolesByIdAsync(string realm, string roleId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites/realm")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/roles-by-id/{roleId}/composites/clients/{refClientId} <br/>
        /// Get client-level child roles for the client that are in the role's composite
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        /// <param name="refClientId">id of referenced client (not client-id)</param>
        public async Task<IEnumerable<Role>> GetCompositeClientRolesByIdAsync(string realm, string roleId,
            string refClientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites/clients/{refClientId}")
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// DELETE /{realm}/roles-by-id/{roleId}/composites <br/>
        /// Remove a set of child roles from the role's composite by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">Role id</param>
        /// <param name="roles">A set of roles to be removed</param>
        public async Task<bool> RemoveCompositeRolesByIdAsync(string realm, string roleId, IEnumerable<Role> roles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
                .SendJsonAsync(HttpMethod.Delete, new CapturedJsonContent(_serializer.Serialize(roles)))
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
