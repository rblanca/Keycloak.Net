using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Groups;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for 'Groups' management.
    /// </summary>
    [Collection(KeycloakClientTests.Groups)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Step4_0
    {
        public Step4_0(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private readonly Group _subGroup = new Group()
        {
            Name = "subGroup",
            Path = "/path/subGroup"
        };

        #endregion

        [Fact, TestCasePriority(-10)]

        public async Task GetGroupHierarchyAsync()
        {
            var result = (await _keycloak.GetGroupsAsync(_realm)).ToList();
            result.Should().NotBeNullOrEmpty();
            _fixture.Group.Id = result!.First(g => g.Name!.Equals(_fixture.Group.Name)).Id;
        }

        [Fact]
        public async Task GetGroupAsync()
        {
            var result = await _keycloak.GetGroupAsync(_realm, _fixture.Group.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        
        public async Task GetGroupsCountAsync()
        {
            var result = await _keycloak.GetGroupsCountAsync(_realm);
            result.Should().BeGreaterThan(0);
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateGroupAsync()
        {
            var result = await _keycloak.UpdateGroupAsync(_realm, _fixture.Group.Id!, _fixture.Group);
            result.Should().BeTrue();
        }
        
        [Fact]
        public async Task SetOrCreateGroupChildAsync()
        {
            var result = await _keycloak.SetOrCreateGroupChildAsync(_realm, _fixture.Group.Id!, _subGroup);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetGroupClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.GetGroupClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Group.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(2)]
        public async Task SetGroupClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.SetGroupClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Group.Id!, _fixture.ManagementPermission);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetGroupUsersAsync()
        {
            var result = await _keycloak.GetGroupUsersAsync(_realm, _fixture.Group.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRealmGroupHierarchyAsync()
        {
            var result = await _keycloak.GetRealmGroupHierarchyAsync(_realm);
            result.Should().NotBeNull();
        }
    }
}
