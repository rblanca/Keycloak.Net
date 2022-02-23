using System.IO;
using Microsoft.Extensions.Configuration;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        private readonly KeycloakClient _client;

        public KeycloakClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var url = configuration["url"];
            var userName = configuration["userName"];
            var password = configuration["password"];

            _client = new KeycloakClient(url, "unitTest", "admin-cli", userName, password);
        }
    }
}
