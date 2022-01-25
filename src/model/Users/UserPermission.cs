using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    public class UserPermission
    {
        [JsonProperty("view")]
        public IEnumerable<string>? View { get; set; }

        [JsonProperty("edit")]
        public IEnumerable<string>? Edit { get; set; }
    }
}
