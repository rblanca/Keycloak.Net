using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Enums
    {
        [JsonProperty("operationType")]
        public IEnumerable<string> OperationType { get; set; } = null!;

        [JsonProperty("eventType")]
        public IEnumerable<string> EventType { get; set; } = null!;

        [JsonProperty("resourceType")]
        public IEnumerable<string> ResourceType { get; set; } = null!;
    }
}