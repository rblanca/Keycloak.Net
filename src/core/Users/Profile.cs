using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage user profiles. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_users_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/users/profile <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/server_admin/index.html#user-profile.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<UserProfiles?> GetUserProfileAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/profile")
                .GetJsonAsync<UserProfiles>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm}/users/profile <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/server_admin/index.html#user-profile.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userProfiles"></param>
        public async Task<bool> UpdateUserProfileAsync(string realm, UserProfiles userProfiles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/profile")
                .PutJsonAsync(userProfiles)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
