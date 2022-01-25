using Newtonsoft.Json;

namespace Keycloak.Net.Model.ClientScopes
{
    /// <summary>
    /// Additional attributes for <see cref="ClientScope"/>.
    /// </summary>
    public class Attributes
    {
        [JsonProperty("consent.screen.text")]
        public string? ConsentScreenText { get; set; }

        [JsonProperty("display.on.consent.screen")]
        public bool? DisplayOnConsentScreen { get; set; }

        [JsonProperty("include.in.token.scope")]
        public bool? IncludeInTokenScope { get; set; }
    }
}