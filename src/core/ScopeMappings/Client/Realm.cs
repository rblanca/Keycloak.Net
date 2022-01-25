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
		/// POST /{realm}/clients/{clientId}/scope-mappings/realm <br/>
		/// Add a set of realm-level roles to the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="roles"></param>
		public async Task<bool> AddRealmRolesToClientAsync(string realm, string clientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/realm")
				.PostJsonAsync(roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/realm <br/>
		/// Get realm-level roles associated with the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		public async Task<IEnumerable<Role>> GetRealmRolesForClientAsync(string realm, string clientId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/realm")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// DELETE /{realm}/clients/{clientId}/scope-mappings/realm <br/>
		/// Remove a set of realm-level roles from the client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <param name="roles"></param>
		public async Task<bool> RemoveRealmRolesFromClientAsync(string realm, string clientId, IEnumerable<Role> roles)
		{
			var response = await GetBaseUrl()
				.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/realm")
				.SendJsonAsync(HttpMethod.Delete, roles)
				.ConfigureAwait(false);

			return response.ResponseMessage.IsSuccessStatusCode;
		}

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/realm/available <br/>
		/// Get realm-level roles that are available to attach to this client's scope.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <remarks>The method is really to show a comprehensive total view of realm-level roles associated with the client.</remarks>
		public async Task<IEnumerable<Role>> GetAvailableRealmRolesForClientAsync(string realm, string clientId)
		{
			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/realm/available")
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// GET /{realm}/clients/{clientId}/scope-mappings/realm/composite <br/>
		/// Get effective realm-level roles associated with the client’s scope.
		/// What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
		/// </summary>
		/// <param name="realm">realm name (not id!)</param>
		/// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
		/// <remarks>The method is really to show a comprehensive total view of realm-level roles associated with the client.</remarks>
		public async Task<IEnumerable<Role>> GetEffectiveRealmRolesForClientAsync(
			string realm, string clientId,
			bool? briefRepresentation = null)
		{
			var queryParams = new Dictionary<string, object?>
			{
				[nameof(briefRepresentation)] = briefRepresentation
			};

			var response = await GetBaseUrl()
			.AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/scope-mappings/realm/composite")
			.SetQueryParams(queryParams)
			.GetJsonAsync<IEnumerable<Role>>()
			.ConfigureAwait(false);

			return response;
		}
	}
}
