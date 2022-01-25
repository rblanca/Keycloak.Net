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
        /// POST /{realm}/authentication/register-required-action <br/>
        /// Register a new required actions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="data">JSON containing 'providerId', and 'name' attributes.</param>
        public async Task<bool> RegisterRequiredActionAsync(string realm, RequiredAction data)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/register-required-action")
                .PostJsonAsync(data)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/required-actions <br/>
        /// Get required actions. Returns a stream of required actions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<RequiredActionProvider>> GetRequiredActionsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions")
                .GetJsonAsync<IEnumerable<RequiredActionProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/required-actions/{requiredActionAlias}
        /// Get required action for alias.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="requiredActionAlias">alias of required action</param>
        public async Task<RequiredActionProvider> GetRequiredActionByAliasAsync(
            string realm,
            string requiredActionAlias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
                .GetJsonAsync<RequiredActionProvider>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/authentication/required-actions/{requiredActionAlias}
        /// Update required action.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="requiredActionAlias">alias of required action</param>
        /// <param name="requiredActionProvider">JSON describing new state of required action</param>
        public async Task<bool> UpdateRequiredActionAsync(string realm, string requiredActionAlias, RequiredActionProvider requiredActionProvider)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
                .PutJsonAsync(requiredActionProvider)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/authentication/required-actions/{requiredActionAlias} <br/>
        /// Delete required action.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="requiredActionAlias">alias of required action</param>
        public async Task<bool> DeleteRequiredActionAsync(string realm, string requiredActionAlias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/required-actions/{requiredActionAlias}/lower-priority <br/>
        /// Lower required action's priority.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="requiredActionAlias">alias of required action</param>
        public async Task<bool> LowerRequiredActionPriorityAsync(string realm, string requiredActionAlias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}/lower-priority")
                .PostAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/authentication/required-actions/{requiredActionAlias}/raise-priority <br/>
        /// Raise required action’s priority.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="requiredActionAlias"></param>
        public async Task<bool> RaiseRequiredActionPriorityAsync(string realm, string requiredActionAlias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}/raise-priority")
                .PostAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/authentication/unregistered-required-actions <br/>
        /// Get unregistered required actions. Returns a stream of unregistered required actions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<RequiredActionProvider>> GetUnregisteredRequiredActionsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/unregistered-required-actions")
                .GetJsonAsync<IEnumerable<RequiredActionProvider>>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
