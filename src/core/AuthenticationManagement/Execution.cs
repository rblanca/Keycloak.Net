using System.Net.Http;
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
        /// POST /{realm}/authentication/executions <br/>
        /// Add new authentication execution.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="authenticationExecution">json model describing authentication execution</param>
        public async Task<bool> AddAuthenticationExecutionAsync(string realm, AuthenticationExecution authenticationExecution)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions")
                .PostJsonAsync(authenticationExecution)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/executions/{executionId} <br/>
        /// Get Single Execution.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="executionId"></param>
        public async Task<AuthenticationExecutionById> GetAuthenticationExecutionAsync(string realm, string executionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}")
                .GetJsonAsync<AuthenticationExecutionById>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/authentication/executions/{executionId} <br/>
        /// Delete execution.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="executionId"></param>
        public async Task<bool> DeleteAuthenticationExecutionAsync(string realm, string executionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/executions/{executionId}/config <br/>
        /// Update execution with new configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="executionId">execution id</param>
        /// <param name="authenticatorConfig">JSON with new configuration</param>
        public async Task<bool> UpdateAuthenticationExecutionConfigurationAsync(string realm, string executionId, AuthenticatorConfig authenticatorConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/config")
                .PostJsonAsync(authenticatorConfig)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/executions/{executionId}/lower-priority <br/>
        /// Lower execution’s priority.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="executionId">execution id</param>
        public async Task<bool> LowerAuthenticationExecutionPriorityAsync(string realm, string executionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/lower-priority")
                .PostAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/executions/{executionId}/raise-priority <br/>
        /// Raise execution’s priority.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="executionId"></param>
        public async Task<bool> RaiseAuthenticationExecutionPriorityAsync(string realm, string executionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/raise-priority")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
