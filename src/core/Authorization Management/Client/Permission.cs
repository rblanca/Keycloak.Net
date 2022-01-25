using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keycloak.Net.Model.AuthorizationManagement;
using System;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage authorization permissions for client. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/authz/resource-server/permission/{permission.Type} <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_permission_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="permission"></param>
        public async Task<AuthorizationPermission> CreateAuthorizationPermissionAsync(string realm, string clientId, AuthorizationPermission permission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
                .AppendPathSegment($"/{Enum.GetName(typeof(AuthorizationPermissionType), permission.Type)!.ToLower()}")
                .PostJsonAsync(permission)
                .ReceiveJson<AuthorizationPermission>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/permission/{permissionType} <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_permission_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="permissionType"></param>
        /// <param name="permissionId"></param>
        public async Task<AuthorizationPermission> GetAuthorizationPermissionByIdAsync(string realm, string clientId, AuthorizationPermissionType permissionType, string permissionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
                .AppendPathSegment($"/{Enum.GetName(typeof(AuthorizationPermissionType), permissionType)!.ToLower()}")
                .AppendPathSegment($"/{permissionId}")
                .GetJsonAsync<AuthorizationPermission>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/authz/resource-server/permission/{permissionType} <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_permission_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="ofPermissionType"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="name"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        public async Task<IEnumerable<AuthorizationPermission>> GetAuthorizationPermissionsAsync(
            string realm,
            string clientId,
            AuthorizationPermissionType? ofPermissionType = null,
            int? first = null,
            int? max = null,
            string? name = null,
            string? resource = null,
            string? scope = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(name)] = name,
                [nameof(resource)] = resource,
                [nameof(scope)] = scope
            };

            var request = GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission");

            if (ofPermissionType.HasValue)
            {
                request.AppendPathSegment($"/{Enum.GetName(typeof(AuthorizationPermissionType), ofPermissionType)!.ToLower()}");
            }

            var response = await request
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<AuthorizationPermission>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId}/authz/resource-server/permission/{permission.Type} <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_permission_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="permission"></param>
        public async Task<bool> UpdateAuthorizationPermissionAsync(string realm, string clientId, AuthorizationPermission permission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
                .AppendPathSegment($"/{Enum.GetName(typeof(AuthorizationPermissionType), permission.Type)!.ToLower()}")
                .AppendPathSegment($"/{permission.Id}")
                .PutJsonAsync(permission)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId}/authz/resource-server/permission/{permissionType} <br/><br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_permission_overview
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="permissionType"></param>
        /// <param name="permissionId"></param>
        public async Task<bool> DeleteAuthorizationPermissionAsync(string realm, string clientId, AuthorizationPermissionType permissionType, string permissionId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
                .AppendPathSegment($"/{Enum.GetName(typeof(AuthorizationPermissionType), permissionType)!.ToLower()}")
                .AppendPathSegment($"/{permissionId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
