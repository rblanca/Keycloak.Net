using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/saml/mappers/UsernameTemplateMapper.Target.html
    /// </summary>
    [JsonConverter(typeof(UsernameTemplateMapperTargetConverter))]
    public enum UsernameTemplateMapperTarget
    {
        Local,
        BrokerId,
        BrokerUsername
    }
}
