using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class KeycloakStorageClientStorageProviderMetadata : IMetadata
    {
        [JsonProperty("synchronizable")]
        public bool Synchronizable { get; set; }
    }
}