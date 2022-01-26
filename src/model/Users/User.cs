using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_userrepresentation
    /// </summary>
    public class User
    {
        [JsonProperty("access")]
        public UserAccess? Access { get; set; }

        /// <summary>
        /// Additional user attributes and metadata.
        /// </summary>
        [JsonProperty("attributes")]
        public IDictionary<string, string>? Attributes { get; set; }

        [JsonProperty("clientConsents")]
        public IEnumerable<UserConsent>? ClientConsents { get; set; }

        /// <summary>
        /// Client roles mapped to the user.
        /// </summary>
        [JsonProperty("clientRoles")]
        public IDictionary<string, string>? ClientRoles { get; set; }

        /// <summary>
        /// When is this user created.
        /// </summary>
        [JsonProperty("createdTimestamp")]
        public long? CreatedTimestamp { get; set; }

        /// <summary>
        /// User login credentials
        /// </summary>
        [JsonProperty("credentials")]
        public IEnumerable<Credential>? Credentials { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        public IReadOnlyCollection<string>? DisableableCredentialTypes { get; set; }

        /// <summary>
        /// User's email address.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Has the user's email been verified?
        /// </summary>
        [JsonProperty("emailVerified")]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// A disabled user cannot login.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("federatedIdentities")]
        public IEnumerable<FederatedIdentity>? FederatedIdentities { get; set; }

        [JsonProperty("federationLink")]
        public string? FederationLink { get; set; }

        /// <summary>
        /// User's first name.
        /// </summary>
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Groups where the user has membership.
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<string>? Groups { get; set; }

        /// <summary>
        /// Identifier for this user
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// User's last name
        /// </summary>
        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("notBefore")]
        public int? NotBefore { get; set; }

        [JsonProperty("origin")]
        public string? Origin { get; set; }

        /// <summary>
        /// Realm roles mapped to the user.
        /// </summary>
        [JsonProperty("realmRoles")]
        public IEnumerable<string>? RealmRoles { get; set; }

        /// <summary>
        /// Require an action when the user logs in.
        /// <list type="bullet">
        /// <item>
        ///     <term>Verify email</term>
        ///     <description>Sends an email to the user to verify their email address.</description>
        /// </item>
        /// <item>
        ///     <term>Update profile</term>
        ///     <description>Requires user to enter in new personal information.</description>
        /// </item>
        /// <item>
        ///     <term>Update password</term>
        ///     <description>Requires user to enter in a new password.</description>
        /// </item>
        /// <item>
        ///     <term>Configure OTP</term>
        ///     <description>Requires setup of a mobile password generator.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("requiredActions")]
        public IReadOnlyCollection<string>? RequiredActions { get; set; }

        [JsonProperty("self")]
        public string? Self { get; set; }

        [JsonProperty("serviceAccountClientId")]
        public string? ServiceAccountClientId { get; set; }

        [JsonProperty("totp")]
        public bool? Totp { get; set; }

        [JsonProperty("username")]
        public string? UserName { get; set; }
    }
}
