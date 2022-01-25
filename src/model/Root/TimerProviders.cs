using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class TimerProviders
    {
        [JsonProperty("basic")]
        public HasOrder Basic { get; set; }
    }
}