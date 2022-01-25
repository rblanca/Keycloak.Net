using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_credentialrepresentation
    /// </summary>
    public class CredentialData
    {
        [JsonProperty("algorithm")]
        public string? Algorithm { get; set; }

        [JsonProperty("hashIterations")]
        public int? HashIterations { get; set; }

        [JsonProperty("additionalParameters")]
        public IDictionary<string, object>? AdditionalParameters { get; set; }
    }
}
