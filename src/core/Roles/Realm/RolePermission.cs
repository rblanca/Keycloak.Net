using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage realm-level role permissions. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/roles/{roleName}/management/permissions <br/>
        /// Returns an object stating whether role authorization permissions have been initialized or not for this realm role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">the role name.</param>
        public async Task<ManagementPermission> GetRoleAuthorizationPermissionsInitializedByNameAsync(
            string realm,
            string roleName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/management/permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/roles/{roleName}/management/permissions <br/>
        /// Return an object stating whether role authorization permissions have been initialized or not for this realm role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">the role name.</param>
        /// <param name="managementPermission"></param>
        public async Task<ManagementPermission> SetRoleAuthorizationPermissionsInitializedByNameAsync(
            string realm,
            string roleName,
            ManagementPermission managementPermission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);

            return response;
        }
    }
}
