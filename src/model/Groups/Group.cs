using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Groups
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_grouprepresentation
    /// </summary>
    public class Group
    {
        [JsonProperty("access")]
        public IDictionary<string, string>? Access { get; set; }

        [JsonProperty("attributes")]
        public IDictionary<string, IEnumerable<string>>? Attributes { get; set; }

        [JsonProperty("clientRoles")]
        public IDictionary<string, IEnumerable<string>>? ClientRoles { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("realmRoles")]
        public IEnumerable<string>? RealmRoles { get; set; }

        [JsonProperty("subGroups")]
        public IEnumerable<Group>? Subgroups { get; set; }
    }
}
