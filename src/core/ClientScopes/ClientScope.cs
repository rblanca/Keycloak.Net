using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.ClientScopes;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/client-scopes <br/>
        /// Create a new client scope. Client Scope’s name must be unique!
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScope"></param>
        public async Task<bool> CreateClientScopeAsync(string realm, ClientScope clientScope)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes")
                .PostJsonAsync(clientScope)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/client-scopes <br/>
        /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<ClientScope>> GetClientScopesAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/client-scopes/{clientScopeId} <br/>
        /// Get representation of the client scope.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId">id of client scope (not name)</param>
        public async Task<ClientScope> GetClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
                .GetJsonAsync<ClientScope>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/client-scopes/{clientScopeId} <br/>
        /// Update the client scope.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId">id of client scope (not name)</param>
        /// <param name="clientScope"></param>
        public async Task<bool> UpdateClientScopeAsync(string realm, string clientScopeId, ClientScope clientScope)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
                .PutJsonAsync(clientScope)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/client-scopes/{clientScopeId} <br/>
        /// Delete the client scope.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId">id of client scope (not name)</param>
        public async Task<bool> DeleteClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
