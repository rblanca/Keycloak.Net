using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ComponentTypes
    {
        [JsonProperty("org.keycloak.authentication.Authenticator")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakAuthenticationAuthenticator { get; set; }

        [JsonProperty("org.keycloak.authentication.ClientAuthenticator")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakAuthenticationClientAuthenticator { get; set; }

        [JsonProperty("org.keycloak.authentication.FormAction")]
        public IEnumerable<KeycloakAuthenticationFormAction>? OrgKeycloakAuthenticationFormAction { get; set; }

        [JsonProperty("org.keycloak.authentication.FormAuthenticator")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakAuthenticationFormAuthenticator { get; set; }

        [JsonProperty("org.keycloak.broker.provider.IdentityProviderMapper")]
        public IEnumerable<KeycloakAuthenticationFormAction>? OrgKeycloakBrokerProviderIdentityProviderMapper { get; set; }

        [JsonProperty("org.keycloak.keys.KeyProvider")]
        public IEnumerable<KeycloakAuthenticationFormAction>? OrgKeycloakKeysKeyProvider { get; set; }

        [JsonProperty("org.keycloak.protocol.ProtocolMapper")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakProtocolProtocolMapper { get; set; }

        [JsonProperty("org.keycloak.services.clientregistration.policy.ClientRegistrationPolicy")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakServicesClientRegistrationPolicyClientRegistrationPolicy { get; set; }

        [JsonProperty("org.keycloak.services.clientpolicy.condition.ClientPolicyConditionProvider")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakServicesClientPolicyConditionClientPolicyConditionProvider { get; set; }

        [JsonProperty("org.keycloak.services.clientpolicy.executor.ClientPolicyExecutorProvider")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakServicesClientPolicyExecutorClientPolicyExecutorProvider { get; set; }

        [JsonProperty("org.keycloak.storage.client.ClientStorageProvider")]
        public IEnumerable<KeycloakStorageClientStorageProvider>? OrgKeycloakStorageClientClientStorageProvider { get; set; }

        [JsonProperty("org.keycloak.storage.ldap.mappers.LDAPStorageMapper")]
        public IEnumerable<KeycloakStorageLdapMappersLdapStorageMapper>? OrgKeycloakStorageLdapMappersLdapStorageMapper { get; set; }

        [JsonProperty("org.keycloak.storage.UserStorageProvider")]
        public IEnumerable<KeycloakStorageUserStorageProvider>? OrgKeycloakStorageUserStorageProvider { get; set; }

        [JsonProperty("org.keycloak.userprofile.UserProfileProvider")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakUserProfileUserProfileProvider { get; set; }

        [JsonProperty("org.keycloak.validate.Validator")]
        public IEnumerable<KeycloakAuthenticationAuthenticator>? OrgKeycloakValidateValidator { get; set; }
    }
}