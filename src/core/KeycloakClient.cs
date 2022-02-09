using System;
using System.Net;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Keycloak.Net.Model.Root;
using Keycloak.Net.Shared.Extensions;

#pragma warning disable 8618

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
        private KeycloakClient(string url, string authenticationRealm)
        {
            _url = url;
            _authenticationRealm = authenticationRealm;

            Initialize();
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, string authenticationRealm, string clientId, string userName, string password)
            : this(url, authenticationRealm)
        {
            _clientId = clientId;
            _userName = userName;
            _password = password;
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, string authenticationRealm, string clientId, string clientSecret)
            : this(url, authenticationRealm)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <inheritdoc cref="KeycloakClient"/>
        public KeycloakClient(string url, string authenticationRealm, Func<string> getToken)
            : this(url, authenticationRealm)
        {
            _getToken = getToken;
        }

        #region Properties
        
        private readonly string _url;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authenticationRealm;
        private readonly Func<string> _getToken;
        private readonly ISerializer _serializer = new NewtonsoftJsonSerializer(JsonExtensions.JsonSerializerSettings);
        
        #endregion
        
        private IFlurlRequest GetBaseUrl()
        {
            var request = _url
                .AppendPathSegment("/auth")
                .ConfigureRequest(_ => {})
                .WithAuthentication(_getToken, _url, _authenticationRealm, _clientId, _userName, _password, _clientSecret);

            return request;
        }

        private IFlurlRequest GetBaseUrlNoAuth()
        {
            var request = _url
                .AppendPathSegment("/auth")
                .ConfigureRequest(_ => { });

            return request;
        }

        /// <summary>
        /// Initialization settings
        /// </summary>
        private void Initialize()
        {
            FlurlHttp.ConfigureClient(_url, client =>
            {
                client.Settings.JsonSerializer = _serializer;
                client.Settings.OnErrorAsync = async call =>
                {
                    // Wrap all error messages return from the Keycloak server into exception
                    var errorContent = call.HttpResponseMessage != null ? await call.HttpResponseMessage.Content.ReadAsStringAsync() : string.Empty;
                    var exceptionMessage = call.Exception.FlattenError(errorContent);
                    call.Exception = new KeycloakException(exceptionMessage);

                    // Set response content to null when 404
                    if (call.HttpResponseMessage?.StatusCode == HttpStatusCode.NotFound)
                    {
                        call.HttpResponseMessage.Content = null;
                        call.ExceptionHandled = true;
                    }

                    if (!call.ExceptionHandled)
                    {
                        throw call.Exception;
                    }
                };
            });
        }
    }
}
