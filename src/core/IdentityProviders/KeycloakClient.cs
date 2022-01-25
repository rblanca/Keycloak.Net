using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.IdentityProviders;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/identity-provider/import-config <br/>
        /// Import identity provider from uploaded JSON file.
        /// </summary>
        /// <remarks>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/server_admin/#_general-idp-config
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="input"></param>
        public async Task<IDictionary<string, object>> ImportIdentityProviderAsync(string realm, string input) => await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/identity-provider/import-config")
            .PostMultipartAsync(content => content.AddFile(Path.GetFileName(input), Path.GetDirectoryName(input)))
            .ReceiveJson<IDictionary<string, object>>()
            .ConfigureAwait(false);

        /// <summary>
        /// POST /{realm}/identity-provider/instances <br/>
        /// Create a new identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="identityProvider"></param>
        public async Task<bool> AddIdentityProviderAsync(string realm, IdentityProvider identityProvider)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances")
                .PostJsonAsync(identityProvider)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances <br/>
        /// Get identity providers.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<IdentityProvider>> GetIdentityProviderInstancesAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances")
                .GetJsonAsync<IEnumerable<IdentityProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias} <br/>
        /// Get the identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        public async Task<IdentityProvider> GetIdentityProviderAsync(string realm, string alias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}")
                .GetJsonAsync<IdentityProvider>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/identity-provider/instances/{alias} <br/>
        /// Update the identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="identityProvider"></param>
        public async Task<bool> UpdateIdentityProviderAsync(
            string realm,
            string alias,
            IdentityProvider identityProvider)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}")
                .PutJsonAsync(identityProvider)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/identity-provider/instances/{alias} <br/>
        /// Delete the identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        public async Task<bool> DeleteIdentityProviderAsync(string realm, string alias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias}/export <br/>
        /// Export public broker configuration for identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="format">format to use</param>
        public async Task<bool> ExportIdentityProviderPublicBrokerConfigurationAsync(
            string realm, 
            string alias, 
            string? format = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(format)] = format
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/export")
                .SetQueryParams(queryParams)
                .GetAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias}/management/permissions <br/>
        /// Return object stating whether client Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        public async Task<ManagementPermission> GetIdentityProviderAuthorizationPermissionsInitializedAsync(
            string realm, 
            string alias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/identity-provider/instances/{alias}/management/permissions.
        /// Return object stating whether client Authorization permissions have been initialized or not and a reference.
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="managementPermission"></param>
        public async Task<ManagementPermission> SetIdentityProviderAuthorizationPermissionsInitializedAsync(
            string realm, string alias, ManagementPermission managementPermission)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias}/mapper-types <br/>
        /// Get mapper types for identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        public async Task<IDictionary<string, object>> GetIdentityProviderMapperTypesAsync(string realm, string alias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mapper-types")
                .GetJsonAsync<IDictionary<string, object>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/identity-provider/instances/{alias}/mappers <br/>
        /// Add a mapper to identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="mapper"></param>
        public async Task<bool> AddIdentityProviderMapperAsync(string realm, string alias, IdentityProviderMapper mapper)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mappers")
                .PostJsonAsync(mapper)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias}/mappers <br/>
        /// Get mappers for identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        public async Task<IEnumerable<IdentityProviderMapper>> GetIdentityProviderMappersAsync(string realm, string alias)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mappers")
                .GetJsonAsync<IEnumerable<IdentityProviderMapper>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/instances/{alias}/mappers/{id} <br/>
        /// Get mapper by id for the identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="id">mapper id</param>
        public async Task<IEnumerable<IdentityProviderMapper>> GetIdentityProviderMapperByIdAsync(
            string realm, 
            string alias,
            string id)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}")
                .GetJsonAsync<IEnumerable<IdentityProviderMapper>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/identity-provider/instances/{alias}/mappers/{id} <br/>
        /// Update a mapper for the identity provider by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="id">mapper id</param>
        /// <param name="mapper"></param>
        public async Task<bool> UpdateIdentityProviderMapperAsync(string realm, string alias, string id, IdentityProviderMapper mapper)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}")
                .PutJsonAsync(mapper)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/identity-provider/instances/{alias}/mappers/{id} <br/>
        /// Delete a mapper for the identity provider.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="alias">identity provider alias</param>
        /// <param name="id">mapper id</param>
        public async Task<bool> DeleteIdentityProviderMapperAsync(string realm, string alias, string id)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/identity-provider/providers/{providerId} <br/>
        /// Get identity providers by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="providerId"></param>
        public async Task<IdentityProviderInfo> GetIdentityProviderByProviderIdAsync(string realm, string providerId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/identity-provider/providers/{providerId}")
                .GetJsonAsync<IdentityProviderInfo>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
