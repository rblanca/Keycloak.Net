using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<IEnumerable<Resource>?> GetResourcesOwnedByClientAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "urn:ietf:params:oauth:grant-type:uma-ticket"),
                    new("response_mode", "permissions"),
                    new("audience", clientId)
                })
                .ReceiveJson<IEnumerable<Resource>>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
