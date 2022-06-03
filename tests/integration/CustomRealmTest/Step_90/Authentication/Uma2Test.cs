using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    /// <summary>
    /// Integration tests for Uma2 'Authentication'.
    /// </summary>
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Uma2Test : KeycloakClientTests
    {
        public Uma2Test(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestNoAuthClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        #endregion

        [Fact, TestPriority(2)]
        public async Task GetUma2ConfigurationAsync()
        {
            var result = await _keycloak.GetUma2ConfigurationAsync(_realm);
            result.Issuer!.AbsoluteUri.Should().NotBeNullOrEmpty();
        }
    }
}
