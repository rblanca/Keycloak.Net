using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_realmrepresentation
    /// </summary>
    public class BrowserSecurityHeaders
    {
        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
        /// </summary>
        [JsonProperty("contentSecurityPolicy")]
        public string? ContentSecurityPolicy { get; set; }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy-Report-Only
        /// </summary>
        [JsonProperty("contentSecurityPolicyReportOnly")]
        public string? ContentSecurityPolicyReportOnly { get; set; }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Strict-Transport-Security
        /// </summary>
        [JsonProperty("strictTransportSecurity")]
        public string? StrictTransportSecurity { get; set; }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
        /// </summary>
        [JsonProperty("xContentTypeOptions")]
        public string? XContentTypeOptions { get; set; }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
        /// </summary>
        [JsonProperty("xFrameOptions")]
        public string? XFrameOptions { get; set; }

        /// <summary>
        /// https://developers.google.com/search/docs/advanced/robots/robots_meta_tag
        /// </summary>
        [JsonProperty("xRobotsTag")]
        public string? XRobotsTag { get; set; }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
        /// </summary>
        [JsonProperty("xXSSProtection")]
        public string? XXssProtection { get; set; }
    }
}