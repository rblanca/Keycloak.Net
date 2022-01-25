using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_getperclientconfigdescription
    /// </summary>
    public class ClientAuthenticatorProvider
    {
        [JsonProperty("client-jwt")]
        public IEnumerable<string>? ClientJwt { get; set; }

        [JsonProperty("client-secret")]
        public IEnumerable<string>? ClientSecret { get; set; }

        [JsonProperty("client-x509")]
        public IEnumerable<string>? ClientX509 { get; set; }

        [JsonProperty("client-secret-jwt")]
        public IEnumerable<string>? ClientSecretJwt { get; set; }
    }
}