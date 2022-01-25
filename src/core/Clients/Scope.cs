using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.ClientScopes;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/default-client-scopes <br/>
        /// Get default client scopes.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <returns>Only name and ids are returned.</returns>
        public async Task<IEnumerable<ClientScope>?> GetDefaultClientScopesAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/default-client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/default-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> UpdateDefaultClientScopeAsync(string realm, string clientId, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/default-client-scopes/{clientScopeId}")
                .PutAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/default-client-scopes/{clientScopeId}
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> DeleteDefaultClientScopeAsync(string realm, string clientId, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/default-client-scopes/{clientScopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/optional-client-scopes <br/>
        /// Get optional client scopes.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <returns>Only name and ids are returned.</returns>
        public async Task<IEnumerable<ClientScope>?> GetOptionalClientScopesAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/optional-client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/optional-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> UpdateOptionalClientScopeAsync(string realm, string clientId, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/optional-client-scopes/{clientScopeId}")
                .PutAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/optional-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> DeleteOptionalClientScopeAsync(string realm, string clientId, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/optional-client-scopes/{clientScopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/granted <br/>
        /// Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have in the accessToken issued for him. <br/>
        /// This contains scope mappings, which this client has directly, as well as scope mappings, which are granted to all client scopes, which are linked with this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="roleContainerId">either realm name OR client UUID</param>
        /// <param name="scope"></param>
        public async Task<IEnumerable<Role>?> GetClientGrantedScopeMappingsAsync(
            string realm,
            string clientId,
            string roleContainerId,
            string? scope = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope
            };

            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/granted")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted <br/>
        /// Get roles, which this client doesn't have scope for and can't have them in the accessToken issued for him. <br/>
        /// Defacto all the other roles of particular role container, which are not in <see cref="GetClientGrantedScopeMappingsAsync"/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="roleContainerId">either realm name OR client UUID</param>
        /// <param name="scope"></param>
        public async Task<IEnumerable<Role>?> GetClientNotGrantedScopeMappingsAsync(
            string realm,
            string clientId,
            string roleContainerId,
            string? scope = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope
            };

            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Role>>()
                .ConfigureAwait(false);
            return response;
        }

    }
}
