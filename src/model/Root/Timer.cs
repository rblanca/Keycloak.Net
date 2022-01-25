using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Timer
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public TimerProviders Providers { get; set; }
    }
}