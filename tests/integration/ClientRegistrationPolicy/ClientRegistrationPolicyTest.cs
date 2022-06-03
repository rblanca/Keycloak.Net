using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Keycloak.Net.Tests
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientRegistrationPolicyTest : KeycloakClientTests
    {
        public ClientRegistrationPolicyTest(KeycloakFixture fixture)
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
        public async Task GetRetrieveProvidersBasePathAsync()
        {
            var result = await _keycloak.GetRetrieveProvidersBasePathAsync(_realm);
            result.Should().NotBeNullOrEmpty();
        }
    }
}
