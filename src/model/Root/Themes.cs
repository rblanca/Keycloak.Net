using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Themes
    {
        [JsonProperty("common")]
        public IEnumerable<ThemeOptions> Common { get; set; } = null!;

        [JsonProperty("admin")]
        public IEnumerable<ThemeOptions> Admin { get; set; } = null!;

        [JsonProperty("login")]
        public IEnumerable<ThemeOptions> Login { get; set; } = null!;

        [JsonProperty("welcome")]
        public IEnumerable<ThemeOptions> Welcome { get; set; } = null!;

        [JsonProperty("account")]
        public IEnumerable<ThemeOptions> Account { get; set; } = null!;

        [JsonProperty("email")]
        public IEnumerable<ThemeOptions> Email { get; set; } = null!;
    }
}