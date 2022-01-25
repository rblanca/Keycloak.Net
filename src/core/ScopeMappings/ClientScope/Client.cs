using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Roles;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net
{
    public partial class KeycloakClient
	{
		/// <summary>
		/// POST /{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId} <br/>
		/// Add client-level roles to the client's scope.
		/// </summary>
		/// <param name="realm"></param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="clientId">realm name (not id!)</param>
		/// <param name="roles"></param>
		public async Task<bool> AddClientRolesToClientScopeAsync(string realm, string clientScopeId, string clientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}")
				.PostJsonAsync(roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId} <br/>
		/// Get the client-level roles associated with a client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <returns>Returns roles for the client.</returns>
		public async Task<IEnumerable<Role>> GetClientRolesForClientScopeAsync(string realm, string clientScopeId, string clientId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// DELETE /{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId} <br/>
		/// Remove client-level roles from the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="roles"></param>
		public async Task<bool> RemoveClientRolesFromClientScopeAsync(string realm, string clientScopeId, string clientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}")
				.SendJsonAsync(HttpMethod.Delete, roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}/available <br/>
		/// The available client-level roles for the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <returns>Returns the roles for the client that can be associated with the client’s scope.</returns>
		public async Task<IEnumerable<Role>> GetAvailableClientRolesForClientScopeAsync(string realm, string clientScopeId, string clientId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}/available")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// GET /{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}/composite <br/>
		/// Get effective client roles.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientScopeId">id of client scope (not name)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="briefRepresentation">if false, return roles with their attributes. Default: true</param>
		/// <returns>Returns the roles for the client that are associated with the client’s scope.</returns>
		public async Task<IEnumerable<Role>> GetEffectiveClientRolesForClientScopeAsync(
			string realm, string clientScopeId, string clientId,
			bool? briefRepresentation = null)
		{
			var queryParams = new Dictionary<string, object?>
			{
				[nameof(briefRepresentation)] = briefRepresentation
			};

			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/scope-mappings/clients/{clientId}/composite")
			.SetQueryParams(queryParams)
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

	}
}
