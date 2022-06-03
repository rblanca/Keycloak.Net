using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests.MasterRealmTest
{
    public partial class KeycloakClientShould
    {
        private readonly KeycloakClient _client;

        public KeycloakClientShould()
        {
            var url = KeyCloakServer.keyCloakEndpoint;
            var username = KeyCloakServer.keyCloakAdminUser;
            var password = KeyCloakServer.keyCloakAdminPassword;

            _client = new KeycloakClient(url, "master", "admin-cli", username, password);
        }

        [Fact, TestPriority(-10)]
        public async Task StartKeyCloakTestServer()
        {
            await KeyCloakServer.StartsServerContainer();
        }
    }
}
