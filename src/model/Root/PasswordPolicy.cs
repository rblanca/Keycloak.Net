using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_passwordpolicytyperepresentation
    /// </summary>
    public class PasswordPolicy
    {
        [JsonProperty("configType")]
        public ConfigType ConfigType { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; } = null!;

        [JsonProperty("displayName")]
        public string DisplayName { get; set; } = null!;

        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("multipleSupported")]
        public bool MultipleSupported { get; set; }
    }
}