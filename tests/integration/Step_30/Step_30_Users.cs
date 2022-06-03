using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Users;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for 'Users' management.
    /// </summary>
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    [TestPriority(30)]
    public class Step_30_Users : KeycloakClientTests
    {
        public Step_30_Users(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static UserProfiles _userProfiles;
        private static ManagementPermission _managementPermission;

        #endregion

        [Fact, TestPriority(-10)]
        public async Task GetUsersAsync()
        {
            var result = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName)).Single();
            result.Should().NotBeNull();
            result.UserName.Should().Be(_fixture.User.UserName);
            _fixture.User.Id = result.Id;
        }

        [Fact]
        public async Task GetUserAsync()
        {
            var result = await _keycloak.GetUserByIdAsync(_realm, _fixture.User.Id!);
            result.Should().BeEquivalentTo(_fixture.User,
                opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.User)));
        }

        [Fact, TestPriority(-1)]
        public async Task GetUserCredentials()
        {
            var result = (await _keycloak.GetUserCredentials(_realm, _fixture.User.Id!)).Single();
            result.Should().NotBeNull();
            _fixture.Credential.Id = result.Id;
        }

        [Fact]
        public async Task GetUsersCountAsync()
        {
            int? result = await _keycloak.GetUsersCountAsync(_realm);
            result.Should().Be(1);
        }

        [Fact(Skip ="Not working")]
        public async Task GetUserProfileAsync()
        {
            _userProfiles = await _keycloak.GetUserProfileAsync(_realm);
            var profiles = _userProfiles.Attributes!.Select(_ => _.Name);
            profiles.Should().Contain(new[]
            {
                "username",
                "email",
                "firstName",
                "lastName"
            });
        }

        [Fact(Skip = "Not working"), TestPriority(2)]
        public async Task UpdateUserProfileAsync()
        {
            var profile = await _keycloak.UpdateUserProfileAsync(_realm, _userProfiles);
            profile.Should().BeTrue();
        }

        [Fact, TestPriority(1)]
        public async Task UpdateUserAsync()
        {
            var result = await _keycloak.UpdateUserByIdAsync(_realm, _fixture.User.Id!, _fixture.User);
            result.Should().BeTrue();

            // Assert
            var user = await _keycloak.GetUserByIdAsync(_realm, _fixture.User.Id!);
            user.Should().BeEquivalentTo(_fixture.User,
                opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.User)));
        }
        
        [Fact]
        public async Task GetUserCredentialTypesAsync()
        {
            var result = await _keycloak.GetUserCredentialTypesAsync(_realm, _fixture.User.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetUserConsentsAsync()
        {
            var result = await _keycloak.GetUserConsentsAsync(_realm, _fixture.User.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = "not working")]
        public async Task RevokeUserConsentAndOfflineTokensAsync()
        {
            var result = await _keycloak
                .RevokeUserConsentAndOfflineTokensAsync(_realm, _fixture.User.Id!, _fixture.Client.Id!)
                ;
            result.Should().BeFalse();
        }
        
        [Fact]
        public async Task MoveUserCredentialToBehind()
        {
            var result = await _keycloak.MoveUserCredentialToBehind(_realm, _fixture.User.Id!, _fixture.Credential.Id!, _fixture.Credential.Id!);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task MoveUserCredentialToFirst()
        {
            var result = await _keycloak.MoveUserCredentialToFirst(_realm, _fixture.User.Id!, _fixture.Credential.Id!);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateUserCredentialLabel()
        {
            var result = await _keycloak.UpdateUserCredentialLabel(_realm, _fixture.User.Id!, _fixture.Credential.Id!, "userLabel");
            result.Should().BeTrue();
        }
        
        [Fact]
        public async Task GetUserSocialLoginsAsync()
        {
            var result = await _keycloak.GetUserSocialLoginsAsync(_realm, _fixture.User.Id!);
            result.Should().BeEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetUserGroupsAsync()
        {
            var groups = await _keycloak.GetUserGroupsAsync(_realm, _fixture.User.Id!, search: _fixture.Group.Name);
            groups.Should().NotBeNullOrEmpty();
        }

        [Fact, TestPriority(3)]
        public async Task GetUserGroupsCountAsync()
        {
            var count = await _keycloak.GetUserGroupsCountAsync(_realm, _fixture.User.Id!);
            count.Should().Be(1);
        }

        [Fact, TestPriority(2)]
        public async Task UpdateUserGroupAsync()
        {
            _fixture.Group = (await _keycloak.GetGroupsAsync(_realm)).Single(g => g.Name!.Equals(_fixture.Group.Name));
            var result = await _keycloak.UpdateUserGroupAsync(_realm, _fixture.User.Id!, _fixture.Group.Id!);
            result.Should().BeTrue();
        }
        
        [Fact]
        public async Task ImpersonateUserAsync()
        {
            var result = await _keycloak.ImpersonateUserAsync(_realm, _fixture.User.Id!);
            result.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async Task GetUserSessionsAsync()
        {
            var result = await _keycloak.GetUserSessionsAsync(_realm, _fixture.User.Id!);
            result.Should().NotBeNull();
        }
        [Fact]
        public async Task ClearUserCacheAsync()
        {
            var result = await _keycloak.ClearUserCacheAsync(_realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetRealmUsersManagementPermissionsAsync()
        {
            _managementPermission = await _keycloak.GetRealmUsersManagementPermissionsAsync(_realm);
            _managementPermission.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task UpdateRealmUsersManagementPermissionsAsync()
        {
            var result = await _keycloak.UpdateRealmUsersManagementPermissionsAsync(_realm, _managementPermission);
            result.Should().BeEquivalentTo(_managementPermission);
        }

    }
}