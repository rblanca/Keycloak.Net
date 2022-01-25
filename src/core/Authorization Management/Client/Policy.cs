using System;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.AuthorizationManagement;

namespace Keycloak.Net
{
    /// <remarks>
    /// Keycloak fine-grained authorization policies for client. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType} <br/><br/>
        /// Create a new authorization policy for this client. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policy"></param>
        public async Task<AuthorizationPolicy> CreateAuthorizationPolicyByTypeAsync(string realm, string clientId, AuthorizationPolicy policy)
        {
                var response = await GetBaseUrl()
                    .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
                    .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policy.Type)!.ToLower()}")
                    .PostJsonAsync(policy)
                    .ReceiveJson<AuthorizationPolicy>()
                    .ConfigureAwait(false);

                return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType}/{policyId} <br/><br/>
        /// Get client authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyType"></param>
        /// <param name="policyId"></param>
        public async Task<AuthorizationPolicy> GetAuthorizationPolicyByIdAsync(string realm, string clientId, PolicyType policyType, string policyId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
                .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policyType)!.ToLower()}")
                .AppendPathSegment($"/{policyId}")
                .GetJsonAsync<AuthorizationPolicy>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType} <br/><br/>
        /// Get all client authorization policies by type. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyType"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="name"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <param name="permission"></param>
        public async Task<IEnumerable<Policy>> GetAuthorizationPoliciesByTypeAsync(
            string realm, string clientId, PolicyType policyType,
            int? first = null, int? max = null,
            string? name = null, string? resource = null,
            string? scope = null, bool? permission = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(name)] = name,
                [nameof(resource)] = resource,
                [nameof(scope)] = scope,
                [nameof(permission)] = permission
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
                .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policyType)!.ToLower()}")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Policy>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType}/search <br/><br/>
        /// Search all client authorization policies by name. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyType"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="name"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <param name="permission"></param>
        public async Task<IEnumerable<Policy>> GetAuthorizationPoliciesByNameAsync(
            string realm, string clientId, PolicyType policyType,
            int? first = null, int? max = null, 
            string? name = null, string? resource = null,
            string? scope = null, bool? permission = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(name)] = name,
                [nameof(resource)] = resource,
                [nameof(scope)] = scope,
                [nameof(permission)] = permission
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/search")
                .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policyType)!.ToLower()}")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Policy>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType}/{policyId} <br/><br/>
        /// Update client authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policy"></param>
        public async Task<bool> UpdateAuthorizationPolicyByIdAsync(string realm, string clientId, AuthorizationPolicy policy)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
                .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policy.Type)!.ToLower()}")
                .AppendPathSegment($"/{policy.Id}")
                .PutJsonAsync(policy)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/authz/resource-server/policy/{policyType}/{policyId} <br/><br/>
        /// Delete client authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyType"></param>
        /// <param name="policyId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAuthorizationPolicyByIdAsync(string realm, string clientId, PolicyType policyType, string policyId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
                .AppendPathSegment($"/{Enum.GetName(typeof(PolicyType), policyType)!.ToLower()}")
                .AppendPathSegment($"/{policyId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/associatedPolicies <br/><br/>
        /// Get the associated policies for this authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyId"></param>
        public async Task<IEnumerable<Policy>> GetPoliciesForAuthorizationPolicyByIdAsync(string realm, string clientId, string policyId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{policyId}/associatedPolicies")
                .GetJsonAsync<IEnumerable<Policy>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/scopes" <br/><br/>
        /// Get the associated scopes for this authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyId"></param>
        public async Task<IEnumerable<AuthorizationScope>> GetScopesForAuthorizationPolicyByIdAsync(string realm, string clientId, string policyId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{policyId}/scopes")
                .GetJsonAsync<IEnumerable<AuthorizationScope>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/resources" <br/><br/>
        /// Get the associated resources for this authorization policy by id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_policy_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="policyId"></param>
        public async Task<IEnumerable<AuthorizationResource>> GetResourcesForAuthorizationPolicyByIdAsync(string realm, string clientId, string policyId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{policyId}/resources")
                .GetJsonAsync<IEnumerable<AuthorizationResource>>()
                .ConfigureAwait(false);

            return response;
        }
    }
}
