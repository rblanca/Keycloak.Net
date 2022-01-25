using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/nodes <br/>
        /// Register a cluster node with the client. Manually register cluster node to this client - usually it’s not needed to call this directly as adapter should handle by sending registration request to Keycloak.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="formParams"></param>
        public async Task<bool> RegisterClientClusterNodeAsync(
            string realm,
            string clientId,
            IDictionary<string, object> formParams)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/nodes")
                .PostJsonAsync(formParams)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/nodes/{node} <br/>
        /// Un-register a cluster node from the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="node">node to be removed</param>
        public async Task<bool> UnregisterClientClusterNodeAsync(string realm, string clientId, string node)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/nodes/{node}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/test-nodes-available <br/>
        /// Test if registered cluster nodes are available Tests availability by sending 'ping' request to all cluster nodes.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<GlobalRequestResult?> TestClientClusterNodesAvailableAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/test-nodes-available")
                .GetJsonAsync<GlobalRequestResult>()
                .ConfigureAwait(false);
            return response;
        }

    }
}
