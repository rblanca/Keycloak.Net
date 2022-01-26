using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Roles
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_rolerepresentation 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Additional role attributes and metadata.
        /// </summary>
        [JsonProperty("attributes")]
        public IDictionary<string, object>? Attributes { get; set; }

        /// <summary>
        /// Client roles mapped to the role.
        /// </summary>
        [JsonProperty("clientRole")]
        public bool? ClientRole { get; set; }

        /// <summary>
        /// True if role supports child roles.
        /// </summary>
        [JsonProperty("composite")]
        public bool? Composite { get; set; }

        /// <summary>
        /// The list of child realm and client roles.
        /// </summary>
        [JsonProperty("composites")]
        public RoleComposite? Composites { get; set; }

        [JsonProperty("containerId")]
        public string? ContainerId { get; set; }

        /// <summary>
        /// Role description.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The identifier for this role.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Role name.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
