using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage users that are associatated with the realm-level roles. <br/>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_roles_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/roles/{roleName}/users <br/>
        /// Returns a stream of users associated with this realm role.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="roleName">the role name.</param>
        /// <param name="first">first result to return. Ignored if negative or <see langword="null"/>.</param>
        /// <param name="max">maximum number of results to return. Ignored if negative or <see langword="null"/></param>
        public async Task<IEnumerable<User>> GetUsersWithRoleNameAsync(
            string realm,
            string roleName,
            int? first = null,
            int? max = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/roles/{roleName}/users")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<User>>()
                .ConfigureAwait(false);

            return response;
        }

    }
}
