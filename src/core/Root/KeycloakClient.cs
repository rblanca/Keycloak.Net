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

        public async Task<OpenIdConfiguration> GetOpenIdConfigurationAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/realms/{realm}/.well-known/openid-configuration")
                .GetJsonAsync<OpenIdConfiguration>()
                .ConfigureAwait(false);
            return response;
        }
        public async Task<Uma2Configuration> GetUma2ConfigurationAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/realms/{realm}/.well-known/uma2-configuration")
                .GetJsonAsync<Uma2Configuration>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
