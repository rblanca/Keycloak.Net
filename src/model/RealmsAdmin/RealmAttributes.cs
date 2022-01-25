using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    public class RealmAttributes
    {
        [JsonProperty("_browser_headerxXSSProtection")]
        public string? BrowserHeaderxXssProtection { get; set; }

        [JsonProperty("_browser_headerxFrameOptions")]
        public string? BrowserHeaderxFrameOptions { get; set; }

        [JsonProperty("_browser_headerstrictTransportSecurity")]
        public string? BrowserHeaderstrictTransportSecurity { get; set; }

        [JsonProperty("_browser_headerxRobotsTag")]
        public string? BrowserHeaderxRobotsTag { get; set; }

        [JsonProperty("_browser_headerxContentTypeOptions")]
        public string? BrowserHeaderxContentTypeOptions { get; set; }

        [JsonProperty("_browser_headercontentSecurityPolicyReportOnly")]
        public string? BrowserHeadercontentSecurityPolicyReportOnly { get; set; }

        [JsonProperty("_browser_headercontentSecurityPolicy")]
        public string? BrowserHeadercontentSecurityPolicy { get; set; }

        [JsonProperty("actionTokenGeneratedByAdminLifespan")]
        public string? ActionTokenGeneratedByAdminLifespan { get; set; }

        [JsonProperty("actionTokenGeneratedByUserLifespan")]
        public string? ActionTokenGeneratedByUserLifespan { get; set; }

        [JsonProperty("bruteForceProtected")]
        public string? BruteForceProtected { get; set; }

        [JsonProperty("cibaAuthRequestedUserHint")]
        public string? CibaAuthRequestedUserHint { get; set; }

        [JsonProperty("cibaBackchannelTokenDeliveryMode")]
        public string? CibaBackchannelTokenDeliveryMode { get; set; }

        [JsonProperty("cibaExpiresIn")]
        public int? CibaExpiresIn { get; set; }

        [JsonProperty("cibaInterval")]
        public int? CibaInterval { get; set; }

        [JsonProperty("failureFactor")]
        public string? FailureFactor { get; set; }

        [JsonProperty("maxFailureWaitSeconds")]
        public string? MaxFailureWaitSeconds { get; set; }

        [JsonProperty("maxDeltaTimeSeconds")]
        public string? MaxDeltaTimeSeconds { get; set; }

        [JsonProperty("minimumQuickLoginWaitSeconds")]
        public string? MinimumQuickLoginWaitSeconds { get; set; }

        [JsonProperty("oauth2DeviceCodeLifespan")]
        public int? OAuth2DeviceCodeLifespan { get; set; }

        [JsonProperty("oauth2DevicePollingInterval")]
        public int? OAuth2DevicePollingInterval { get; set; }

        [JsonProperty("offlineSessionMaxLifespan")]
        public string? OfflineSessionMaxLifespan { get; set; }

        [JsonProperty("offlineSessionMaxLifespanEnabled")]
        public string? OfflineSessionMaxLifespanEnabled { get; set; }

        [JsonProperty("permanentLockout")]
        public string? PermanentLockout { get; set; }

        [JsonProperty("parRequestUriLifespan")]
        public int? ParRequestUriLifespan { get; set; }

        [JsonProperty("quickLoginCheckMilliSeconds")]
        public string? QuickLoginCheckMilliSeconds { get; set; }

        [JsonProperty("userProfileEnabled")]
        public bool? UserProfileEnabled { get; set; }

        [JsonProperty("waitIncrementSeconds")]
        public string? WaitIncrementSeconds { get; set; }

    }
}