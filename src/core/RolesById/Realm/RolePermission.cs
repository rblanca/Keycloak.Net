using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/roles-by-id/{role-id}/management/permissions <br/>
        /// Return object stating whether role Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        public async Task<ManagementPermission> GetRoleAuthorizationPermissionsInitializedByIdAsync(string realm,
            string roleId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/management/permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/roles-by-id/{role-id}/management/permissions <br/>
        /// Return object stating whether role Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleId">id of role</param>
        /// <param name="managementPermission"></param>
        public async Task<ManagementPermission> SetRoleAuthorizationPermissionsInitializedByIdAsync(string realm,
            string roleId, ManagementPermission managementPermission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);

            return response;
        }
    }
}
