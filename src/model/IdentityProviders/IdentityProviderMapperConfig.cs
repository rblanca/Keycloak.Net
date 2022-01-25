using JsonSubTypes;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_identityprovidermapperrepresentation
    /// </summary>
    // https://stackoverflow.com/a/49214090/3104587
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(HardcodedUserSessionAttribute), nameof(HardcodedUserSessionAttribute.Attribute))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(HardcodedRole), nameof(HardcodedRole.Role))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AttributeImporter), nameof(AttributeImporter.JsonField))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(HardcodedAttribute), nameof(HardcodedAttribute.AttributeValue))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(UsernameTemplateImporter), nameof(UsernameTemplateImporter.Template))]
    public class IdentityProviderMapperConfig
    {
        /// <summary>
        /// Overrides the default sync mode of the IDP for this mapper. Values are:
        /// <list type="bullet">
        /// <item>
        ///     <term>Inherit</term>
        ///     <description>To use the sync mode defined in the identity provider for this mapper.</description>
        /// </item>
        /// <item>
        ///     <term>Legacy</term>
        ///     <description>To keep the behaviour before this option was introduced.</description>
        /// </item>
        /// <item>
        ///     <term>Import</term>
        ///     <description>To only import the user once during first login of the user with this identity provider.</description>
        /// </item>
        /// <item>
        ///     <term>Force</term>
        ///     <description>To always update the user during every login with this identity provider.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("syncMode")]
        public IdentityProviderSyncMode SyncMode { get; set; }
    }
}
