using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Keycloak.Net.Tests
{
    [Collection(KeycloakClientTests.RootCollection)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class RootTest
    {
        public RootTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        #endregion

        [Fact]
        public async Task GetServerInfoAsync()
        {
            var result = await _keycloak.GetServerInfoAsync(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task CorsPreflightAsync()
        {
            bool? result = await _keycloak.CorsPreflightAsync(_realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetOpenIdConfigurationAsync()
        {
            var result = await _keycloak.GetOpenIdConfigurationAsync(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUma2ConfigurationAsync()
        {
            var result = await _keycloak.GetUma2ConfigurationAsync(_realm);
            result.Should().NotBeNull();
        }

    }
}
