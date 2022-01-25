using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken-certconf
    /// </summary>
    public class AccessTokenCertConf
    {
        [JsonProperty("x5t#S256")]
        public string? X5Ts256 { get; set; }
    }
}
