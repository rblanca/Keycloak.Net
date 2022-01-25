namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Client Authenticator used for authentication of this client against Keycloak server.
    /// </summary>
    public enum ClientAuthenticatorType
    {
        /// <summary>
        /// Signed Jwt
        /// </summary>
        ClientJwt = 0,

        /// <summary>
        /// Client Id and Secret
        /// </summary>
        ClientSecret = 1,

        /// <summary>
        /// X509 Certificate
        /// </summary>
        ClientX509 = 2,

        /// <summary>
        /// Signed Jwt with Client Secret
        /// </summary>
        ClientSecretJwt = 3
    }
}
