using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.AuthenticationManagement;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage authenticator's configurations. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authentication_management_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/authentication/config/{configurationId} <br/>
        /// Get authenticator configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="configurationId">configuration id</param>
        public async Task<AuthenticatorConfig> GetAuthenticatorConfigurationAsync(string realm, string configurationId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
                .GetJsonAsync<AuthenticatorConfig>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/authentication/config/{configurationId} <br/>
        /// Update authenticator configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="configurationId">configuration id</param>
        /// <param name="authenticatorConfig">json describing new state of authenticator configuration</param>
        public async Task<bool> UpdateAuthenticatorConfigurationAsync(string realm, string configurationId, AuthenticatorConfig authenticatorConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
                .PutJsonAsync(authenticatorConfig)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/authentication/config/{configurationId} <br/>
        /// Delete authenticator configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="configurationId">configuration id</param>
        public async Task<bool> DeleteAuthenticatorConfigurationAsync(string realm, string configurationId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
