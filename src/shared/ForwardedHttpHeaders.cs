namespace Keycloak.Net.Shared
{
    public class ForwardedHttpHeaders
    {
        /// <summary>
        /// The header for <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-For">X-Forwarded-For</a>.<br/>
        /// Default: <c>X-Forwarded-For</c>
        /// </summary>
        public string? ForwardedFor { get; set; } = "X-Forwarded-For";

        /// <summary>
        /// The header for <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Proto">X-Forwarded-Proto</a>.<br/>
        /// Default: <c>X-Forwarded-Proto</c>
        /// </summary>
        public string? ForwardedProto { get; set; } = "X-Forwarded-Proto";

        /// <summary>
        /// The header for <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Host">X-Forwarded-Host</a>.<br/>
        /// Default: <c>X-Forwarded-Host</c>
        /// </summary>
        public string? ForwardedHost { get; set; } = "X-Forwarded-Host";
    }
}
