using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_authenticationexecutioninforepresentation
    /// </summary>
    public class AuthenticationFlowExecutionInfo
    {
        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("authenticationConfig")]
        public string? AuthenticationConfig { get; set; }

        [JsonProperty("authenticationFlow")]
        public bool? AuthenticationFlow { get; set; }

        [JsonProperty("configurable")]
        public bool? Configurable { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("flowId")]
        public string? FlowId { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("providerId")]
        public string? ProviderId { get; set; }

        [JsonProperty("requirement")]
        public string? Requirement { get; set; }

        [JsonProperty("requirementChoices")]
        public IEnumerable<string>? RequirementChoices { get; set; }
    }
}
