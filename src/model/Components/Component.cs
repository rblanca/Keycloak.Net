using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    public class Component
    {
        /// <summary>
        /// The provider id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Display name of provider when linked in admin console.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <inheritdoc cref="ComponentProviderTypesId"/>
        [JsonProperty("providerId")]
        public ComponentProviderTypesId ProviderId { get; set; }

        /// <summary>
        /// The actual implementation type of the <see cref="ProviderId"/>.
        /// </summary>
        [JsonProperty("providerType")]
        public string ProviderType { get; set; }

        /// <summary>
        /// The parent component id that this component belongs to.
        /// </summary>
        [JsonProperty("parentId")]
        public string? ParentId { get; set; }

        /// <inheritdoc cref="ComponentConfig"/>
        [JsonProperty("config")]
        public ComponentConfig? Config { get; set; }

        /// <summary>
        /// The sub-component type for this component if available.
        /// </summary>
        [JsonProperty("subType")]
        public string? SubType { get; set; }
    }
}
