using System.Collections.Generic;
using Keycloak.Net.Model.Root;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Common
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_configpropertyrepresentation
    /// </summary>
    public class ConfigProperty
    {
        [JsonProperty("defaultValue")]
        public string? DefaultValue { get; set; }

        [JsonProperty("helpText")]
        public string? HelpText { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("options")]
        public IEnumerable<string>? Options { get; set; }

        [JsonProperty("secret")]
        public bool? Secret { get; set; }

        [JsonProperty("type")]
        public JsonTypeLabel Type { get; set; }
    }
}
