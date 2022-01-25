using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_profileinforepresentation
    /// </summary>
    public class ProfileInfo
    {
        [JsonProperty("disabledFeatures")]
        public IEnumerable<string> DisabledFeatures { get; set; } = null!;

        [JsonProperty("experimentalFeatures")]
        public IEnumerable<string> ExperimentalFeatures { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("previewFeatures")]
        public IEnumerable<string> PreviewFeatures { get; set; } = null!;
    }
}