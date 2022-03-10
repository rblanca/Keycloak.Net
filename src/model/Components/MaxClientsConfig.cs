using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    public class MaxClientsConfig : ComponentConfig
    {
        [JsonProperty("max-clients")]
        public IEnumerable<int>? MaxClients { get; set; }
    }
}
