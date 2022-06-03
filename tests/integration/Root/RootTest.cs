using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Keycloak.Net.Tests
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class RootTest : KeycloakClientTests
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

        [Fact(Skip = "Not working")]
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
    }
}
