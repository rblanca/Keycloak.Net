using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// The specific component configuration.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AesGeneratedConfig), nameof(ComponentProviderTypesId.AesGenerated))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AllowedClientTemplatesConfig), nameof(ComponentProviderTypesId.AllowedClientTemplates))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AllowedProtocolMappersConfig), nameof(ComponentProviderTypesId.AllowedProtocolMappers))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(HmacGeneratedConfig), nameof(ComponentProviderTypesId.HmacGenerated))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KerberosConfig), nameof(ComponentProviderTypesId.Kerberos))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(LdapConfig), nameof(ComponentProviderTypesId.Ldap))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(MaxClientsConfig), nameof(ComponentProviderTypesId.MaxClients))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(RsaGeneratedConfig), nameof(ComponentProviderTypesId.RsaGenerated))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(TrustedHostsConfig), nameof(ComponentProviderTypesId.TrustedHosts))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(UserAttributeLdapMapperConfig), nameof(ComponentProviderTypesId.UserAttributeLdapMapper))]
    public class ComponentConfig
    {
        /// <summary>
        /// Priority of provider when doing a user lookup. Lowest first.
        /// </summary>
        [JsonProperty("priority")]
        public IEnumerable<string>? Priority { get; set; }
        
        /// <summary>
        /// If provider is disabled, it will not be considered for queries and imported users will be disabled and read-only until the provider is enabled again.
        /// </summary>
        [JsonProperty("enabled")]
        public IEnumerable<bool>? Enabled { get; set; } = new[] { true };

        [JsonProperty("vidiCoreUrl")]
        public IEnumerable<string>? VidicoreUrl { get; set;  }
    }
}