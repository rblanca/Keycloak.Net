using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class AuthorizationPersisterProviders
    {
        [JsonProperty("jpa")]
        public HasOrder Jpa { get; set; } = null!;
    }
}