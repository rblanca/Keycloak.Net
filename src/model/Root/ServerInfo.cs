using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_serverinforepresentation
    /// </summary>
    public class ServerInfo
    {
        [JsonProperty("builtinProtocolMappers")]
        public BuiltinProtocolMappers? BuiltinProtocolMappers { get; set; }

        [JsonProperty("clientImporters")]
        public string? ClientImporters { get; set; }

        [JsonProperty("clientInstallations")]
        public ClientInstallations? ClientInstallations { get; set; }

        [JsonProperty("componentTypes")]
        public ComponentTypes? ComponentTypes { get; set; }

        [JsonProperty("enums")]
        public Enums? Enums { get; set; }

        [JsonProperty("identityProviders")]
        public IEnumerable<Provider>? IdentityProviders { get; set; }

        [JsonProperty("memoryInfo")]
        public MemoryInfo? MemoryInfo { get; set; }

        [JsonProperty("passwordPolicies")]
        public IEnumerable<PasswordPolicy>? PasswordPolicies { get; set; }

        [JsonProperty("profileInfo")]
        public ProfileInfo? ProfileInfo { get; set; }

        [JsonProperty("protocolMapperTypes")]
        public ProtocolMapperTypes? ProtocolMapperTypes { get; set; }

        [JsonProperty("providers")]
        public ServerInfoProviders? Providers { get; set; }

        [JsonProperty("socialProviders")]
        public IEnumerable<Provider>? SocialProviders { get; set; }

        [JsonProperty("systemInfo")]
        public SystemInfo? SystemInfo { get; set; }

        [JsonProperty("themes")]
        public Themes? Themes { get; set; }

    }
}
