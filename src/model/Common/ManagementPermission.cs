using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Common
{
    /// <summary>
    /// Fine grained permissions for administrators that want to manage this client or apply roles defined by this client. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_managementpermissionreference
    /// </summary>
    public class ManagementPermission
    {
        /// <summary>
        /// Determines if fine grained permissions are enabled for managing this role. Disabling will delete all current permissions that have been set up.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Reference to the client authorization service resource id. <br/>
        /// See <include file='../../keycloak.xml' path='keycloak/docs/doc' />/authorization_services/#_resource_server_overview
        /// </summary>
        [JsonProperty("resource")]
        public string? Resource { get; set; }

        [JsonProperty("scopePermissions")]
        public IDictionary<string, object>? ScopePermissions { get; set; }
    }
}
