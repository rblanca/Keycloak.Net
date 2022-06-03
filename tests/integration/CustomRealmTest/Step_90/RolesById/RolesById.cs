using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Roles;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class RolesById : KeycloakClientTests
    {
        public RolesById(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private readonly Role _subRole = new Role
        {
            Name = "subRole2",
            Description = "some sub role"
        };

        #endregion

        [Fact, TestPriority(-10)]
        public async Task GetClientAndRoleAsync()
        {

            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId))!.Single();
            _fixture.User = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName)).Single();
            _fixture.Role = await _keycloak.GetRoleByNameAsync(_realm, _fixture.Role.Name!);
        }

        [Fact]
        public async Task GetRoleByIdAsync()
        {
            var result = await _keycloak.GetRoleByIdAsync(_realm, _fixture.Role.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateRoleByIdAsync()
        {
            var result = await _keycloak.UpdateRoleByIdAsync(_realm, _fixture.Role.Id!, _fixture.Role);
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working")]
        public async Task MakeRoleCompositeAsync()
        {
            var result = await _keycloak.AddCompositeRolesByIdAsync(_realm, _fixture.Role.Id!, new []{ _subRole });
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working")]
        public async Task GetRoleChildrenAsync()
        {
            var result = await _keycloak.GetCompositeRolesByIdAsync(_realm, _fixture.Role.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = "Not working"), TestPriority(2)]
        public async Task RemoveRolesFromCompositeAsync()
        {
            var result = await _keycloak.RemoveCompositeRolesByIdAsync(_realm, _fixture.Role.Id!, new[] { _subRole });
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working")]
        public async Task GetClientRolesForCompositeByIdAsync()
        {
            var result = await _keycloak.GetCompositeClientRolesByIdAsync(_realm, _fixture.Role.Id!, _fixture.Client.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = "Not working")]
        public async Task GetRealmRolesForCompositeByIdAsync()
        {
            var result = await _keycloak.GetCompositeRealmRolesByIdAsync(_realm, _fixture.Role.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetRoleByIdAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.GetRoleAuthorizationPermissionsInitializedByIdAsync(_realm, _fixture.Role.Id!);
            Assert.NotNull(result);
        }

        [Fact, TestPriority(2)]
        public async Task SetRoleByIdAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.SetRoleAuthorizationPermissionsInitializedByIdAsync(_realm, _fixture.Role.Id!, _fixture.ManagementPermission);
            Assert.NotNull(result);
        }
    }
}
