using System;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// Exceptions that are thrown by Keycloak
    /// </summary>
    public class KeycloakException : Exception
    {
        /// <inheritdoc cref="KeycloakException"/>
        public KeycloakException(string message)
            : base(message)
        {
        }

        /// <inheritdoc cref="KeycloakException"/>
        public KeycloakException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
