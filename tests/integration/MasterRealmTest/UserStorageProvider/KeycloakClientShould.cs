﻿using Keycloak.Net.Model.UserStorageProvider;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests.MasterRealmTest
{
    public partial class KeycloakClientShould
    {
        [Theory(Skip = "Not working yet")]
        [InlineData("master")]
        public async Task TriggerUserSynchronizationAsync(string realm)
        {
            string storageProviderId = "";
            var result = await _client.TriggerUserSynchronizationAsync(realm, storageProviderId, UserSyncActions.Full);
            Assert.NotNull(result);
        }

        [Theory(Skip = "Not working yet")]
        [InlineData("master")]
        public async Task TriggerLdapMapperSynchronizationAsync(string realm)
        {
            string storageProviderId = "";
            string mapperId = "";
            var result = await _client.TriggerLdapMapperSynchronizationAsync(realm, storageProviderId, mapperId, LdapMapperSyncActions.KeycloakToFed);
            Assert.NotNull(result);
        }
    }
}
