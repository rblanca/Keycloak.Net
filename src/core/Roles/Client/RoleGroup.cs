using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Groups;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage groups that are associated with the client-level roles. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/roles/{roleName}/groups <br/>
        /// Returns a stream of groups associated with this client role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not client-id)</param>
        /// <param name="roleName">the role name.</param>
        /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects.</param>
        /// <param name="first">first result to return. Ignored if negative or {@code null}.</param>
        /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}.</param>
        public async Task<IEnumerable<Group>> GetGroupsWithRoleNameAsync(
            string realm,
            string clientId,
            string roleName,
            bool? briefRepresentation = null,
            int? first = null,
            int? max = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(briefRepresentation)] = briefRepresentation,
                [nameof(first)] = first,
                [nameof(max)] = max
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}/groups")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);

            return response;
        }

    }
}
