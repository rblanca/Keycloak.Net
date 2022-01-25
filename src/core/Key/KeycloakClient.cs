using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Key;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<KeysMetadata> GetKeysAsync(string realm) => await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/keys")
            .GetJsonAsync<KeysMetadata>()
            .ConfigureAwait(false);
    }
}
