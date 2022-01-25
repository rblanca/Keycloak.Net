using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Components;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_client_registration_policy_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/client-registration-policy/providers <br/>
        /// Base path for retrieve providers with the configProperties properly filled.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<ComponentType>> GetRetrieveProvidersBasePathAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-registration-policy/providers")
                .GetJsonAsync<IEnumerable<ComponentType>>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
