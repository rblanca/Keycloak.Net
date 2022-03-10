using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    public class AllowedClientTemplatesConfig : ComponentConfig
    {
        [JsonProperty("allow-default-scopes")]
        public IEnumerable<bool>? AllowDefaultScopes { get; set; }
    }
}
