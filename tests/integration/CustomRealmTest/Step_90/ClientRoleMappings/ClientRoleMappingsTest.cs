using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Roles;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientRoleMappingsTest : KeycloakClientTests
    {
        public ClientRoleMappingsTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;
        
        private static IEnumerable<Role> _availableClientRoles;

        #endregion

        #region Group-Role Mappings

        [Fact, TestPriority(-11)]
        public async Task GetAvailableClientRoleMappingsForGroupAsync()
        {
            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId!)).Single();
            _fixture.Group = (await _keycloak.GetGroupsAsync(_realm, search: _fixture.Group.Name)).Single();
            _availableClientRoles = await _keycloak.GetAvailableClientRolesForGroupAsync(_realm, _fixture.Group.Id!, _fixture.Client.Id!);
            _availableClientRoles.Should().NotBeNull();
        }

        [Fact, TestPriority(-9)]
        public async Task AddClientRoleMappingsToGroupAsync()
        {
            var result = await _keycloak.AddClientRolesToGroupAsync(_realm, _fixture.Group.Id!, _fixture.Client.Id!, _availableClientRoles);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-8)]
        public async Task GetClientRoleMappingsForGroupAsync()
        {
            var result = await _keycloak.GetClientRolesForGroupAsync(_realm, _fixture.Group.Id!, _fixture.Client.Id!);
            result.Should().BeEquivalentTo(_availableClientRoles);
        }

        [Fact]
        public async Task GetEffectiveClientRoleMappingsForGroupAsync()
        {
            var result = await _keycloak.GetEffectiveClientRolesForGroupAsync(_realm, _fixture.Group.Id!, _fixture.Client.Id!);
            result.Should().BeEquivalentTo(_availableClientRoles);
        }

        [Fact, TestPriority(10)]
        public async Task DeleteClientRoleMappingsFromGroupAsync()
        {
            var result = await _keycloak.DeleteClientRolesFromGroupAsync(_realm, _fixture.Group.Id!, _fixture.Client.Id!, _availableClientRoles);
            result.Should().BeTrue();
        }

        #endregion

        #region User-Role Mappings

        [Fact, TestPriority(-11)]
        public async Task GetAvailableClientRoleMappingsForUserAsync()
        {
            _fixture.User = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName)).Single();
            _availableClientRoles = await _keycloak.GetAvailableClientRolesForUserAsync(_realm, _fixture.User.Id!, _fixture.Client.Id!);
            _availableClientRoles.Should().NotBeNull();
        }

        [Fact, TestPriority(-10)]
        public async Task AddClientRoleMappingsToUserAsync()
        {
            var result = await _keycloak.AddClientRolesToUserAsync(_realm, _fixture.User.Id!, _fixture.Client.Id!, _availableClientRoles);
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working"), TestPriority(-9)]
        public async Task GetClientRoleMappingsForUserAsync()
        {
            var result = await _keycloak.GetClientRolesForUserAsync(_realm, "c2589ac8-9056-408a-ac4b-f2f982038272", "370a5b68-b8c2-437e-bbbe-d2c1994d65fe");
            result.Should().BeEquivalentTo(_availableClientRoles);
        }

        [Fact]
        public async Task GetEffectiveClientRoleMappingsForUserAsync()
        {
            var result = await _keycloak.GetEffectiveClientRolesForUserAsync(_realm, _fixture.User.Id!, _fixture.Client.Id!);
            result.Should().BeEquivalentTo(_availableClientRoles);
        }

        [Fact, TestPriority(10)]
        public async Task DeleteClientRoleMappingsFromUserAsync()
        {
            var result = await _keycloak.DeleteClientRolesFromUserAsync(_realm, _fixture.User.Id!, _fixture.Client.Id!, _availableClientRoles);
            result.Should().BeTrue();
        }

        #endregion
    }
}
