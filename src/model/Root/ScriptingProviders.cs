using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ScriptingProviders
    {
        [JsonProperty("script-based-auth")]
        public HasOrder ScriptBasedAuth { get; set; }
    }
}