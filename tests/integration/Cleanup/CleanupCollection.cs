using Xunit;

namespace Keycloak.Net.Tests
{
    [CollectionDefinition(Cleanup)]
    public class CleanupCollection : KeycloakClientTests
    {
    }
}
