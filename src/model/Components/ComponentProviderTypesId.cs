using System.ComponentModel;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// The keycloak component types supported.
    /// </summary>
    public enum ComponentProviderTypesId
    {
        [Description("aes-generated")]
        AesGenerated,

        [Description("allowed-client-templates")]
        AllowedClientTemplates,

        [Description("allowed-protocol-mappers")]
        AllowedProtocolMappers,

        [Description("consent-required")]
        ConsentRequired,

        [Description("declarative-user-profile")]
        DeclarativeUserProfile,

        [Description("hmac-generated")]
        HmacGenerated,

        /// <summary>
        /// Kerberos is a computer-network authentication protocol that works on the basis of tickets to allow nodes communicating over a non-secure network to prove their identity to one another in a secure manner.
        /// </summary>
        [Description("kerberos")]
        Kerberos,

        /// <summary>
        /// LDAP (Lightweight Directory Access Protocol) is an open and cross platform protocol used for directory services authentication. 
        /// </summary>
        [Description("ldap")]
        Ldap,

        [Description("max-clients")]
        MaxClients,

        [Description("rsa-generated")]
        RsaGenerated,

        [Description("scope")]
        Scope,

        [Description("trusted-hosts")]
        TrustedHosts,

        [Description("user-attribute-ldap-mapper")]
        UserAttributeLdapMapper,

        /// <summary>
        /// Vidicore Identity Provider
        /// </summary>
        [Description("vidicore-provider")]
        VidicoreProvider
    }
}
