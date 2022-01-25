using System.Collections.Generic;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.Converters;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Model.IdentityProviders;
using Keycloak.Net.Model.Users;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_partialimportrepresentation
    /// </summary>
    public class PartialImport
    {
        [JsonProperty("clients")]
        public IEnumerable<Client>? Clients { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<Group>? Groups { get; set; }

        [JsonProperty("identityProviders")]
        public IEnumerable<IdentityProvider>? IdentityProviders { get; set; }

        [JsonProperty("ifResourceExists")]
        public string? IfResourceExists { get; set; }

        [JsonProperty("policy")]
        [JsonConverter(typeof(PoliciesConverter))]
        public Policies? Policy { get; set; }

        [JsonProperty("roles")]
        public Roles? Roles { get; set; }

        [JsonProperty("users")]
        public IEnumerable<User>? Users { get; set; }
    }
}
