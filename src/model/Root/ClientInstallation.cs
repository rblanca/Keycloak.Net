using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_serverinforepresentation
    /// </summary>
    public class ClientInstallation
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("protocol")]
        public Protocol Protocol { get; set; }

        [JsonProperty("downloadOnly")]
        public bool DownloadOnly { get; set; }

        [JsonProperty("displayType")]
        public string DisplayType { get; set; } = null!;

        [JsonProperty("helpText")]
        public string HelpText { get; set; } = null!;

        [JsonProperty("filename")]
        public string FileName { get; set; } = null!;

        [JsonProperty("mediaType")]
        public string MediaType { get; set; } = null!;
    }
}