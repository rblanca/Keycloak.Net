using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Override realm authentication flow bindings.
    /// </summary>
    public class AuthenticationFlowBindingOverrides
    {
        /// <summary>
        /// The flow you want to use for browser authentication.
        /// </summary>
        [JsonProperty("browser")]
        public string? Browser { get; set; }

        /// <summary>
        /// The flow you want to use for direct grant authentication.
        /// </summary>
        [JsonProperty("direct_grant")] 
        public string? DirectGrant { get; set; }
    }
}
