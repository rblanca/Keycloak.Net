using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class KeycloakStorageLdapMappersLdapStorageMapperMetadata : IMetadata
    {
        [JsonProperty("fedToKeycloakSyncSupported")]
        public bool FedToKeycloakSyncSupported { get; set; }

        [JsonProperty("keycloakToFedSyncSupported")]
        public bool KeycloakToFedSyncSupported { get; set; }

        [JsonProperty("fedToKeycloakSyncMessage")]
        public string FedToKeycloakSyncMessage { get; set; } = null!;

        [JsonProperty("keycloakToFedSyncMessage")]
        public string KeycloakToFedSyncMessage { get; set; } = null!;
    }
}