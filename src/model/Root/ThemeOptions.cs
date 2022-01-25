using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ThemeOptions
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("locales")]
        public IEnumerable<string> Locales { get; set; } = null!;
    }
}