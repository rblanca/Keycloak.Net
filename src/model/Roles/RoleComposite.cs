using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Roles
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_rolerepresentation-composites 
    /// </summary>
    public class RoleComposite
    {
        /// <summary>
        /// Child client roles.
        /// </summary>
        [JsonProperty("client")]        
        public IDictionary<string, string>? Client { get; set; }

        /// <summary>
        /// Child realm roles.
        /// </summary>
        [JsonProperty("realm")]
        public IEnumerable<string>? Realm { get; set; }
    }
}