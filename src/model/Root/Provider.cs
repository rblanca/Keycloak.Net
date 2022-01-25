using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Provider
    {
        [JsonProperty("groupName")]
        public GroupName GroupName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("id")]
        public string Id { get; set; } = null!;
    }
}