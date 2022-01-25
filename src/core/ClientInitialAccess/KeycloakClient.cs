using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.ClientInitialAccess;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_client_initial_access_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients-initial-access <br/>
        /// Create a new initial access token.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="create"></param>
        public async Task<ClientInitialAccessPresentation> CreateInitialAccessTokenAsync(
            string realm,
            ClientInitialAccessCreatePresentation create)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
                .PostJsonAsync(create)
                .ReceiveJson<ClientInitialAccessPresentation>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients-initial-access <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
                .GetJsonAsync<IEnumerable<ClientInitialAccessPresentation>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/clients-initial-access/{clientInitialAccessTokenId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientInitialAccessTokenId"></param>
        public async Task<bool> DeleteInitialAccessTokenAsync(string realm, string clientInitialAccessTokenId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access/{clientInitialAccessTokenId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
