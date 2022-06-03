using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Groups;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    /// <summary>
    /// Integration tests for 'Groups' management.
    /// </summary>
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    [TestPriority(40)]
    public class Step_40_Groups: KeycloakClientTests
    {
        public Step_40_Groups(KeycloakFixture fixture)
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

        [Fact, TestPriority(-10)]

        public async Task GetGroupHierarchyAsync()
        {
            var result = (await _keycloak.GetGroupsAsync(_realm)).ToList();
            result.Should().NotBeNullOrEmpty();
            _fixture.Group.Id = result!.First(g => g.Name!.Equals(_fixture.Group.Name)).Id;
        }

        [Fact]
        public async Task GetGroupAsync()
        {
            var result = await _keycloak.GetGroupByIdAsync(_realm, _fixture.Group.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        
        public async Task GetGroupsCountAsync()
        {
            var result = await _keycloak.GetGroupsCountAsync(_realm);
            result.Should().BeGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task UpdateGroupAsync()
        {
            var result = await _keycloak.UpdateGroupByIdAsync(_realm, _fixture.Group.Id!, _fixture.Group);
            result.Should().BeTrue();
        }
        
        [Fact]
        public async Task SetOrCreateGroupChildAsync()
        {
            var result = await _keycloak.SetOrCreateGroupChildAsync(_realm, _fixture.Group.Id!, _subGroup);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(3)]
        public async Task GetGroupClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.GetGroupClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Group.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task SetGroupClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.SetGroupClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Group.Id!, _fixture.ManagementPermission);
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(3)]
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
