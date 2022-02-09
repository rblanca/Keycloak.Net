using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Root;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for Oidc 'Authentication'.
    /// </summary>
    [Collection(KeycloakClientTests.Authentication)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class OidcTest
    {
        public OidcTest(KeycloakFixture fixture)
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

        [Fact]
        public async Task GetOpenIdConfigurationAsync()
        {
            var result = await _keycloak.GetOpenIdConfigurationAsync(_realm);
            result.Issuer!.AbsoluteUri.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetJwksAsync()
        {
            var result = await _keycloak.GetJwksAsync(_realm);
            result.Should().NotBeNull();
            result.Keys.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async Task EndsessionAsync()
        {
            var result = await _keycloak.EndsessionAsync(_realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetUserInfoAsync()
        {
            var keycloak = _fixture.TestClient;
            var result = await keycloak.GetUserinfoAsync(_realm);
            result.Should().NotBeNullOrEmpty();
            result[JwtClaimTypes.PreferredUserName].Should().Be("service-account-testclient");
        }

        [Fact]
        public async Task GetClientCredentialsToken()
        {
            var result = await _keycloak.GetClientCredentialsToken(_realm, _fixture.Client.ClientId, _fixture.Client.Secret!);
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetPasswordToken()
        {
            var result = await _keycloak.GetPasswordToken(_realm, _fixture.User.UserName, _fixture.Credential.Value!, "admin-cli");
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeNullOrEmpty();
        }

    }
}
