using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.Common;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clients_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/management/permissions <br/>
        /// Return object stating whether client Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<ManagementPermission?> GetClientAuthorizationPermissionsInitializedAsync(string realm,
            string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/management/permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/management/permissions <br/>
        /// Return object stating whether client Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="managementPermission"></param>
        public async Task<ManagementPermission?> SetClientAuthorizationPermissionsInitializedAsync(
            string realm,
            string clientId,
            ManagementPermission managementPermission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }
    }
}