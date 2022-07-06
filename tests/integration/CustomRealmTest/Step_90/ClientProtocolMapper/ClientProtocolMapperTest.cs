using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.ProtocolMappers;
using Xunit;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientProtocolMapperTest : KeycloakClientTests
    {
        public ClientProtocolMapperTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;
       

        #endregion

        [Fact, TestPriority(-12)]
        public async Task CreateClientIfNotExist()
        {
            var allClients = await _keycloak.GetClientsAsync(_realm);
            var testClient = allClients.SingleOrDefault(c => c.Name!.Equals(_fixture.Client.Name));

            if (testClient == null)
            {
                await _keycloak.CreateClientAsync(_realm, _fixture.Client);
            }

            var result = (await _keycloak.GetClientsAsync(_realm)).Single(c => c.Name!.Equals(_fixture.Client.Name));
            result.Should().NotBeNull();
            _fixture.Client = result;
        }

        [Fact, TestPriority(-11)]
        public async Task CreateClientProtocolMapper()
        {
            await _keycloak.CreateClientProtocolMapperAsync(_realm, _fixture.Client.Id, _fixture.ProtocolMappers[0]);
        }

        [Fact, TestPriority(-11)]
        public async Task CreateClientMultipleProtocolMappersAsync()
        {
            await _keycloak.CreateClientMultipleProtocolMappersAsync(_realm, _fixture.Client.Id, new List<ProtocolMapper> { _fixture.ProtocolMappers[1] });
        }

        [Fact, TestPriority(-10)]
        public async Task GetClientProtocolMapperAsync()
        {
            var result = await _keycloak.GetClientProtocolMappersAsync(_realm, _fixture.Client.Id);
            var testClaim1 = result.SingleOrDefault(c => c.Name!.Equals(_fixture.ProtocolMappers[0].Name));
            var testClaim2 = result.SingleOrDefault(c => c.Name!.Equals(_fixture.ProtocolMappers[1].Name));

            testClaim1.Should().NotBeNull();
            testClaim2.Should().NotBeNull();
            _fixture.ProtocolMappers[0] = testClaim1;
            _fixture.ProtocolMappers[1] = testClaim2;
        }

        [Fact, TestPriority(3)]
        public async Task GetClientProtocolMapperByIdAsync()
        {
            foreach(var protocolMapper in _fixture.ProtocolMappers)
            {
                var result = await _keycloak.GetClientProtocolMapperAsync(_realm, _fixture.Client.Id!,protocolMapper.Id);
                result.Should().BeEquivalentTo(protocolMapper,
                    opt => opt.Using(new IgnoreNullMembersInExpectation(protocolMapper)));
            }
        }

        [Fact, TestPriority(2)]
        public async Task UpdateClientProtocolMapperAsync()
        {
            var result = await _keycloak.UpdateClientProtocolMapperAsync(_realm, _fixture.Client.Id!, _fixture.ProtocolMappers[0].Id, _fixture.ProtocolMappers[0]);
            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task DeleteClientProtocolMapperAsync()
        {
            foreach (var protocolMapper in _fixture.ProtocolMappers)
            {
                var result = await _keycloak.DeleteClientProtocolMapperAsync(_realm, _fixture.Client.Id!, protocolMapper.Id);
                result.Should().BeTrue();
            }
        }
    }
}
