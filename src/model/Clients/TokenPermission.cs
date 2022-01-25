using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/api' />#_permission.
    /// </summary>
    public class TokenPermission
    {
        [JsonProperty("claims")]
        public IDictionary<string, object>? Claims { get; set; }

        [JsonProperty("rsid")]
        public string? RsId { get; set; }

        [JsonProperty("rsname")]
        public string? RsName { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<string>? Scopes { get; set; }
    }
}
