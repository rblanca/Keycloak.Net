using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Roles;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    /// <summary>
    /// Integration tests for 'Roles' management.
    /// </summary> 
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    [TestPriority(60)]
    public class Step_60_Roles: KeycloakClientTests
    {
        public Step_60_Roles(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        // ReSharper disable once InconsistentNaming
        private static readonly Role _clientRole = new Role
        {
            Name = "clientRole",
            Description = "client role"
        };
        
        #endregion

        #region Realm Role

        [Fact, TestPriority(-10)]
        public async Task GetRoleByNameAsync_Realm()
        {
            var result = await _keycloak.GetRoleByNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNull();
            _fixture.Role.Id = result!.Id;
        }

        [Fact]
        public async Task GetRolesAsync_Realm()
        {
            var results = (await _keycloak.GetRolesAsync(_realm)).ToList();
            results.Should().NotBeNullOrEmpty();
            results.Should().ContainSingle(r => r.Id.Equals(_fixture.Role.Id));
        }

        [Fact, TestPriority(2)]
        public async Task AddRoleCompositesAsync_Realm()
        {
            var result = await _keycloak.AddCompositeRolesByNameAsync(_realm, _fixture.Role.Name!, new[] { _fixture.Role });
            result.Should().BeTrue();
        }

        [Fact, TestPriority(3)]
        public async Task GetRoleCompositesAsync_Realm()
        {
            var result = await _keycloak.GetCompositeRolesByNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetRealmRoleCompositesAsync_Realm()
        {
            var result = await _keycloak.GetCompositeRealmRolesByNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetClientRoleCompositesAsync_Realm()
        {
            var result = await _keycloak.GetCompositeClientRolesByNameAsync(_realm, _fixture.Role.Name!, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(4)]
        public async Task RemoveRoleCompositesAsync_Realm()
        {
            var result = await _keycloak.RemoveCompositeRolesByNameAsync(_realm, _fixture.Role.Name!, new[] { _fixture.Role });
            result.Should().BeTrue();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateRoleByNameAsync_Realm()
        {
            var result = await _keycloak.UpdateRoleByNameAsync(_realm, _fixture.Role.Name!, _fixture.Role);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(3)]
        public async Task GetRoleAuthorizationPermissionsInitializedAsync_Realm()
        {
            var result = await _keycloak.GetRoleAuthorizationPermissionsInitializedByNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task SetRoleAuthorizationPermissionsInitializedAsync_Realm()
        {
            var result = await _keycloak.SetRoleAuthorizationPermissionsInitializedByNameAsync(_realm, _fixture.Role.Name!, _fixture.ManagementPermission);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetGroupsWithRoleNameAsync_Realm()
        {
            var result = await _keycloak.GetGroupsWithRoleNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUsersWithRoleNameAsync_Realm()
        {
            var result = await _keycloak.GetUsersWithRoleNameAsync(_realm, _fixture.Role.Name!);
            result.Should().NotBeNull();
        }

        #endregion

        #region Client Role

        [Fact, TestPriority(-11)]
        public async Task CreateRoleAsync_Client()
        {
            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId!)).Single();
            var result = await _keycloak.CreateClientRoleAsync(_realm, _fixture.Client.Id!, _clientRole);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(-10)]
        public async Task GetRoleByNameAsync_Client()
        {
            var result = await _keycloak.GetClientRoleByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNull();
            _clientRole.Id = result!.Id;
        }

        [Fact]
        public async Task GetRolesAsync_Client()
        {
            var results = (await _keycloak.GetClientRolesAsync(_realm, _fixture.Client.Id!)).ToList();
            results.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(2)]
        public async Task AddRoleCompositesAsync_Client()
        {
            var result = await _keycloak.AddCompositeRolesByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!, new[] { _clientRole });
            result.Should().BeTrue();
        }

        [Fact, TestPriority(3)]
        public async Task GetRoleCompositesAsync_Client()
        {
            var result = await _keycloak.GetCompositeRolesByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetClientRoleCompositesAsync_Client()
        {
            var result = await _keycloak.GetCompositeClientRolesByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!, _fixture.Client.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(4)]
        public async Task RemoveRoleCompositesAsync_Client()
        {
            var result = await _keycloak.RemoveCompositeRolesByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!, new[] { _clientRole });
            result.Should().BeTrue();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateRoleByNameAsync_Client()
        {
            var result = await _keycloak.UpdateClientRoleByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!, _clientRole);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetRealmRoleCompositesAsync_Client()
        {
            var result = await _keycloak.GetCompositeRealmRolesByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetGroupsWithClientRoleNameAsync_Client()
        {
            var result = await _keycloak.GetGroupsWithRoleNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(3)]
        public async Task GetClientRoleAuthorizationPermissionsInitializedAsync_Client()
        {
            var result = await _keycloak.GetClientRoleAuthorizationPermissionsInitializedByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task SetRoleAuthorizationPermissionsInitializedAsync_Client()
        {
            var result = await _keycloak.SetClientRoleAuthorizationPermissionsInitializedByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!, _fixture.ManagementPermission);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUsersWithRoleNameAsync_Client()
        {
            var result = await _keycloak.GetUsersWithRoleNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(10)]
        public async Task DeleteRoleByNameAsync_Client()
        {
            var result = await _keycloak.DeleteClientRoleByNameAsync(_realm, _fixture.Client.Id!, _clientRole.Name!);
            result.Should().BeTrue();
        }

        #endregion
    }
}
