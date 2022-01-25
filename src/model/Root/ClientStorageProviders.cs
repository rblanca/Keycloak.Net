using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ClientStorageProviders
    {
        [JsonProperty("openshift-oauth-client")]
        public HasOrder? OpenshiftOAuthClient { get; set; }
    }
}
