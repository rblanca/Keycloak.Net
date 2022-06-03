using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests.MasterRealmTest
{
    public partial class KeycloakClientShould
    {
        [Theory(Skip = "Not Working")]
        [InlineData("master")]
        public async Task GetComponentsAsync(string realm)
        {
            var result = await _client.GetComponentsAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory(Skip = "Not Working")]
        [InlineData("master")]
        public async Task GetComponentAsync(string realm)
        {
            var components = await _client.GetComponentsAsync(realm).ConfigureAwait(false);
            string componentId = components.FirstOrDefault()?.Id;
            if (componentId != null)
            {
                var result = await _client.GetComponentByIdAsync(realm, componentId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
    }
}
