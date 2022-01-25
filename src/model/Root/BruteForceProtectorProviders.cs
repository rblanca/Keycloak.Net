using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class BruteForceProtectorProviders
    {
        [JsonProperty("default-brute-force-detector")]
        public HasOrder DefaultBruteForceDetector { get; set; } = null!;
    }
}