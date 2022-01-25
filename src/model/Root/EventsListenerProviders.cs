using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class EventsListenerProviders
    {
        [JsonProperty("jboss-logging")]
        public HasOrder JbossLogging { get; set; }

        [JsonProperty("email")]
        public HasOrder Email { get; set; }
    }
}