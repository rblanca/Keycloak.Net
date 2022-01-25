using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keycloak.Net.Model.AuthorizationManagement;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage authorization scopes for client. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/authz/resource-server/scope" <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="scope"></param>
        public async Task<bool> CreateAuthorizationScopeAsync(string realm, string clientId, AuthorizationScope scope)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/scope")
                .PostJsonAsync(scope)
                .ConfigureAwait(false);
            
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/scope" <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="deep"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="name"></param>
        public async Task<IEnumerable<AuthorizationScope>> GetAuthorizationScopesAsync(string realm, string? clientId = null,
            bool? deep = false, int? first = null, int? max = null, string? name = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(deep)] = deep,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(name)] = name,
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/scope")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<AuthorizationScope>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}" <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="scopeId"></param>
        public async Task<AuthorizationScope> GetAuthorizationScopeByIdAsync(string realm, string clientId,
            string scopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}")
                .GetJsonAsync<AuthorizationScope>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}" <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="scopeId"></param>
        /// <param name="scope"></param>
        public async Task<bool> UpdateAuthorizationScopeByIdAsync(string realm, string clientId, string scopeId, AuthorizationScope scope)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}")
                .PutJsonAsync(scope)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}" <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="scopeId"></param>
        public async Task<bool> DeleteAuthorizationScopeByIdAsync(string realm, string clientId, string scopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/scope/{scopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
