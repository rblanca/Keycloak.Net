using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/federation/ldap/src/main/java/org/keycloak/storage/ldap/mappers/LDAPStorageMapperManager.java
    /// </summary>
    public class UserAttributeLdapMapperConfig : ComponentConfig
    {
        [JsonProperty("ldap.attribute")]
        public IEnumerable<string>? LdapAttribute { get; set; }

        [JsonProperty("is.mandatory.in.ldap")]
        public IEnumerable<bool>? IsMandatoryInLdap { get; set; }

        [JsonProperty("read.only")]
        public IEnumerable<bool>? ReadOnly { get; set; }

        [JsonProperty("always.read.value.from.ldap")]
        public IEnumerable<bool>? AlwaysReadValueFromLdap { get; set; }

        [JsonProperty("user.model.attribute")]
        public IEnumerable<string>? UserModelAttribute { get; set; }
    }
}
