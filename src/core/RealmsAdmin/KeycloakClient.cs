using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.ClientScopes;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Model.Ldap;
using Keycloak.Net.Model.RealmsAdmin;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST / <br/>
        /// Imports a realm from a full representation of that realm
        /// </summary>
        /// <remarks>Realm name must be unique.</remarks>
        public async Task<bool> ImportRealmAsync(string realm, Realm realmConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment("/admin/realms")
                .PostJsonAsync(realmConfig)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm} <br/>
        /// Create the top-level information of the realm. Any user, roles or client information in the representation will be ignored.
        /// </summary>
        /// <remarks>This will only update top-level attributes of the realm.</remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="realmConfig"></param>
        public async Task<bool> CreateRealmAsync(string realm, Realm realmConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms")
                .PostJsonAsync(realmConfig)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /realms <br/>
        /// </summary>
        public async Task<IEnumerable<Realm>?> GetRealmsAsync()
        {
            var response = await GetBaseUrl()
                .AppendPathSegment("/admin/realms")
                .GetJsonAsync<IEnumerable<Realm>>()
                .ConfigureAwait(false);
            return response;
        }
        
        /// <summary>
        /// GET /{realm} <br/>
        /// Get the top-level representation of the realm. It will not include nested information like User and Client representations.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<Realm?> GetRealmAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}")
                .GetJsonAsync<Realm>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// PUT /{realm} <br/>
        /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
        /// </summary>
        /// <remarks>This will only update top-level attributes of the realm.</remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="realmConfig"></param>
        public async Task<bool> UpdateRealmAsync(string realm, Realm realmConfig)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}")
                .PutJsonAsync(realmConfig)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm} <br/>
        /// Delete the realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="realmToDelete">realm name (not id!) to be deleted.</param>
        public async Task<bool> DeleteRealmAsync(string realm, string realmToDelete)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realmToDelete}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/admin-events <br/>
        /// Get admin events Returns all admin events, or filters events based on URL query parameters listed here.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="authClient"></param>
        /// <param name="authIpAddress"></param>
        /// <param name="authRealm"></param>
        /// <param name="authUser">user id</param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="first"></param>
        /// <param name="max">Maximum results size (defaults to 100)</param>
        /// <param name="operationTypes"></param>
        /// <param name="resourcePath"></param>
        /// <param name="resourceTypes"></param>
        public async Task<IEnumerable<AdminEvent>?> GetAdminEventsAsync(
            string realm, 
            string? authClient = null, 
            string? authIpAddress = null, 
            string? authRealm = null, 
            string? authUser = null,
            string? dateFrom = null, 
            string? dateTo = null, 
            int? first = null, 
            int? max = null, 
            IEnumerable<string>? operationTypes = null, 
            string? resourcePath = null, 
            IEnumerable<string>? resourceTypes = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(authClient)] = authClient,
                [nameof(authIpAddress)] = authIpAddress,
                [nameof(authRealm)] = authRealm,
                [nameof(authUser)] = authUser,
                [nameof(dateFrom)] = dateFrom,
                [nameof(dateTo)] = dateTo,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(operationTypes)] = operationTypes == null ? null : string.Join(",", operationTypes),
                [nameof(resourcePath)] = resourcePath,
                [nameof(resourceTypes)] = resourceTypes == null ? null : string.Join(",", resourceTypes)
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/admin-events")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<AdminEvent>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/admin-events <br/>
        /// Delete all admin events.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> DeleteAdminEventsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/admin-events")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clear-keys-cache <br/>
        /// Clear cache of external public keys (Public keys of clients or Identity providers).
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> ClearKeysCacheAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clear-keys-cache")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clear-realm-cache <br/>
        /// Clear realm cache.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> ClearRealmCacheAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clear-realm-cache")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clear-user-cache <br/>
        /// Clear user cache.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> ClearUserCacheAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clear-user-cache")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/client-description-converter <br/>
        /// Base path for importing clients under this realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="description"></param>
        public async Task<Client> BasePathForImportingClientsAsync(string realm, string description)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-description-converter")
                .PostAsync(new StringContent(description))
                .ReceiveJson<Client>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/client-policies/policies <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<ClientPolicies> GetClientPolicies(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-policies/policies")
                .GetJsonAsync<ClientPolicies>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/client-policies/policies
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientPolicies"></param>
        public async Task<bool> UpdateClientPolicies(string realm, ClientPolicies clientPolicies)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-policies/policies")
                .PutJsonAsync(clientPolicies)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/client-policies/profiles <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="includeGlobalProfiles"></param>
        /// <returns></returns>
        public async Task<ClientProfiles> GetClientProfiles(string realm, bool? includeGlobalProfiles = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                ["include-global-profiles"] = includeGlobalProfiles
            };
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-policies/profiles")
                .SetQueryParams(queryParams)
                .GetJsonAsync<ClientProfiles>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/client-policies/profiles <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientProfiles"></param>
        /// <returns></returns>
        public async Task<bool> UpdateClientProfiles(string realm, ClientProfiles clientProfiles)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-policies/profiles")
                .PutJsonAsync(clientProfiles)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/client-session-stats <br/>
        /// Get client session stats. Returns a JSON map.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <returns>
        /// The key is the client id, the value is the number of sessions that currently are active with that client.
        /// Only clients that actually have a session associated with them will be in this map.
        /// </returns>
        public async Task<IEnumerable<IDictionary<string, object>>> GetClientSessionStatsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-session-stats")
                .GetJsonAsync<IEnumerable<IDictionary<string, object>>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/    dential-registrators <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<string>> GetCredentialRegistrators(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/credential-registrators")
                .GetJsonAsync<IEnumerable<string>>()
                .ConfigureAwait(false);
            return response;
        }


        /// <summary>
        /// GET /{realm}/client-scopes <br/>
        /// Get client scopes belonging to the realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <returns>Returns a list of client scopes belonging to the realm.</returns>
        public async Task<IEnumerable<ClientScope>> GetRealmClientScopesAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }


        /// <summary>
        /// GET /{realm}/default-default-client-scopes <br/>
        /// Get realm default client scopes.
        /// </summary>
        /// <remarks>Only name and ids are returned.</remarks>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<ClientScope>> GetRealmDefaultClientScopesAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-default-client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/default-default-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> UpdateRealmDefaultClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-default-client-scopes/{clientScopeId}")
                .PutAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/default-default-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRealmDefaultClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-default-client-scopes/{clientScopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/default-groups <br/>
        /// Get group hierarchy. Only name and ids are returned.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<Group>> GetRealmGroupHierarchyAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-groups")
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/default-groups/{groupId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        public async Task<bool> UpdateRealmGroupAsync(string realm, string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-groups/{groupId}")
                .PutAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/default-groups/{groupId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRealmGroupAsync(string realm, string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-groups/{groupId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/default-optional-client-scopes <br/>
        /// Get realm optional client scopes.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<IEnumerable<ClientScope>> GetRealmOptionalClientScopesAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-optional-client-scopes")
                .GetJsonAsync<IEnumerable<ClientScope>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/default-optional-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> UpdateRealmOptionalClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}")
                .PutAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/default-optional-client-scopes/{clientScopeId} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientScopeId"></param>
        public async Task<bool> DeleteRealmOptionalClientScopeAsync(string realm, string clientScopeId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/events <br/>
        /// Get events.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="client">App or oauth client name</param>
        /// <param name="dateFrom">From date</param>
        /// <param name="dateTo">To date</param>
        /// <param name="first">Paging offset</param>
        /// <param name="ipAddress">IP address</param>
        /// <param name="max">Maximum results size (defaults to 100)</param>
        /// <param name="type">The types of events to return</param>
        /// <param name="user">User id</param>
        /// <returns>Returns all events, or filters them based on URL query parameters listed here.</returns>
        public async Task<IEnumerable<Event>> GetEventsAsync(
            string realm, 
            string? client = null, 
            string? dateFrom = null, 
            string? dateTo = null, 
            int? first = null, 
            string? ipAddress = null, 
            int? max = null, 
            string? type = null, 
            string? user = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(client)] = client,
                [nameof(dateFrom)] = dateFrom,
                [nameof(dateTo)] = dateTo,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(ipAddress)] = ipAddress,
                [nameof(type)] = type,
                [nameof(user)] = user
            };

            return await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/events")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Event>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// DELETE /{realm}/events <br/>
        /// Delete all events.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> DeleteEventsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/events")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/events/config <br/>
        /// Get the events provider configuration. Returns JSON object with events provider configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<RealmEventsConfig> GetRealmEventsProviderConfigurationAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/events/config")
                .GetJsonAsync<RealmEventsConfig>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/events/config <br/>
        /// Update the events provider. Change the events provider and/or its configuration.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<bool> UpdateRealmEventsProviderConfigurationAsync(string realm, RealmEventsConfig config)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/events/config")
                .PutJsonAsync(config)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/group-by-path/{path} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<Group> GetRealmGroupByPathAsync(string realm, string path)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/group-by-path/{path}")
                .GetJsonAsync<Group>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/ldap-server-capabilities <br/>
        /// Get LDAP supported extensions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="config">LDAP configuration</param>
        public async Task<bool> GetLdapSupportedExtensions(string realm, TestLdapConnection config)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/ldap-server-capabilities")
                .PostJsonAsync(config)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/localization <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<object> GetRealmLocalization(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization")
                .GetJsonAsync<object>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/localization/{locale} <br/>
        /// Import localization from uploaded JSON file.
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="input"></param>
        public async Task<object> ImportRealmLocalizationLocale(string locale, string realm, object input)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization")
                .PostJsonAsync(input)
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/localization/{locale} <br/>
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<object> GetRealmLocalizationLocale(string locale, string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}")
                .GetJsonAsync<object>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/localization/{locale} <br/>
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> DeleteRealmLocalizationLocale(string locale, string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// PATCH /{realm}/localization/{locale} <br/>
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="localizationTexts"></param>
        public async Task<bool> PatchRealmLocalizationLocale(string locale, string realm, object localizationTexts)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}")
                .PatchJsonAsync(localizationTexts)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/localization/{locale}/{key} <br/>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<string> GetRealmLocalizationKey(string key, string locale, string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}/{key}")
                .GetStringAsync()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/localization/{locale}/{key} <br/>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> PutRealmLocalizationKey(string key, string locale, string realm, string text)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}/{key}")
                .PutStringAsync(text)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/localization/{locale}/{key} <br/>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="locale"></param>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<bool> DeleteRealmLocalizationKey(string key, string locale, string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/localization/{locale}/{key}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/logout-all <br/>
        /// Removes all user sessions.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<GlobalRequestResult> RemoveUserSessionsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/logout-all")
                .PostAsync()
                .ReceiveJson<GlobalRequestResult>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/partial-export <br/>
        /// Partial export of existing realm into a JSON file.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="exportClients"></param>
        /// <param name="exportGroupsAndRoles"></param>
        public async Task<Realm> RealmPartialExportAsync(
            string realm,
            bool? exportClients = null, 
            bool? exportGroupsAndRoles = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(exportClients)] = exportClients,
                [nameof(exportGroupsAndRoles)] = exportGroupsAndRoles,
            };

            return await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/partial-export")
                .SetQueryParams(queryParams)
                .PostAsync()
                .ReceiveJson<Realm>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// POST /{realm}/partialImport <br/>
        /// Partial import from a JSON file to an existing realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="import"></param>
        public async Task<bool> RealmPartialImportAsync(string realm, PartialImport import)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/partialImport")
                .PostJsonAsync(import)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/push-revocation <br/>
        /// Push the realm’s revocation policy to any client that has an admin url associated with it.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<GlobalRequestResult> PushRealmRevocationPolicyAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/push-revocation")
                .PostAsync(new StringContent(""))
                .ReceiveJson<GlobalRequestResult>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// DELETE /{realm}/sessions/{session} <br/>
        /// Remove a specific user session.
        /// </summary>
        /// <remarks>
        /// Any client that has an admin url will also be told to invalidate this particular session.
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="session"></param>
        public async Task<bool> DeleteUserSessionAsync(string realm, string session)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/sessions/{session}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/testLDAPConnection <br/>
        /// Test LDAP connection
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="config"></param>
        public async Task<bool> TestLdapConnectionAsync(string realm, TestLdapConnection config)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/testLDAPConnection")
                .PostJsonAsync(config)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/testSMTPConnection <br/>
        /// Test SMTP connection.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="settings"></param>
        public async Task<bool> TestSmtpConnectionAsync(string realm, IEnumerable<IDictionary<string, object>> settings)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/testSMTPConnection")
                .PostJsonAsync(settings)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/users-management-permissions <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        public async Task<ManagementPermission> GetRealmUsersManagementPermissionsAsync(string realm)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users-management-permissions")
                .GetJsonAsync<ManagementPermission>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/users-management-permissions <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="ref"></param>
        /// <returns></returns>
        public async Task<ManagementPermission> UpdateRealmUsersManagementPermissionsAsync(string realm, ManagementPermission @ref)
        {
            return await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users-management-permissions")
                .PutJsonAsync(@ref)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);
        }
    }
}
