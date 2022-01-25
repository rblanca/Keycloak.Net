using System.Collections.Generic;
using Keycloak.Net.Model.Common;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class KeycloakAuthenticationFormAction
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("helpText")]
        public string HelpText { get; set; } = null!;

        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty> Properties { get; set; } = null!;

        [JsonProperty("metadata")]
        public KeycloakAuthenticationFormActionMetadata Metadata { get; set; } = null!;
    }
}