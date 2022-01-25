using System.Collections.Generic;
using Keycloak.Net.Model.Roles;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_rolesrepresentation 
    /// </summary>
    public class Roles
    {
        [JsonProperty("client")]
        public IDictionary<string, object>? Client { get; set; }

        [JsonProperty("realm")]
        public IEnumerable<Role>? Realm { get; set; }
    }
}
