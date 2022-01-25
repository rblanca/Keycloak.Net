using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    public class UserRequired
    {
        [JsonProperty("roles")]
        public IEnumerable<string>? Roles { get; set; }
    }
}
