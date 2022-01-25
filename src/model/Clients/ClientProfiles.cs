using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientprofilesrepresentation
    /// </summary>
    public class ClientProfiles
    {
        [JsonProperty("globalProfiles")]
        public IEnumerable<ClientProfile>? GlobalProfiles { get; set; }

        [JsonProperty("profiles")]
        public IEnumerable<ClientProfile>? Profiles { get; set; }
    }
}
