using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_groups_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/groups/{id}/management/permissions <br/>
        /// Return object stating whether client authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        public async Task<ManagementPermission> GetGroupClientAuthorizationPermissionsInitializedAsync(
            string realm,
            string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/groups/{id}/management/permissions <br/>
        /// Return object stating whether client authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="managementPermission"></param>
        public async Task<ManagementPermission> SetGroupClientAuthorizationPermissionsInitializedAsync(
            string realm,
            string groupId,
            ManagementPermission managementPermission) =>
            await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);

    }
}
