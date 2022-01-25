using Newtonsoft.Json;

namespace Keycloak.Net.Model.Ldap
{
    public class LdapMapper
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public LdapMapperProviders Providers { get; set; }
    }
}