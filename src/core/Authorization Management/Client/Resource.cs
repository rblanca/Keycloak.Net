using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.AuthorizationManagement;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage authorization resources for client. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/resource <br/><br/>
        /// Get the client's authorization service resource server's resources. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="deep"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="name"></param>
        /// <param name="owner"></param>
        /// <param name="type"></param>
        /// <param name="uri"></param>
        public async Task<IEnumerable<AuthorizationResource>> GetAuthorizationResourcesAsync(string realm, string? clientId = null,
            bool deep = false, int? first = null, int? max = null, string? name = null, string? owner = null,
            string? type = null, string? uri = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(deep)] = deep,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(name)] = name,
                [nameof(owner)] = owner,
                [nameof(type)] = type,
                [nameof(uri)] = uri
            };

            return await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/resource")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<AuthorizationResource>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId} <br/><br/>
        /// Get the client's authorization service resource server's resources by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="resourceId"></param>
        public async Task<AuthorizationResource> GetAuthorizationResourceByIdAsync(string realm, string clientId, string resourceId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId}")
                .GetJsonAsync<AuthorizationResource>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{clientId}/authz/resource-server/resource <br/><br/>
        /// Create the client's authorization service resource server's resource. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="resource"></param>
        public async Task<bool> CreateAuthorizationResourceAsync(string realm, string clientId, AuthorizationResource resource)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/resource")
                .PostJsonAsync(resource)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId} <br/><br/>
        /// Update the client's authorization service resource server's resource. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="resourceId"></param>
        /// <param name="resource"></param>
        public async Task<bool> UpdateAuthorizationResourceByIdAsync(string realm, string clientId, string resourceId,
            AuthorizationResource resource)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId}")
                .PutJsonAsync(resource)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId} <br/><br/>
        /// Delete the client's authorization service resource server's resource. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="resourceId"></param>
        public async Task<bool> DeleteAuthorizationResourceByIdAsync(string realm, string clientId, string resourceId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/resource/{resourceId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
