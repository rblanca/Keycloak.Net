using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_groups_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/groups/{id}/members <br/>
        /// Get users. Returns a stream of users, filtered according to query parameters.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="briefRepresentation">
        /// Only return basic information (only guaranteed to return id, username, created, first and last name, email, enabled state, email verification state, federation link, and access.
        /// Note that it means that namely user attributes, required actions, and not before are not returned.)
        /// </param>
        /// <param name="first">Pagination offset</param>
        /// <param name="max">Maximum results size (defaults to 100)</param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetGroupUsersAsync(
            string realm,
            string groupId,
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
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/members")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<User>>()
                .ConfigureAwait(false);

            return response;
        }
    }
}
