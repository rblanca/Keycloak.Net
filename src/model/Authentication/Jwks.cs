using Newtonsoft.Json;

namespace Keycloak.Net.Model.Authentication
{
    /// <summary>
    /// The JSON Web Key set is used to verify the signature of an issued token or to encrypt request objects to it
    /// See https://openid.net/specs/openid-connect-discovery-1_0.html#JWK
    /// </summary>
    public class Jwks
    {
        [JsonProperty("keys")]
        public Jwk[] Keys { get; set; }
    }

    /// <summary>
    /// Single key representation for <see cref="Jwks"/>
    /// </summary>
    public class Jwk
    {
        [JsonProperty("kid")]
        public string Kid { get; set; }

        [JsonProperty("kty")]
        public string Kty { get; set; }

        [JsonProperty("alg")]
        public string Alg { get; set; }

        [JsonProperty("use")]
        public string Use { get; set; }

        [JsonProperty("n")]
        public string N { get; set; }

        [JsonProperty("e")]
        public string E { get; set; }

        [JsonProperty("x5c")]
        public string[] X5c { get; set; }

        [JsonProperty("x5t")]
        public string X5t { get; set; }

        [JsonProperty("x5t#S256")]
        public string X5tS256 { get; set; }

    }
}
