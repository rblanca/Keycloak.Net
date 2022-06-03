using System.IO;
using Keycloak.Net.Tests.Util;
using Microsoft.Extensions.Configuration;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        private readonly KeycloakClient _client;

        public KeycloakClientShould()
        {
            var url = KeyCloakServer.keyCloakEndpoint;
            var username = KeyCloakServer.keyCloakAdminUser;
            var password = KeyCloakServer.keyCloakAdminPassword;

            _client = new KeycloakClient(url, "unitTest", "admin-cli", username, password);
        }
    }
}
