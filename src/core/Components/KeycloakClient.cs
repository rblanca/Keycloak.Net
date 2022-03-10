using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Components;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage various keycloak components. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/_component_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// Creates a new keycloak component.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="componentRepresentation"></param>
        public async Task<bool> CreateComponentAsync(string realm, Component componentRepresentation)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components")
                .PostJsonAsync(componentRepresentation)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get all keycloak components.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <param name="type"></param>
        public async Task<IEnumerable<Component>> GetComponentsAsync(string realm, string? name = null, string? parent = null, string? type = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(name)] = name,
                [nameof(parent)] = parent,
                [nameof(type)] = type
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Component>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Get a keycloak component by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="componentId"></param>
        public async Task<Component> GetComponentByIdAsync(string realm, string componentId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
                .GetJsonAsync<Component>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Update an existing keycloak component by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="componentId"></param>
        /// <param name="componentRepresentation"></param>
        public async Task<bool> UpdateComponentByIdAsync(string realm, string componentId, Component componentRepresentation)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
                .PutJsonAsync(componentRepresentation)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// Delete a keycloak component by id.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="componentId"></param>
        public async Task<bool> DeleteComponentByIdAsync(string realm, string componentId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get a sub-components of a keycloak component.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="componentId"></param>
        /// <param name="type"></param>
        public async Task<IEnumerable<ComponentType>> GetSubcomponentTypesAsync(string realm, string componentId, string type = null)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(type)] = type
            };

            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/components/{componentId}/sub-component-types")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<ComponentType>>()
                .ConfigureAwait(false);

            return result;
        }
    }
}
