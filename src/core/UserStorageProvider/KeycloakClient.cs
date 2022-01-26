﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.UserStorageProvider;

namespace Keycloak.Net
{
    /// <remarks>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_user_storage_provider_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        [Obsolete("Not working yet")]
        public async Task<bool> RemoveImportedUsersAsync(string realm, string storageProviderId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/remove-imported-users")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        [Obsolete("Not working yet")]
        public async Task<SynchronizationResult> TriggerUserSynchronizationAsync(string realm, string storageProviderId, UserSyncActions action)
        {
            var response = await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/sync")
            .SetQueryParam(nameof(action), action == UserSyncActions.Full ? "triggerFullSync" : "triggerChangedUsersSync")
            .PostAsync(new StringContent(""))
            .ReceiveJson<SynchronizationResult>()
            .ConfigureAwait(false);

            return response;
        }

        [Obsolete("Not working yet")]
        public async Task<bool> UnlinkImportedUsersAsync(string realm, string storageProviderId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/unlink-users")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        [Obsolete("Not working yet")]
        public async Task<SynchronizationResult> TriggerLdapMapperSynchronizationAsync(
            string realm, string storageProviderId, string mapperId, LdapMapperSyncActions direction)
        {
            var response = await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/mappers/{mapperId}/sync")
            .SetQueryParam(nameof(direction), direction == LdapMapperSyncActions.FedToKeycloak ? "fedToKeycloak" : "keycloakToFed")
            .PostAsync(new StringContent(""))
            .ReceiveJson<SynchronizationResult>()
            .ConfigureAwait(false);

            return response;
        }
    }
}