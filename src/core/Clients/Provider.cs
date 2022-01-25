using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/installation/providers/{providerId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="providerId"></param>
        public async Task<string?> GetClientProviderAsync(string realm, string clientId, string providerId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/installation/providers/{providerId}")
                .GetStringAsync()
                .ConfigureAwait(false);
            return response;
        }

    }
}
