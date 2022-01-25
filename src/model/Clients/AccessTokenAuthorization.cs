using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken-authorization
    /// </summary>
    public class AccessTokenAuthorization
    {
        [JsonProperty("permissions")]
        public IEnumerable<TokenPermission>? Permissions { get; set; }
    }
}
