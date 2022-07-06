using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.ProtocolMappers;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<bool> CreateClientMultipleProtocolMappersAsync(string realm, string clientId, IEnumerable<ProtocolMapper> protocolMapperRepresentations)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/add-models")
                .PostJsonAsync(protocolMapperRepresentations)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> CreateClientProtocolMapperAsync(string realm, string clientId, ProtocolMapper protocolMapperRepresentation)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/models")
                .PostJsonAsync(protocolMapperRepresentation)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProtocolMapper>> GetClientProtocolMappersAsync(string realm, string clientId) => await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/models")
            .GetJsonAsync<IEnumerable<ProtocolMapper>>()
            .ConfigureAwait(false);

        public async Task<ProtocolMapper> GetClientProtocolMapperAsync(string realm, string clientId, string protocolMapperId) => await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}")
            .GetJsonAsync<ProtocolMapper>()
            .ConfigureAwait(false);

        public async Task<bool> UpdateClientProtocolMapperAsync(string realm, string clientId, string protocolMapperId, ProtocolMapper protocolMapperRepresentation)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}")
                .PutJsonAsync(protocolMapperRepresentation)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteClientProtocolMapperAsync(string realm, string clientId, string protocolMapperId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProtocolMapper>> GetClientProtocolMappersByNameAsync(string realm, string clientId, string protocol) => await GetBaseUrl()
            .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/protocol-mappers/protocol/{protocol}")
            .GetJsonAsync<IEnumerable<ProtocolMapper>>()
            .ConfigureAwait(false);
    }
}
