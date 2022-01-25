using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AuthenticatorProviders
    {
        [JsonProperty("no-cookie-redirect")]
        public HasOrder NoCookieRedirect { get; set; } = null!;

        [JsonProperty("auth-cookie")]
        public HasOrder AuthCookie { get; set; } = null!;

        [JsonProperty("console-username-password")]
        public HasOrder ConsoleUsernamePassword { get; set; } = null!;

        [JsonProperty("reset-credentials-choose-user")]
        public HasOrder ResetCredentialsChooseUser { get; set; } = null!;

        [JsonProperty("direct-grant-validate-password")]
        public HasOrder DirectGrantValidatePassword { get; set; } = null!;

        [JsonProperty("webauthn-authenticator")]
        public HasOrder WebAuthnAuthenticator { get; set; } = null!;

        [JsonProperty("auth-spnego")]
        public HasOrder AuthSpnego { get; set; } = null!;

        [JsonProperty("direct-grant-auth-x509-username")]
        public HasOrder DirectGrantAuthX509Username { get; set; } = null!;

        [JsonProperty("reset-password")]
        public HasOrder ResetPassword { get; set; } = null!;

        [JsonProperty("auth-password-form")]
        public HasOrder AuthPasswordForm { get; set; } = null!;

        [JsonProperty("docker-http-basic-authenticator")]
        public HasOrder DockerHttpBasicAuthenticator { get; set; } = null!;

        [JsonProperty("allow-access-authenticator")]
        public HasOrder AllowAccessAuthenticator { get; set; } = null!;

        [JsonProperty("idp-username-password-form")]
        public HasOrder IdpUsernamePasswordForm { get; set; } = null!;

        [JsonProperty("auth-x509-client-username-form")]
        public HasOrder AuthX509ClientUsernameForm { get; set; } = null!;

        [JsonProperty("idp-auto-link")]
        public HasOrder IdpAutoLink { get; set; } = null!;

        [JsonProperty("idp-email-verification")]
        public HasOrder IdpEmailVerification { get; set; } = null!;

        [JsonProperty("basic-auth")]
        public HasOrder BasicAuth { get; set; } = null!;

        [JsonProperty("conditional-user-role")]
        public HasOrder ConditionalUserRole { get; set; } = null!;

        [JsonProperty("deny-access-authenticator")]
        public HasOrder DenyAccessAuthenticator { get; set; } = null!;

        [JsonProperty("direct-grant-validate-username")]
        public HasOrder DirectGrantValidateUsername { get; set; } = null!;

        [JsonProperty("identity-provider-redirector")]
        public HasOrder IdentityProviderRedirector { get; set; } = null!;

        [JsonProperty("reset-otp")]
        public HasOrder ResetOtp { get; set; } = null!;

        [JsonProperty("conditional-user-configured")]
        public HasOrder ConditionalUserConfigured { get; set; } = null!;

        [JsonProperty("webauthn-authenticator-passwordless")]
        public HasOrder WebAuthnAuthenticatorPasswordless { get; set; } = null!;

        [JsonProperty("basic-auth-otp")]
        public HasOrder BasicAuthOtp { get; set; } = null!;

        [JsonProperty("auth-conditional-otp-form")]
        public HasOrder AuthConditionalOtpForm { get; set; } = null!;

        [JsonProperty("idp-confirm-link")]
        public HasOrder IdpConfirmLink { get; set; } = null!;

        [JsonProperty("idp-review-profile")]
        public HasOrder IdpReviewProfile { get; set; } = null!;

        [JsonProperty("auth-username-password-form")]
        public HasOrder AuthUsernamePasswordForm { get; set; } = null!;

        [JsonProperty("reset-credential-email")]
        public HasOrder ResetCredentialEmail { get; set; } = null!;

        [JsonProperty("auth-username-form")]
        public HasOrder AuthUsernameForm { get; set; } = null!;

        [JsonProperty("idp-detect-existing-broker-user")]
        public HasOrder IdpDetectExistingBrokerUser { get; set; } = null!;

        [JsonProperty("http-basic-authenticator")]
        public HasOrder HttpBasicAuthenticator { get; set; } = null!;

        [JsonProperty("auth-otp-form")]
        public HasOrder AuthOtpForm { get; set; } = null!;

        [JsonProperty("direct-grant-validate-otp")]
        public HasOrder DirectGrantValidateOtp { get; set; } = null!;

        [JsonProperty("idp-create-user-if-unique")]
        public HasOrder IdpCreateUserIfUnique { get; set; } = null!;
    }
}