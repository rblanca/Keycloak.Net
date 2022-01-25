using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients/{clientId}/client-secret <br/>
        /// Generate a new secret for the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<Credential?> GenerateClientSecretAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/client-secret")
                .PostAsync()
                .ReceiveJson<Credential>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/client-secret <br/>
        /// Get the client secret.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<Credential?> GetClientSecretAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/client-secret")
                .GetJsonAsync<Credential>()
                .ConfigureAwait(false);
            return response;
        }

    }
}
