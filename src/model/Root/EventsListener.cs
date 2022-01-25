using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class EventsListener
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public EventsListenerProviders Providers { get; set; }
    }
}