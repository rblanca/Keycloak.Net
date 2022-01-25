using System.Collections.Generic;
using Keycloak.Net.Model.AuthorizationManagement;
using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_resourceserverrepresentation
    /// </summary>
    public class ResourceServer
    {
        [JsonProperty("allowRemoteResourceManagement")]
        public bool AllowRemoteResourceManagement { get; set; }

        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("decisionStrategy")]
        [JsonConverter(typeof(DecisionStrategiesConverter))]
        public DecisionStrategy? DecisionStrategy { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<Policy>? Policies { get; set; }

        [JsonProperty("policyEnforcementMode")]
        [JsonConverter(typeof(PolicyEnforcementModeConverter))]
        public PolicyEnforcementMode? PolicyEnforcementMode { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<Resource>? Resources { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<Scope>? Scopes { get; set; }
    }
}
