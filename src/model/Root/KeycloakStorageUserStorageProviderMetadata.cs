using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class KeycloakStorageUserStorageProviderMetadata : IMetadata
    {
        [JsonProperty("synchronizable")]
        public bool? Synchronizable { get; set; }
    }
}