using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_credentialrepresentation
    /// </summary>
    public class Credential
    {
        [JsonProperty("createdDate")]
        public long? CreatedDate { get; set; }

        [JsonProperty("credentialData")]
        public string? CredentialData { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("secretData")]
        public string? SecretData { get; set; }

        [JsonProperty("temporary")]
        public bool? Temporary { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("userLabel")]
        public string? UserLabel { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}
