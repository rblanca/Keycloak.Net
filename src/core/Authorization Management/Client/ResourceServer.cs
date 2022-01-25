using Flurl.Http;
using System.Threading.Tasks;
using Keycloak.Net.Model.AuthorizationManagement;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage authorization resource server for client. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_server_overview
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server <br/><br/>
        /// Get the client's authorization service resource server. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_server_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="permissionType"></param>
        /// <param name="permissionId"></param>
        public async Task<ResourceServer> GetAuthorizationResourceServerAsync(string realm, string clientId,
            AuthorizationPermissionType permissionType, string permissionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server")
                .GetJsonAsync<ResourceServer>()
                .ConfigureAwait(false);

            return response;
        }

    }
}
