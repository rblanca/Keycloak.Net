using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class BuiltinProtocolMappers
    {
        [JsonProperty("saml")]
        public IEnumerable<Saml> Saml { get; set; } = null!;

        [JsonProperty("openid-connect")]
        public IEnumerable<OpenIdConnect> OpenIdConnect { get; set; } = null!;
    }
}