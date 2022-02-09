using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Root;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<ServerInfo> GetServerInfoAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment("/admin/serverinfo")
                .GetJsonAsync<ServerInfo>()
                .ConfigureAwait(false);
            
            return response;
        }

        public async Task<bool> CorsPreflightAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment("/admin/serverinfo")
                .OptionsAsync()
                .ConfigureAwait(false);
            
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
