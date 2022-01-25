using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    public class UserProfile
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("required")]
        public UserRequired? Required { get; set; }

        [JsonProperty("permissions")]
        public UserPermission? Permissions { get; set; }

        [JsonProperty("validations")]
        public object? Validations { get; set; }
    }
}
