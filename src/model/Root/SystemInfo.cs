using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_systeminforepresentation
    /// </summary>
    public class SystemInfo
    {
        [JsonProperty("fileEncoding")]
        public string FileEncoding { get; set; } = null!;

        [JsonProperty("javaHome")]
        public string JavaHome { get; set; } = null!;

        [JsonProperty("javaRuntime")]
        public string JavaRuntime { get; set; } = null!;

        [JsonProperty("javaVendor")]
        public string JavaVendor { get; set; } = null!;

        [JsonProperty("javaVersion")]
        public string JavaVersion { get; set; } = null!;

        [JsonProperty("javaVm")]
        public string JavaVm { get; set; } = null!;

        [JsonProperty("javaVmVersion")]
        public string JavaVmVersion { get; set; } = null!;

        [JsonProperty("osArchitecture")]
        public string OsArchitecture { get; set; } = null!;

        [JsonProperty("osName")]
        public string OsName { get; set; } = null!;

        [JsonProperty("osVersion")]
        public string OsVersion { get; set; } = null!;

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; } = null!;

        [JsonProperty("uptime")]
        public string Uptime { get; set; } = null!;

        [JsonProperty("uptimeMillis")]
        public long UptimeMillis { get; set; }

        [JsonProperty("userDir")]
        public string UserDir { get; set; } = null!;

        [JsonProperty("userLocale")]
        public string UserLocale { get; set; } = null!;

        [JsonProperty("userName")]
        public string UserName { get; set; } = null!;

        [JsonProperty("userTimezone")]
        public string UserTimezone { get; set; } = null!;

        [JsonProperty("version")]
        public string Version { get; set; } = null!;
    }
}