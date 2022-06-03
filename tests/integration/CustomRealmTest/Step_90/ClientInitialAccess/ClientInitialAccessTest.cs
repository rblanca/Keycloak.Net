using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.ClientInitialAccess;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientInitialAccessTest : KeycloakClientTests
    {
        public ClientInitialAccessTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static ClientInitialAccessPresentation _access;

        #endregion

        [Fact, TestPriority(-10)]
        public async Task CreateInitialAccessTokenAsync()
        {
            _access = await _keycloak.CreateInitialAccessTokenAsync(_realm, new ClientInitialAccessCreatePresentation{Count = 1, Expiration = 300});
            _access.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientInitialAccessAsync()
        {
            var result = (await _keycloak.GetClientInitialAccessAsync(_realm)).ToList();
            result.Should().HaveCount(1);
            result[0].Should().BeEquivalentTo(_access, opt => opt.Excluding(_ => _.Token));
        }

        [Fact, TestPriority(10)]
        public async Task DeleteInitialAccessTokenAsync()
        {
            var result = await _keycloak.DeleteInitialAccessTokenAsync(_realm,  _access.Id!);
            result.Should().BeTrue();
        }

    }
}
