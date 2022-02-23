using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Keycloak.Net.Shared.Extensions;

namespace Keycloak.Net
{
    /// <summary>
    /// Keycloak cli client. <br/>
    /// </summary>
    /// <remarks>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />.
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <inheritdoc cref="KeycloakClient"/>
        private KeycloakClient(string url)
        {
            _url = url;
            Initialize();
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, string authenticationRealm, string clientId, string userName, string password)
            : this(url)
        {
            _withAuthenticationDelegate = request => request.WithAuthenticationAsync(authenticationRealm, clientId, userName, password);
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, string authenticationRealm, string clientId, string clientSecret)
            : this(url)
        {
            _withAuthenticationDelegate = request => request.WithAuthenticationAsync(authenticationRealm, clientId, clientSecret);
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, Func<string> getToken)
            : this(url)
        {
            _withAuthenticationDelegate = request => Task.FromResult(request.WithAuthentication(getToken));
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, Func<Task<string>> getTokenAsync)
            : this(url)
        {
            _withAuthenticationDelegate = async request => await request.WithAuthenticationAsync(getTokenAsync);
        }

        #region Properties

        private readonly string _url;
        private readonly Func<IFlurlRequest, Task<IFlurlRequest>> _withAuthenticationDelegate = null!;
        private readonly ISerializer _serializer = new NewtonsoftJsonSerializer(JsonExtensions.JsonSerializerSettings.Value);
        
        #endregion
        
        /// <summary>
        /// Get Keycloak base url with authentication header.
        /// </summary>
        private IFlurlRequest GetBaseUrl()
        {
            var request = _withAuthenticationDelegate(GetBaseUrlNoAuth()).GetAwaiter().GetResult();
            return request;
        }
        
        /// <summary>
        /// Get Keycloak base url without authentication header.
        /// </summary>
        private IFlurlRequest GetBaseUrlNoAuth()
        {
            var request = _url
                .AppendPathSegment("/auth")
                .ConfigureRequest(_ => { });
            return request;
        }

        /// <summary>
        /// Initialization settings for Keycloak client.
        /// </summary>
        private void Initialize()
        {
            FlurlHttp.ConfigureClient(_url, client =>
            {
                client.BaseUrl = _url;
                client.Settings.JsonSerializer = _serializer;
            });
        }
    }
}
