using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.AuthenticationManagement;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authentication_management_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/authentication/flows <br/>
        /// Create a new authentication flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="authenticationFlow">authentication flow representation</param>
        public async Task<bool> CreateAuthenticationFlowAsync(string realm, AuthenticationFlow authenticationFlow)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows")
                .PostJsonAsync(authenticationFlow)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/flows <br/>
        /// Get authentication flows Returns a stream of authentication flows.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<AuthenticationFlow>> GetAuthenticationFlowsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows")
                .GetJsonAsync<IEnumerable<AuthenticationFlow>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/authentication/flows/{flowAlias}/copy <br/>
        /// Copy existing authentication flow under a new name The new name is given as 'newName' attribute of the passed JSON object.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowAlias">name of the existing authentication flow</param>
        /// <param name="newName">new name of the copied flow</param>
        public async Task<bool> DuplicateAuthenticationFlowAsync(string realm, string flowAlias, string newName)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/copy")
                .PostJsonAsync(new Dictionary<string, object> { [nameof(newName)] = newName })
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/flows/{flowAlias}/executions <br/>
        /// Get authentication executions for a flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowAlias">flow alias</param>
        public async Task<IEnumerable<AuthenticationFlowExecutionInfo>> GetAuthenticationFlowExecutionsAsync(
            string realm,
            string flowAlias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions")
                .GetJsonAsync<IEnumerable<AuthenticationFlowExecutionInfo>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/authentication/flows/{flowAlias}/executions <br/>
        /// Update authentication executions of a Flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowAlias">flow alias</param>
        /// <param name="authenticationFlowExecutionInfo"></param>
        public async Task<bool> UpdateAuthenticationFlowExecutionsAsync(string realm, string flowAlias, AuthenticationFlowExecutionInfo authenticationFlowExecutionInfo)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions")
                .PutJsonAsync(authenticationFlowExecutionInfo)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/flows/{flowAlias}/executions/execution <br/>
        /// Add new authentication execution to a flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowAlias">alias of parent flow</param>
        /// <param name="data">new execution JSON data containing 'provider' attribute</param>
        public async Task<bool> AddAuthenticationFlowExecutionAsync(string realm, string flowAlias, AuthenticationFlowExecution data)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions/execution")
                .PostJsonAsync(data)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/flows/{flowAlias}/executions/flow <br/>
        /// Add new flow with new execution to existing flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowAlias">alias of parent authentication flow</param>
        /// <param name="data">new authentication flow / execution JSON data containing 'alias', 'type', 'provider', and 'description' attributes</param>
        public async Task<bool> AddAuthenticationFlowAndExecutionToAuthenticationFlowAsync(string realm, string flowAlias, AuthenticationFlowWithExecution data)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions/flow")
                .PostJsonAsync(data)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/flows/{flowId} <br/>
        /// Get authentication flow for id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowId">flow id</param>
        public async Task<AuthenticationFlow> GetAuthenticationFlowByIdAsync(string realm, string flowId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
                .GetJsonAsync<AuthenticationFlow>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/authentication/flows/{id} <br/>
        /// Update an authentication flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowId"></param>
        /// <param name="authenticationFlow">authentication flow representation</param>
        public async Task<bool> UpdateAuthenticationFlowAsync(string realm, string flowId, AuthenticationFlow authenticationFlow)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
                .PutJsonAsync(authenticationFlow)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/authentication/flows/{flowId} <br/>
        /// Delete an authentication flow.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="flowId">flow id</param>
        public async Task<bool> DeleteAuthenticationFlowAsync(string realm, string flowId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
