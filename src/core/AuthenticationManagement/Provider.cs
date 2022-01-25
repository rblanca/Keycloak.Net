using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.AuthenticationManagement;
using Keycloak.Net.Model.Root;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authentication_management_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/authentication/authenticator-providers <br/>
        /// Get authenticator providers. Returns a stream of authenticator providers.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<AuthenticatorProvider>> GetAuthenticatorProvidersAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/authenticator-providers")
                .GetJsonAsync<IEnumerable<AuthenticatorProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/client-authenticator-providers <br/>
        /// Get client authenticator providers. Returns a stream of client authenticator providers.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<AuthenticatorProvider>> GetClientAuthenticatorProvidersAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/client-authenticator-providers")
                .GetJsonAsync<IEnumerable<AuthenticatorProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/config-description/{providerId} <br/>
        /// Get authenticator provider’s configuration description.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="providerId"></param>
        public async Task<AuthenticatorConfigInfo> GetAuthenticatorProviderConfigurationDescriptionAsync(
            string realm,
            string providerId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config-description/{providerId}")
                .GetJsonAsync<AuthenticatorConfigInfo>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/form-action-providers <br/>
        /// Get form action providers Returns a stream of form action providers.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<FormActionProvider>> GetFormActionProvidersAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/form-action-providers")
                .GetJsonAsync<IEnumerable<FormActionProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/form-providers <br/>
        /// Get form providers. Returns a stream of form providers.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<FormProvider>> GetFormProvidersAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/form-providers")
                .GetJsonAsync<IEnumerable<FormProvider>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/authentication/per-client-config-description <br/>
        /// Get configuration descriptions for all clients.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<ClientAuthenticatorProvider> GetConfigurationDescriptionsForAllClientsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/authentication/per-client-config-description")
                .GetJsonAsync<ClientAuthenticatorProvider>()
                .ConfigureAwait(false);
            return response;
        }
    }
}
