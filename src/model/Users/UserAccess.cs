using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_userrepresentation
    /// </summary>
    public class UserAccess
    {
        [JsonProperty("impersonate")]
        public bool? Impersonate { get; set; }

        [JsonProperty("manage")]
        public bool? Manage { get; set; }

        [JsonProperty("manageGroupMembership")]
        public bool? ManageGroupMembership { get; set; }

        [JsonProperty("mapRoles")]
        public bool? MapRoles { get; set; }

        [JsonProperty("view")]
        public bool? View { get; set; }
    }
}
