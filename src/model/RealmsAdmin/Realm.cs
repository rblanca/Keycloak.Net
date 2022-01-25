using System.Collections.Generic;
using Keycloak.Net.Model.AuthenticationManagement;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.ClientScopes;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Model.IdentityProviders;
using Keycloak.Net.Model.Json;
using Keycloak.Net.Model.ProtocolMappers;
using Keycloak.Net.Model.Roles;
using Keycloak.Net.Model.ScopeMappings;
using Keycloak.Net.Model.Users;
using Newtonsoft.Json;

#pragma warning disable 8618

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_realmrepresentation
    /// </summary>
    public class Realm
    {
        [JsonProperty("accessCodeLifespan")]
        public int? AccessCodeLifespan { get; set; }

        [JsonProperty("accessCodeLifespanLogin")]
        public int? AccessCodeLifespanLogin { get; set; }

        [JsonProperty("accessCodeLifespanUserAction")]
        public int? AccessCodeLifespanUserAction { get; set; }

        [JsonProperty("accessTokenLifespan")]
        public int? AccessTokenLifespan { get; set; }

        [JsonProperty("accessTokenLifespanForImplicitFlow")]
        public int? AccessTokenLifespanForImplicitFlow { get; set; }

        [JsonProperty("accountTheme")]
        public string? AccountTheme { get; set; }

        [JsonProperty("actionTokenGeneratedByAdminLifespan")]
        public int? ActionTokenGeneratedByAdminLifespan { get; set; }

        [JsonProperty("actionTokenGeneratedByUserLifespan")]
        public int? ActionTokenGeneratedByUserLifespan { get; set; }

        [JsonProperty("adminEventsDetailsEnabled")]
        public bool AdminEventsDetailsEnabled { get; set; }

        [JsonProperty("adminEventsEnabled")]
        public bool AdminEventsEnabled { get; set; }

        [JsonProperty("adminTheme")]
        public string? AdminTheme { get; set; }

        [JsonProperty("attributes")]
        public RealmAttributes? Attributes { get; set; }

        [JsonProperty("authenticationFlows")]
        public IEnumerable<AuthenticationFlow>? AuthenticationFlows { get; set; }

        [JsonProperty("authenticatorConfig")]
        public IEnumerable<AuthenticatorConfig>? AuthenticatorConfig { get; set; }

        [JsonProperty("browserFlow")]
        public string? BrowserFlow { get; set; }

        [JsonProperty("browserSecurityHeaders")]
        public BrowserSecurityHeaders? BrowserSecurityHeaders { get; set; }

        [JsonProperty("bruteForceProtected")]
        public bool BruteForceProtected { get; set; }

        [JsonProperty("clientAuthenticationFlow")]
        public string? ClientAuthenticationFlow { get; set; }

        [JsonProperty("clientOfflineSessionIdleTimeout")]
        public int? ClientOfflineSessionIdleTimeout { get; set; }

        [JsonProperty("clientOfflineSessionMaxLifespan")]
        public int? ClientOfflineSessionMaxLifespan { get; set; }

        [JsonProperty("clientPolicies")]
        public ClientPolicies? ClientPolicies { get; set; }

        [JsonProperty("clientProfiles")]
        public ClientProfiles? ClientProfiles { get; set; }

        [JsonProperty("clientScopeMappings")]
        public IDictionary<string, string>? ClientScopeMappings { get; set; }

        [JsonProperty("clientScopes")]
        public IEnumerable<ClientScope>? ClientScopes { get; set; }

        [JsonProperty("clientSessionIdleTimeout")]
        public int? ClientSessionIdleTimeout { get; set; }

        [JsonProperty("clientSessionMaxLifespan")]
        public int? ClientSessionMaxLifespan { get; set; }

        [JsonProperty("clients")]
        public IEnumerable<Client>? Clients { get; set; }

        [JsonProperty("components")]
        public MultivaluedHashMap? Components { get; set; }

        [JsonProperty("defaultDefaultClientScopes")]
        public IEnumerable<string>? DefaultDefaultClientScopes { get; set; }

        [JsonProperty("defaultGroups")]
        public IEnumerable<string>? DefaultGroups { get; set; }

        [JsonProperty("defaultLocale")]
        public string? DefaultLocale { get; set; }

        [JsonProperty("defaultOptionalClientScopes")]
        public IEnumerable<string>? DefaultOptionalClientScopes { get; set; }

        [JsonProperty("defaultRole")]
        public Role? DefaultRole { get; set; }

        [JsonProperty("defaultSignatureAlgorithm")]
        public string? DefaultSignatureAlgorithm { get; set; }

        [JsonProperty("directGrantFlow")]
        public string DirectGrantFlow { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("displayNameHtml")]
        public string? DisplayNameHtml { get; set; }

        [JsonProperty("dockerAuthenticationFlow")]
        public string? DockerAuthenticationFlow { get; set; }

        [JsonProperty("duplicateEmailsAllowed")]
        public bool DuplicateEmailsAllowed { get; set; }

        [JsonProperty("editUsernameAllowed")]
        public bool EditUsernameAllowed { get; set; }

        [JsonProperty("emailTheme")]
        public string? EmailTheme { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("enabledEventTypes")]
        public IEnumerable<string>? EnabledEventTypes { get; set; }

        [JsonProperty("eventsEnabled")]
        public bool EventsEnabled { get; set; }

        [JsonProperty("eventsExpiration")]
        public long? EventsExpiration { get; set; }

        [JsonProperty("eventsListeners")]
        public IEnumerable<string>? EventsListeners { get; set; }

        [JsonProperty("failureFactor")]
        public int? FailureFactor { get; set; }

        [JsonProperty("federatedUsers")]
        public IEnumerable<User>? FederatedUsers { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<Group>? Groups { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("identityProviderMappers")]
        public IEnumerable<IdentityProviderMapper>? IdentityProviderMappers { get; set; }

        [JsonProperty("identityProviders")]
        public IEnumerable<IdentityProvider> IdentityProviders { get; set; }

        [JsonProperty("internationalizationEnabled")]
        public bool InternationalizationEnabled { get; set; }

        [JsonProperty("keycloakVersion")]
        public string? KeycloakVersion { get; set; }

        [JsonProperty("loginTheme")]
        public string? LoginTheme { get; set; }

        [JsonProperty("loginWithEmailAllowed")]
        public bool LoginWithEmailAllowed { get; set; }

        [JsonProperty("maxDeltaTimeSeconds")]
        public int? MaxDeltaTimeSeconds { get; set; }

        [JsonProperty("maxFailureWaitSeconds")]
        public int? MaxFailureWaitSeconds { get; set; }

        [JsonProperty("minimumQuickLoginWaitSeconds")]
        public int? MinimumQuickLoginWaitSeconds { get; set; }

        [JsonProperty("notBefore")]
        public int? NotBefore { get; set; }

        [JsonProperty("oAuth2DeviceCodeLifespan")]
        public int? OAuth2DeviceCodeLifespan { get; set; }

        [JsonProperty("oAuth2DevicePollingInterval")]
        public int? OAuth2DevicePollingInterval { get; set; }

        [JsonProperty("offlineSessionIdleTimeout")]
        public int? OfflineSessionIdleTimeout { get; set; }

        [JsonProperty("offlineSessionMaxLifespan")]
        public int? OfflineSessionMaxLifespan { get; set; }

        [JsonProperty("offlineSessionMaxLifespanEnabled")]
        public bool OfflineSessionMaxLifespanEnabled { get; set; }

        [JsonProperty("otpPolicyAlgorithm")]
        public string? OtpPolicyAlgorithm { get; set; }

        [JsonProperty("otpPolicyDigits")]
        public int? OtpPolicyDigits { get; set; }

        [JsonProperty("otpPolicyInitialCounter")]
        public int? OtpPolicyInitialCounter { get; set; }

        [JsonProperty("otpPolicyLookAheadWindow")]
        public int? OtpPolicyLookAheadWindow { get; set; }

        [JsonProperty("otpPolicyPeriod")]
        public int? OtpPolicyPeriod { get; set; }

        [JsonProperty("otpPolicyType")]
        public string? OtpPolicyType { get; set; }

        [JsonProperty("otpSupportedApplications")]
        public IEnumerable<string>? OtpSupportedApplications { get; set; }

        [JsonProperty("passwordPolicy")]
        public string? PasswordPolicy { get; set; }

        [JsonProperty("permanentLockout")]
        public bool PermanentLockout { get; set; }

        [JsonProperty("protocolMappers")]
        public IEnumerable<ProtocolMapper>? ProtocolMappers { get; set; }

        [JsonProperty("quickLoginCheckMilliSeconds")]
        public long? QuickLoginCheckMilliSeconds { get; set; }

        [JsonProperty("realm")]
        // ReSharper disable once InconsistentNaming
        public string? _Realm { get; set; }

        [JsonProperty("refreshTokenMaxReuse")]
        public int? RefreshTokenMaxReuse { get; set; }

        [JsonProperty("registrationAllowed")]
        public bool RegistrationAllowed { get; set; }

        [JsonProperty("registrationEmailAsUsername")]
        public bool RegistrationEmailAsUsername { get; set; }

        [JsonProperty("registrationFlow")]
        public string? RegistrationFlow { get; set; }

        [JsonProperty("rememberMe")]
        public bool RememberMe { get; set; }

        [JsonProperty("requiredActions")]
        public IEnumerable<RequiredActionProvider>? RequiredActions { get; set; }

        [JsonProperty("requiredCredentials")]
        public IEnumerable<string> RequiredCredentials { get; set; }

        [JsonProperty("resetCredentialsFlow")]
        public string? ResetCredentialsFlow { get; set; }

        [JsonProperty("resetPasswordAllowed")]
        public bool ResetPasswordAllowed { get; set; }

        [JsonProperty("revokeRefreshToken")]
        public bool RevokeRefreshToken { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<Roles>? Roles { get; set; }

        [JsonProperty("scopeMappings")]
        public IEnumerable<ScopeMapping>? ScopeMappings { get; set; }

        [JsonProperty("smtpServer")]
        public SmtpServer? SmtpServer { get; set; }

        [JsonProperty("sslRequired")]
        public string? SslRequired { get; set; }

        [JsonProperty("ssoSessionIdleTimeout")]
        public int? SsoSessionIdleTimeout { get; set; }

        [JsonProperty("ssoSessionIdleTimeoutRememberMe")]
        public int? SsoSessionIdleTimeoutRememberMe { get; set; }

        [JsonProperty("ssoSessionMaxLifespan")]
        public int? SsoSessionMaxLifespan { get; set; }

        [JsonProperty("ssoSessionMaxLifespanRememberMe")]
        public int? SsoSessionMaxLifespanRememberMe { get; set; }

        [JsonProperty("supportedLocales")]
        public IEnumerable<string>? SupportedLocales { get; set; }

        [JsonProperty("userFederationMappers")]
        public IEnumerable<UserFederationMapper>? UserFederationMappers { get; set; }

        [JsonProperty("userFederationProviders")]
        public IEnumerable<UserFederationProvider>? UserFederationProviders { get; set; }

        [JsonProperty("userManagedAccessAllowed")]
        public bool UserManagedAccessAllowed { get; set; }

        [JsonProperty("users")]
        public IEnumerable<User>? Users { get; set; }

        [JsonProperty("verifyEmail")]
        public bool VerifyEmail { get; set; }

        [JsonProperty("waitIncrementSeconds")]
        public int? WaitIncrementSeconds { get; set; }

        [JsonProperty("webAuthnPolicyAcceptableAaguids")]
        public IEnumerable<string>? WebAuthnPolicyAcceptableAaguids { get; set; }

        [JsonProperty("webAuthnPolicyAttestationConveyancePreference")]
        public string? WebAuthnPolicyAttestationConveyancePreference { get; set; }

        [JsonProperty("webAuthnPolicyAuthenticatorAttachment")]
        public string? WebAuthnPolicyAuthenticatorAttachment { get; set; }

        [JsonProperty("webAuthnPolicyAvoidSameAuthenticatorRegister")]
        public bool WebAuthnPolicyAvoidSameAuthenticatorRegister { get; set; }

        [JsonProperty("webAuthnPolicyCreateTimeout")]
        public int? WebAuthnPolicyCreateTimeout { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessAcceptableAaguids")]
        public IEnumerable<string>? WebAuthnPolicyPasswordlessAcceptableAaguids { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessAttestationConveyancePreference")]
        public string? WebAuthnPolicyPasswordlessAttestationConveyancePreference { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessAuthenticatorAttachment")]
        public string? WebAuthnPolicyPasswordlessAuthenticatorAttachment { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister")]
        public bool WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessCreateTimeout")]
        public int? WebAuthnPolicyPasswordlessCreateTimeout { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessRequireResidentKey")]
        public string? WebAuthnPolicyPasswordlessRequireResidentKey { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessRpEntityName")]
        public string? WebAuthnPolicyPasswordlessRpEntityName { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessRpId")]
        public string? WebAuthnPolicyPasswordlessRpId { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessSignatureAlgorithms")]
        public IEnumerable<string>? WebAuthnPolicyPasswordlessSignatureAlgorithms { get; set; }

        [JsonProperty("webAuthnPolicyPasswordlessUserVerificationRequirement")]
        public string? WebAuthnPolicyPasswordlessUserVerificationRequirement { get; set; }

        [JsonProperty("webAuthnPolicyRequireResidentKey")]
        public string? WebAuthnPolicyRequireResidentKey { get; set; }

        [JsonProperty("webAuthnPolicyRpEntityName")]
        public string? WebAuthnPolicyRpEntityName { get; set; }

        [JsonProperty("webAuthnPolicyRpId")]
        public string? WebAuthnPolicyRpId { get; set; }

        [JsonProperty("webAuthnPolicySignatureAlgorithms")]
        public IEnumerable<string>? WebAuthnPolicySignatureAlgorithms { get; set; }

        [JsonProperty("webAuthnPolicyUserVerificationRequirement")]
        public string? WebAuthnPolicyUserVerificationRequirement { get; set; }
    }
}
