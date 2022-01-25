using System.Collections.Generic;
using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthorizationManagement
{
    /// <summary>
    /// The client authorization service settings
    /// </summary>
    public class AuthorizationPermission
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonConverter(typeof(AuthorizationPermissionTypeConverter))]
        public AuthorizationPermissionType Type { get; set; }

        [JsonConverter(typeof(PolicyDecisionLogicConverter))]
        public PolicyDecisionLogic Logic { get; set; } 

        [JsonConverter(typeof(DecisionStrategiesConverter))]
        public DecisionStrategy DecisionStrategy { get; set; }

        [JsonProperty("resourceType")]
        public string? ResourceType { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<string>? ResourceIds { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<string>? ScopeIds { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<string>? PolicyIds { get; set; }
    }

    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />
    /// </summary>
    public enum PolicyDecisionLogic
    {
        Positive, 
        Negative
    }

    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />
    /// </summary>
    public enum AuthorizationPermissionType
    {   
        Scope, 
        Resource
    }

    /// <summary>
    /// The decision strategy dictates how the policies associated with a given policy are evaluated and how a final decision is obtained.
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/DecisionStrategy.html
    /// </summary>
    public enum DecisionStrategy
    {
        /// <summary>
        /// Defines that at least one policy must evaluate to a positive decision in order to the overall decision be also positive.
        /// </summary>
        Affirmative,

        /// <summary>
        /// Defines that the number of positive decisions must be greater than the number of negative decisions.
        /// </summary>
        Consensus,
        
        /// <summary>
        /// Defines that all policies must evaluate to a positive decision in order to the overall decision be also positive.
        /// </summary>
        Unanimous
    }
}