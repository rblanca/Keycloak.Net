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

        [JsonProperty("attributes")]
        public IDictionary<string, string>? Attributes { get; set; }

        [JsonProperty("clientConsents")]
        public IEnumerable<UserConsent>? ClientConsents { get; set; }

        [JsonProperty("clientRoles")]
        public IDictionary<string, string>? ClientRoles { get; set; }

        [JsonProperty("createdTimestamp")]
        public long? CreatedTimestamp { get; set; }

        [JsonProperty("credentials")]
        public IEnumerable<Credential>? Credentials { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        public IReadOnlyCollection<string>? DisableableCredentialTypes { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("emailVerified")]
        public bool? EmailVerified { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("federatedIdentities")]
        public IEnumerable<FederatedIdentity>? FederatedIdentities { get; set; }

        [JsonProperty("federationLink")]
        public string? FederationLink { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<string>? Groups { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("notBefore")]
        public int? NotBefore { get; set; }

        [JsonProperty("origin")]
        public string? Origin { get; set; }

        [JsonProperty("realmRoles")]
        public IEnumerable<string>? RealmRoles { get; set; }

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
