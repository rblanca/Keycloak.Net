using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Roles
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_rolerepresentation-composites 
    /// </summary>
    public class RoleComposite
    {
        [JsonProperty("client")]        
        public IDictionary<string, string>? Client { get; set; }

        [JsonProperty("realm")]
        public IEnumerable<string>? Realm { get; set; }
    }
}