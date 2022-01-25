using Newtonsoft.Json;

namespace Keycloak.Net.Model.ClientAttributeCertificate
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_keystoreconfig <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/github' />/services/src/main/java/org/keycloak/services/resources/admin/ClientAttributeCertificateResource.java
    /// </summary>
    public class KeyStoreConfig
    {
        [JsonProperty("format")]
        public string? Format { get; set; }

        [JsonProperty("keyAlias")]
        public string? KeyAlias { get; set; }

        [JsonProperty("keyPassword")]
        public string? KeyPassword { get; set; }

        [JsonProperty("realmAlias")]
        public string? RealmAlias { get; set; }

        [JsonProperty("realmCertificate")]
        public bool? RealmCertificate { get; set; }

        [JsonProperty("storePassword")]
        public string? StorePassword { get; set; }
    }
}
