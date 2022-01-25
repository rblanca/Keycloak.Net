using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    public class UserProfiles
    {
        [JsonProperty("attributes")]
        public IEnumerable<UserProfile>? Attributes { get; set; }
    }
}
