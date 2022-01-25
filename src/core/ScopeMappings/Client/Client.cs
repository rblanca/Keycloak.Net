using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Roles;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net
{
	public partial class KeycloakClient
	{
		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/clients <br/>
		/// Get the specified client scope mappings by id for the client.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		public async Task<Mapping> GetClientScopeMappingsForClientAsync(string realm, string clientId)
        {
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings")
			.GetJsonAsync<Mapping>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// POST /{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId} <br/>
		/// Add client-level roles to the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="scopeClientId">id of client which contains the client roles</param>
		public async Task<bool> AddClientRolesToClientAsync(string realm, string clientId, string scopeClientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}")
				.PostJsonAsync(roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId} <br/>
		/// Get the roles associated with a client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="scopeClientId">id of client which contains the client roles</param>
		/// <returns>Returns roles for the client.</returns>
		public async Task<IEnumerable<Role>> GetClientRolesForClientAsync(string realm, string clientId, string scopeClientId)
        {
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// DELETE /{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId} <br/>
		/// Remove client-level roles from the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="scopeClientId">id of client which contains the client roles</param>
		/// <param name="roles"></param>
		public async Task<bool> RemoveClientRolesFromClientAsync(string realm, string clientId, string scopeClientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}")
				.SendJsonAsync(HttpMethod.Delete, roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}/available <br/>
		/// The available client-level roles.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="scopeClientId">id of client which contains the client roles</param>
		/// <returns>Returns the roles for the client that can be associated with the client's scope.</returns>
		public async Task<IEnumerable<Role>> GetAvailableClientRolesForClientAsync(string realm, string clientId, string scopeClientId) => await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}/available")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}/composite <br/>
		/// Get effective client roles.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="scopeClientId">id of client which contains the client roles</param>
		/// <param name="briefRepresentation">if false, return roles with their attributes. Default: true</param>
		/// <returns>Returns the roles for the client that are associated with the client's scope.</returns>
		public async Task<IEnumerable<Role>> GetEffectiveClientRolesForClientAsync(
			string realm, string clientId, string scopeClientId,
			bool? briefRepresentation = null)
        {
			var queryParams = new Dictionary<string, object?>
			{
				[nameof(briefRepresentation)] = briefRepresentation
			};

			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/clients/{scopeClientId}/composite")
			.SetQueryParams(queryParams)
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}
	}
}
