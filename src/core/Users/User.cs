using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage users. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_users_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/users <br/>
        /// Create a new user. Username must be unique.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="user"></param>
        public async Task<bool> CreateUserAsync(string realm, User user)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users")
                .PostJsonAsync(user)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users <br/>
        /// Get users. Returns a stream of users, filtered according to query parameters.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="briefRepresentation">Boolean which defines whether brief representations are returned (default: false)</param>
        /// <param name="email">A String contained in email, or the complete email, if param "exact" is true</param>
        /// <param name="emailVerified">whether the email has been verified</param>
        /// <param name="enabled">Boolean representing if user is enabled or not</param>
        /// <param name="exact">Boolean which defines whether the params "last", "first", "email" and "username" must match exactly</param>
        /// <param name="first">Pagination offset</param>
        /// <param name="firstName">A String contained in firstName, or the complete firstName, if param "exact" is true</param>
        /// <param name="idpAlias">The alias of an Identity Provider linked to the user</param>
        /// <param name="idpUserId">The id at an Identity Provider linked to the user</param>
        /// <param name="lastName">A String contained in lastName, or the complete lastName, if param "exact" is true</param>
        /// <param name="max">Maximum results size (defaults to 100)</param>
        /// <param name="search">A String contained in username, first or last name, or email</param>
        /// <param name="username">A String contained in username, or the complete username, if param "exact" is true</param>
        public async Task<IEnumerable<User>?> GetUsersAsync(
            string realm,
            bool? briefRepresentation = null,
            string? email = null,
            bool? emailVerified = null,
            bool? enabled = null,
            bool? exact = null,
            int? first = null,
            string? firstName = null,
            string? idpAlias = null,
            string? idpUserId = null,
            string? lastName = null,
            int? max = null,
            string? search = null,
            string? username = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(briefRepresentation)] = briefRepresentation,
                [nameof(email)] = email,
                [nameof(emailVerified)] = emailVerified,
                [nameof(enabled)] = enabled,
                [nameof(exact)] = exact,
                [nameof(first)] = first,
                [nameof(firstName)] = firstName,
                [nameof(idpAlias)] = idpAlias,
                [nameof(idpUserId)] = idpUserId,
                [nameof(lastName)] = lastName,
                [nameof(max)] = max,
                [nameof(search)] = search,
                [nameof(username)] = username
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<User>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/{userId} <br/>
        /// Get representation of the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<User?> GetUserByIdAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
                .GetJsonAsync<User>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/count <br/>
        /// Returns the number of users that match the given criteria.
        /// </summary>
        /// <remarks>
        /// It can be called in three different ways:
        /// <list type="number">
        /// <item>Don’t specify any criteria and pass {@code null}. The number of all users within that realm will be returned.</item>
        /// <item>If {@code search} is specified other criteria such as {@code last} will be ignored even though you set them.
        /// The {@code search} string will be matched against the first and last name, the username and the email of a user.</item>
        /// <item>If {@code search} is unspecified but any of {@code last}, {@code first}, {@code email} or {@code username} those criteria are
        /// matched against their respective fields on a user entity. Combined with a logical and.</item>
        /// </list>
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="email">email filter</param>
        /// <param name="emailVerified"></param>
        /// <param name="firstName">first name filter</param>
        /// <param name="lastName">last name filter</param>
        /// <param name="search">arbitrary search string for all the fields below</param>
        /// <param name="username">username filter</param>
        public async Task<int> GetUsersCountAsync(
            string realm,
            string? email = null,
            bool? emailVerified = null,
            string? firstName = null,
            string? lastName = null,
            string? search = null,
            string? username = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(email)] = email,
                [nameof(emailVerified)] = emailVerified,
                [nameof(firstName)] = firstName,
                [nameof(lastName)] = lastName,
                [nameof(search)] = search,
                [nameof(username)] = username
            };
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/count")
                .SetQueryParams(queryParams)
                .GetJsonAsync<int>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId} <br/>
        /// Update the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="user"></param>
        public async Task<bool> UpdateUserByIdAsync(string realm, string userId, User user)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
                .PutJsonAsync(user)
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId} <br/>
        /// Delete the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<bool> DeleteUserByIdAsync(string realm, string userId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/execute-actions-email <br/>
        /// Send a update account email to the user An email contains a link the user can click to perform a set of required actions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="requiredActions">required actions the user needs to complete</param>
        /// <param name="clientId">client id</param>
        /// <param name="lifespan">Number of seconds after which the generated token expires</param>
        /// <param name="redirectUri">Redirect uri</param>
        public async Task<bool> SendUserUpdateAccountEmailAsync(
            string realm,
            string userId,
            IEnumerable<string> requiredActions,
            string? clientId = null,
            int? lifespan = null,
            string? redirectUri = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                ["clientId_id"] = clientId,
                [nameof(lifespan)] = lifespan,
                ["redirect_uri"] = redirectUri
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/execute-actions-email")
                .SetQueryParams(queryParams)
                .PutJsonAsync(requiredActions)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/send-verify-email <br/>
        /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
        /// </summary>
        /// <remarks>
        /// The redirectUri and clientId parameters are optional. The default for the redirect is the account client.
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="clientId">client id</param>
        /// <param name="redirectUri"></param>
        public async Task<bool> VerifyUserEmailAddressAsync(
            string realm,
            string userId,
            string? clientId = null,
            string? redirectUri = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                ["clientId_id"] = clientId,
                ["redirect_uri"] = redirectUri
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/send-verify-email")
                .SetQueryParams(queryParams)
                .PutAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
