using System.Collections.Generic;
using Keycloak.Net.Model.AuthorizationManagement;
using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_scoperepresentation
    /// </summary>
    public class AuthorizationPolicy
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonConverter(typeof(PolicyTypeConverter))]
        public PolicyType Type { get; set; } = PolicyType.Role;

        [JsonConverter(typeof(PolicyDecisionLogicConverter))]
        public PolicyDecisionLogic Logic { get; set; } 

        [JsonConverter(typeof(DecisionStrategiesConverter))]
        public DecisionStrategy DecisionStrategy { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<RoleConfig>? RoleConfigs { get; set; }
    }

    public class RoleConfig
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("required")]
        public bool? Required { get; set; }
    }

    public enum PolicyType
    {
        Role,
        Client,
        Time,
        User,
        Aggregate,
        Group,
        Js
    }

    public class PolicyConfig
    {
        [JsonProperty("roles")]
        public IEnumerable<RoleConfig>? RoleConfigs { get; set; }
    }
}