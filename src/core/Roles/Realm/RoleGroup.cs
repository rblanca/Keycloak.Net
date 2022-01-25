using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Groups;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage groups that are associated with the realm-level roles. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/roles/{roleName}/groups <br/>
        /// Returns a stream of groups associated with this realm role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">the role name.</param>
        /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects.</param>
        /// <param name="first">first result to return. Ignored if negative or {@code null}.</param>
        /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}.</param>
        public async Task<IEnumerable<Group>> GetGroupsWithRoleNameAsync(
            string realm,
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
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/groups")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);

            return response;
        }

    }
}
