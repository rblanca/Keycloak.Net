﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Roles;

namespace Keycloak.Net
{
    public partial class KeycloakClient
	{
		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings <br/>
		/// Get the specified client scope mappings by id in this realm.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		public async Task<Mapping> GetClientScopeMappingsForRealmAsync(string realm, string clientScopeId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings")
			.GetJsonAsync<Mapping>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// POST /{realm}/client-scopes/{clientScopeId}/scope-mappings/realm <br/>
		/// Add a set of realm-level roles to the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="roles">set of roles to add</param>
		public async Task<bool> AddRealmRolesToClientScopeAsync(string realm, string clientScopeId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/realm")
				.PostJsonAsync(roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/realm <br/>
		/// Get realm-level roles associated with the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		public async Task<IEnumerable<Role>> GetRealmRolesForClientScopeAsync(string realm, string clientScopeId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/realm")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// DELETE /{realm}/client-scopes/{clientScopeId}/scope-mappings/realm <br/>
		/// Remove a set of realm-level roles from the client’s scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="roles"></param>
		public async Task<bool> RemoveRealmRolesFromClientScopeAsync(string realm, string clientScopeId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/realm")
				.SendJsonAsync(HttpMethod.Delete, roles)
				.ConfigureAwait(false);
			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/realm/available <br/>
		/// Get realm-level roles that are available to attach to this client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		public async Task<IEnumerable<Role>> GetAvailableRealmRolesForClientScopeAsync(string realm, string clientScopeId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/realm/available")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/realm/composite <br/>
		/// Get effective realm-level roles associated with the client's scope.
		/// What this does is to recurse any composite roles associated with the client's scope and adds the roles to this lists.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="briefRepresentation">if false, return roles with their attributes. Default: true</param>
		/// <remarks>The method is really to show a comprehensive total view of realm-level roles associated with the client.</remarks>
		public async Task<IEnumerable<Role>> GetEffectiveRealmRolesForClientScopeAsync(
			string realm, string clientScopeId, 
			bool? briefRepresentation= null)
		{
			var queryParams = new Dictionary<string, object?>
			{
				[nameof(briefRepresentation)] = briefRepresentation
			};

			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/realm/composite")
			.SetQueryParams(queryParams)
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}
	}
}