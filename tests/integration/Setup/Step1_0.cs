using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.RealmsAdmin;
using Keycloak.Net.Model.Roles;
using Keycloak.Net.Model.Users;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer("Keycloak.Net.Tests.DisplayNameOrderer", "Keycloak.Net.Tests")]
namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Setup pre-requisites for the integration test
    /// </summary>
    [Collection(KeycloakClientTests.Setup)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Step1_0
    {
        public Step1_0(KeycloakFixture fixture)
        {
            _fixture = fixture;
            _keycloak = fixture.AdminCliClient;

            _realm = fixture.Realm._Realm;
            _masterRealm = fixture.MasterRealm;
        }

        #region Properties

        private readonly KeycloakFixture _fixture;
        private readonly KeycloakClient _keycloak;
        private readonly string _realm;
        private readonly string _masterRealm;

        private static Client _realmManagementClient = new Client
        {
            // https://stackoverflow.com/questions/56743109/keycloak-create-admin-user-in-a-realm
            ClientId = "realm-management"
        };
        private static User _testClientUser;
        private static IEnumerable<Role> _availableClientRoles;

        #endregion

        [Fact, TestCasePriority(10)]
        public async Task CreateTestRealmAsync()
        {
            var result = await _keycloak.CreateRealmAsync(_masterRealm, _fixture.Realm);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(11)]
        public async Task ImportTestRealmAsync()
        {
            var result = await _keycloak.ImportRealmAsync(_realm, new Realm
            {
                Id = "testRealm",
                _Realm = "testRealm",
                Enabled = true
            });
            result.Should().BeTrue();
            await _keycloak.DeleteRealmAsync(_realm, "testRealm");
        }

        [Fact, TestCasePriority(20)]
        public async Task CreateTestClientAsync()
        {
            var result = await _keycloak.CreateClientAsync(_realm, _fixture.Client);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(21)]
        public async Task GetTestClientAsync()
        {
            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId))!.Single();
            _fixture.Client.Should().NotBeNull();
            _fixture.Client.Id.Should().NotBeNullOrEmpty();
            _fixture.Client.ClientId.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(22)]
        public async Task GetServiceAccountUserForTestClientAsync()
        {
            _realmManagementClient = (await _keycloak.GetClientsAsync(_realm, _realmManagementClient.ClientId))!.Single();
            _testClientUser = await _keycloak.GetServiceAccountUserForClientAsync(_realm, _fixture.Client.Id);
            _testClientUser.Should().NotBeNull();
        }

        [Fact, TestCasePriority(23)]
        public async Task AssignRolesToTestClientUserAsync()
        {
            _availableClientRoles = (await _keycloak.GetAvailableClientRolesForUserAsync(_realm, _testClientUser.Id, _realmManagementClient.Id)).ToList();
            _availableClientRoles.Should().NotBeNullOrEmpty();

            var result = await _keycloak.AddClientRolesToUserAsync(_realm, _testClientUser.Id, _realmManagementClient.Id, _availableClientRoles);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(24)]
        public async Task AssignRolesToTestClientScopeAsync()
        {
            _availableClientRoles = (await _keycloak.GetAvailableClientRolesForClientAsync(_realm, _fixture.Client.Id, _realmManagementClient.Id)).ToList();
            _availableClientRoles.Should().NotBeNullOrEmpty();

            var result = await _keycloak.AddClientRolesToClientAsync(_realm, _fixture.Client.Id, _realmManagementClient.Id, _availableClientRoles);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(30)]
        public async Task CreateAdminUserAsync()
        {
            var result = await _keycloak.CreateUserAsync(_realm, _fixture.User);
            result.Should().BeTrue();
        }
        
        [Fact, TestCasePriority(31)]
        public async Task ResetAdminUserPasswordAsync()
        {
            _fixture.User = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName))!.Single();
            var result = await _keycloak.ResetUserPasswordAsync(_realm, _fixture.User.Id, _fixture.Credential);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(32)]
        public async Task AssignRolesToAdminUserAsync()
        {
            _availableClientRoles = (await _keycloak.GetAvailableClientRolesForUserAsync(_realm, _fixture.User.Id, _realmManagementClient.Id)).ToList();
            _availableClientRoles.Should().NotBeNullOrEmpty();

            var result = await _keycloak.AddClientRolesToUserAsync(_realm, _fixture.User.Id, _realmManagementClient.Id, _availableClientRoles);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(40)]
        public async Task CreateAdminGroupAsync()
        {
            var result = await _keycloak.CreateGroupAsync(_realm, _fixture.Group);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(50)]
        public async Task CreateAdminRoleAsync()
        {
            var result = await _keycloak.CreateRoleAsync(_realm, _fixture.Role);
            result.Should().BeTrue();
        }
    }
}
