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

        /// <summary>
        /// Additional group attributes and metadata.
        /// </summary>
        [JsonProperty("attributes")]
        public IDictionary<string, IEnumerable<string>>? Attributes { get; set; }

        /// <summary>
        /// Client roles mapped to the group.
        /// </summary>
        [JsonProperty("clientRoles")]
        public IDictionary<string, IEnumerable<string>>? ClientRoles { get; set; }

        /// <summary>
        /// The identifier for this group.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Group name.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        /// <summary>
        /// Realm roles mapped to the group.
        /// </summary>
        [JsonProperty("realmRoles")]
        public IEnumerable<string>? RealmRoles { get; set; }

        [JsonProperty("subGroups")]
        public IEnumerable<Group>? Subgroups { get; set; }
    }
}
