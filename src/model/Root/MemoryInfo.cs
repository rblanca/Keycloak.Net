using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_memoryinforepresentation
    /// </summary>
    public class MemoryInfo
    {
        [JsonProperty("free")]
        public long Free { get; set; }

        [JsonProperty("freeFormated")]
        public string FreeFormatted { get; set; } = null!;

        [JsonProperty("freePercentage")]
        public long FreePercentage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("totalFormated")]
        public string TotalFormatted { get; set; } = null!;

        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("usedFormated")]
        public string UsedFormatted { get; set; } = null!;
    }
}