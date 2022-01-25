using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class JtaLookupProviders
    {
        [JsonProperty("jboss")]
        public HasOrder Jboss { get; set; }
    }
}