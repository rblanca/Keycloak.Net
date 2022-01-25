using System.Collections.Generic;
using Keycloak.Net.Model.Roles;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Common
{
    public class Mapping
    {
        [JsonProperty("clientMappings")]
        public IDictionary<string, ClientRoleMapping> ClientMappings { get; set; }
        [JsonProperty("realmMappings")]
        public IEnumerable<Role> RealmMappings { get; set; }
    }
}
