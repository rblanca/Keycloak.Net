using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Keycloak integration tests collection
    /// </summary>
    //[CollectionDefinition(Collection)]
    public class KeycloakClientTests : ICollectionFixture<KeycloakFixture>
    {
        internal const string Collection = "Keycloak Client Tests";
        internal const string Setup = "Setup";
        internal const string Cleanup = "Cleanup";
        
        internal const string Get = "Retrieve data from Keycloak";
        internal const string Update = "Update data in Keycloak";

        internal const string RootCollection = nameof(RootCollection);
        internal const string AuthenticationManagement = nameof(AuthenticationManagement);
        internal const string RealmsAdmin = nameof(RealmsAdmin);
        internal const string Users = nameof(Users);
        internal const string Groups = nameof(Groups);
        internal const string Clients = nameof(Clients);
        internal const string ClientScopes = nameof(ClientScopes);
        internal const string ClientRoleMappings = nameof(ClientRoleMappings);
        internal const string ClientRegistrationPolicy = nameof(ClientRegistrationPolicy);
        internal const string ClientInitialAccess = nameof(ClientInitialAccess);
        internal const string ClientAttributeCertificate = nameof(ClientAttributeCertificate);
        internal const string Roles = nameof(Roles);
        internal const string IdentityProviders = nameof(IdentityProviders);
    }
}
