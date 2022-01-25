using System.Collections.Generic;
using Keycloak.Net.Model.Roles;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Common
{
    public class ClientRoleMapping
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("client")]
        public string? Client { get; set; }

        [JsonProperty("mappings")]
        public List<Role>? Mappings { get; set; }
    }
}
