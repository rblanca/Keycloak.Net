using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    [JsonConverter(typeof(IdentityProviderSyncModeConverter))]
    public enum IdentityProviderSyncMode
    {
        /// <summary>
        /// To use the sync mode defined in the identity provider for this mapper.
        /// </summary>
        Inherit,

        /// <summary>
        /// To keep the behaviour before this option was introduced.
        /// </summary>
        Legacy,

        /// <summary>
        /// To only import the user once during first login of the user with this identity provider.
        /// </summary>
        Import,

        /// <summary>
        /// To always update the user during every login with this identity provider.
        /// </summary>
        Force
    }
}
