using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Authentication;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// Get <a href="https://docs.kantarainitiative.org/uma/wg/rec-oauth-uma-grant-2.0.html">User-Managed Access 2.0</a> configurations.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<Uma2Configuration> GetUma2ConfigurationAsync(string realm)
        {
            var response = await GetBaseUrlNoAuth()
                .AppendPathSegment($"/realms/{realm}/.well-known/uma2-configuration")
                .GetJsonAsync<Uma2Configuration>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
