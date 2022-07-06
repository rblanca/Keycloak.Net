using System.Collections.Generic;
using Keycloak.Net.Model.AuthenticationManagement;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.ClientScopes;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Model.IdentityProviders;
using Keycloak.Net.Model.ProtocolMappers;
using Keycloak.Net.Model.RealmsAdmin;
using Keycloak.Net.Model.Roles;
using Keycloak.Net.Model.Users;

namespace Keycloak.Net.Tests.CustomRealmTest
{
    public class KeycloakFixture
    {
        public KeycloakFixture()
        {
            Realm = GetRealm();
            Client = GetClient();
            GetKeycloakClient();
            AuthenticatorProvider = GetAuthenticatorProvider();
            AuthenticationFlow = GetAuthenticationFlow();
            FormActionProvider = GetFormActionProvider();
            FormProvider = GetFormProvider();
            RequiredActionProvider = GetRequiredActionProvider();
            User = GetUser();
            Credential = GetUserCredential();
            Group = GetGroup();
            Role = GetRole();
            ClientScope = GetClientScope();
            ClientPolicy = GetClientPolicy();
            ClientProfile = GetClientProfile();
            IdentityProvider = GetIdentityProvider();
            IdentityProviderMapper = GetIdentityProviderMapper();
            ManagementPermission = GetManagementPermission();
            ProtocolMappers = GetProtocolMappers();
        }

        #region Properties

        private string _username;
        private string _password;

        /// <summary>
        /// The keycloak server endpoint
        /// </summary>
        internal string Url { get; private set; }

        internal string MasterRealm => "master";

        public KeycloakClient AdminCliClient { get; private set; }

        public KeycloakClient TestClient { get; private set; }

        public KeycloakClient TestNoAuthClient { get; private set; }

        public AuthenticatorProvider AuthenticatorProvider { get; set; }

        public AuthenticationFlow AuthenticationFlow { get; set; }

        public FormActionProvider FormActionProvider { get; set; }

        public FormProvider FormProvider { get; set; }

        public RequiredActionProvider RequiredActionProvider { get; set; }

        public Realm Realm { get; set; }
        
        public User User { get; set; }

        public Credential Credential { get; set; }

        public Group Group { get; set; }

        public Role Role { get; set; }

        public Client Client { get; set; }

        public ClientScope ClientScope { get; set; }

        public ClientPolicy ClientPolicy { get; set; }

        public ClientProfile ClientProfile { get; set; }

        public IdentityProvider IdentityProvider { get; set; }

        public IdentityProviderMapper IdentityProviderMapper { get; set; }

        public ManagementPermission ManagementPermission { get; set; }

        public ProtocolMapper[] ProtocolMappers { get; set; }

        #endregion

        #region Private

        private void GetKeycloakClient()
        {
            Url = KeyCloakServer.keyCloakEndpoint;
            _username = KeyCloakServer.keyCloakAdminUser;
            _password = KeyCloakServer.keyCloakAdminPassword;

            AdminCliClient = new KeycloakClient(Url, MasterRealm, "admin-cli", _username, _password);
            TestClient = new KeycloakClient(Url, Realm._Realm!, Client.ClientId, Client.Secret!);
            TestNoAuthClient = new KeycloakClient(Url, () => string.Empty);
        }

        private AuthenticatorProvider GetAuthenticatorProvider()
        {
            var authProvider = new AuthenticatorProvider
            {
                DisplayName = "TestProvider"
            };
            return authProvider;
        }

        private AuthenticationFlow GetAuthenticationFlow()
        {
            var authenticationFlow = new AuthenticationFlow
            {
                Alias = "testFlow",
                Description = "test flow",
                ProviderId = "basic-flow",
                TopLevel = true,
                BuiltIn = false
            };
            return authenticationFlow;
        }

        private FormActionProvider GetFormActionProvider()
        {
            var formActionProvider = new FormActionProvider
            {
                DisplayName = "TestFormActionProvider"
            };
            return formActionProvider;
        }

        private FormProvider GetFormProvider()
        {
            var formProvider = new FormProvider
            {
                DisplayName = "TestFormProvider"
            };
            return formProvider;
        }

        private RequiredActionProvider GetRequiredActionProvider()
        {
            var requiredActionProvider = new RequiredActionProvider
            {
                Alias = "testRequiredAction",
                Name = "TestRequiredAction",
                ProviderId = "testRequiredAction",
                Enabled = false
            };
            return requiredActionProvider;
        }

        private Realm GetRealm()
        {
            var realm = new Realm
            {
                _Realm = "unitTest",
                DisplayName = "unitTest",
                DisplayNameHtml = "<div class=\"kc-logo-text\"><span>Unit Test</span></div>",
                AdminEventsEnabled = true,
                BruteForceProtected = true,
                Enabled = true,
                EditUsernameAllowed = true,
                EventsEnabled = true,
                InternationalizationEnabled = true,
                OfflineSessionMaxLifespanEnabled = true,
                LoginWithEmailAllowed = true,
                UserManagedAccessAllowed = true,
                Attributes = new RealmAttributes
                {
                    UserProfileEnabled = true
                }
            };
            return realm;
        }
        
        private User GetUser()
        {
            var user = new User
            {
                UserName = _username,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@example.com",
                EmailVerified = true,
                Enabled = true
            };
            return user;
        }

        private Credential GetUserCredential()
        {
            var credential = new Credential
            {
                Value = _password,
                Temporary = false
            };

            return credential;
        }

        private Group GetGroup()
        {
            var group = new Group
            {
                Name = "normalGroup",
                Path = "/normalGroup"
            };

            return group;
        }

        private Role GetRole()
        {
            var role = new Role
            {
                Name = "normalRole",
                Description = "some normal role"
            };

            return role;
        }

        private Client GetClient()
        {
            var client = new Client
            {
                ClientId = "testClient",
                Name = "testClient",
                Description = "test client for unit tests",
                Enabled = true,
                ImplicitFlowEnabled = true,
                ServiceAccountsEnabled = true,
                StandardFlowEnabled = true,
                DirectAccessGrantsEnabled = true,
                ClientAuthenticatorType = ClientAuthenticatorType.ClientSecret,
                Secret = "secret",
                Access = new ClientAccess
                {
                    Configure = true,
                    Manage = true,
                    View = true
                }
            };

            return client;
        }

        private ClientScope GetClientScope()
        {
            var clientScope = new ClientScope
            {
                Name = "normalClientScope",
                Description = "normal client scope",
                Attributes = new Attributes(),
                ProtocolMappers = new List<ProtocolMapper>
                {
                    new ProtocolMapper
                    {
                        Name = "claim",
                        Protocol = "openid-connect",
                        ConsentRequired = false,
                        Config = new ProtocolConfig
                        {
                            ClaimName = "claim",
                            IdTokenClaim = true,
                            UserInfoTokenClaim = true
                        }
                    }
                }
            };
            return clientScope;
        }

        private ProtocolMapper[] GetProtocolMappers()
        {
            return new ProtocolMapper[]
                {
                    new ProtocolMapper
                    {
                        Name = "test-claim-1",
                        Protocol = "openid-connect",
                        ConsentRequired = false,
                        Config = new ProtocolConfig
                        {
                            ClaimName = "test-claim-1",
                            IdTokenClaim = true,
                            UserInfoTokenClaim = true
                        }
                    },
                    new ProtocolMapper
                    {
                        Name = "test-claim-2",
                        Protocol = "openid-connect",
                        ConsentRequired = false,
                        Config = new ProtocolConfig
                        {
                            ClaimName = "test-claim-2",
                            IdTokenClaim = true,
                            UserInfoTokenClaim = true
                        }
                    }
                };
        }

        private ClientPolicy GetClientPolicy()
        {
            var clientPolicy = new ClientPolicy
            {
                Name = "normalPolicy",
                Enabled = true,
                Description = "A normal policy"
            };
            return clientPolicy;
        }

        private ClientProfile GetClientProfile()
        {
            var clientPolicy = new ClientProfile
            {
                Name = "normalProfile",
                Description = "A normal policy"
            };
            return clientPolicy;
        }

        private IdentityProvider GetIdentityProvider()
        {
            var identityProvider = new IdentityProvider
            {
                ProviderId = "facebook",
                Alias = "facebook",
                DisplayName = "Facebook",
                Enabled = true
            };
            return identityProvider;
        }

        private IdentityProviderMapper GetIdentityProviderMapper()
        {
            var identityProviderMapper = new IdentityProviderMapper
            {
                Name = "facebook",
                IdentityProviderAlias = "facebook"
            };
            return identityProviderMapper;
        }

        private ManagementPermission GetManagementPermission()
        {
            var managementPermission = new ManagementPermission
            {
                Enabled = true
            };
            return managementPermission;
        }

        #endregion
    }
}