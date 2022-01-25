using Newtonsoft.Json;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/oidc/mappers/UsernameTemplateMapper.html
    /// </summary>
    public class UsernameTemplateImporter : IdentityProviderMapperConfig
    {
        /// <summary>
        /// Destination field for the mapper.
        /// <list type="bullet">
        /// <item>
        ///     <term>LOCAL (default)</term>
        ///     <description>The changes are applied to the username stored in local database upon user import.</description>
        /// </item>
        /// <item>
        ///     <term>BROKER_ID</term>
        ///     <description>The changes are stored into the ID used for federation user lookup</description>
        /// </item>
        /// <item>
        ///     <term>BROKER_USERNAME</term>
        ///     <description>The changes are stored into the username used for federation user lookup</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("target")]
        public UsernameTemplateMapperTarget Target { get; set; }

        /// <summary>
        /// Template to use to format the username to import. Substitutions are enclosed in ${}.<br/>
        /// <list type="bullet">
        /// <item>ALIAS is the provider alias.</item>
        /// <item>CLAIM.{NAME} references an ID or Access token claim.</item>
        /// </list>
        /// The substitution can be converted to upper or lower case by appending |uppercase or |lowercase to the substituted value, e.g. '${CLAIM.sub | lowercase}
        /// </summary>
        /// <example>'${ALIAS}.${CLAIM.sub}'</example>
        [JsonProperty("template")]
        public string? Template { get; set; }
    }
}
