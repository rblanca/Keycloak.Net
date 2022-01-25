using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/provider/HardcodedRoleMapper.html
    /// </summary>
    public class HardcodedRole : IdentityProviderMapperConfig
    {
        /// <summary>
        /// Role to grant to user. <br/>
        /// To reference a client role the syntax is clientname.clientrole, i.e. <c>myclient.myrole</c>
        /// </summary>
        [JsonProperty("role")]
        public string? Role { get; set; }
    }
}
