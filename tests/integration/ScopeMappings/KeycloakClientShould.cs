using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("master")]
        public async Task GetScopeMappingsAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetClientScopeMappingsForRealmAsync(realm, clientScopeId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetClientRolesForClientScopeAsync(realm, clientScopeId, clientId).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetAvailableClientRolesForClientScopeAsync(realm, clientScopeId, clientId).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetEffectiveClientRolesForClientScopeAsync(realm, clientScopeId, clientId).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetRealmRolesForClientScopeAsync(realm, clientScopeId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetAvailableRealmRolesForClientScopeAsync(realm, clientScopeId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm).ConfigureAwait(false);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetEffectiveRealmRolesForClientScopeAsync(realm, clientScopeId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetClientScopeMappingsForClientAsync(realm, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetClientRolesScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetClientRolesForClientAsync(realm, clientId, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableClientRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetAvailableClientRolesForClientAsync(realm, clientId, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveClientRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetEffectiveClientRolesForClientAsync(realm, clientId, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetRealmRolesScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetRealmRolesForClientAsync(realm, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableRealmRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetAvailableRealmRolesForClientAsync(realm, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveRealmRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetEffectiveRealmRolesForClientAsync(realm, clientId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
    }
}
