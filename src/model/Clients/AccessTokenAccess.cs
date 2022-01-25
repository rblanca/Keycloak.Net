using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken-access
    /// </summary>
    public class AccessTokenAccess
    {
        [JsonProperty("roles")] 
        public IEnumerable<string>? Roles  { get; set; }

        [JsonProperty("verify_caller")] 
        public bool? VerifyCaller { get; set; }
    }
}
