using Newtonsoft.Json;

namespace Keycloak.Net.Model.Json
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_multivaluedhashmap
    /// </summary>
    public class MultivaluedHashMap
    {
        [JsonProperty("empty")]
        public bool? Empty { get; set; }

        [JsonProperty("loadFactor")]
        public float? LoadFactor { get; set; }

        [JsonProperty("threshold")]
        public int? Threshold { get; set; }
    }
}
