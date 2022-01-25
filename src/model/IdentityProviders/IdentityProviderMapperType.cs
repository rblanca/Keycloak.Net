using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    [JsonConverter(typeof(IdentityProviderMapperTypeConverter))]
    public enum IdentityProviderMapperType
    {
        HardcodedUserSessionAttribute,
        HardcodedRole,
        AttributeImporter,
        HardcodedAttribute,
        UsernameTemplateImporter
    }
}
