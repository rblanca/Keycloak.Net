using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/server-spi/src/main/java/org/keycloak/storage/UserStorageProvider.java
    /// </summary>
    public class KerberosConfig : ComponentConfig
    {
        /// <summary>
        /// Full name of server principal for HTTP service including server and domain name. <br/>
        /// Example: <c>HTTP/host.foo.org@FOO.ORG</c>.
        /// </summary>
        /// <remarks>Use '*' to accept any service principal in the KeyTab file.</remarks>
        [JsonProperty("serverPrincipal")]
        public IEnumerable<string>? ServerPrincipal { get; set; }

        /// <summary>
        /// Enable/disable possibility of username/password authentication against Kerberos database.
        /// </summary>
        [JsonProperty("allowPasswordAuthentication")]
        public IEnumerable<bool>? AllowPasswordAuthentication { get; set; }

        /// <summary>
        /// Enable/disable debug logging to standard output for Krb5LoginModule.
        /// </summary>
        [JsonProperty("debug")]
        public IEnumerable<bool>? Debug { get; set; }

        /// <inheritdoc cref="Components.EditMode"/>
        [JsonProperty("editMode")]
        public IEnumerable<EditMode>? EditMode { get; set; }

        /// <summary>
        /// Location of Kerberos KeyTab file containing the credentials of server principal. <br/>
        /// Example: <c>/etc/krb5.keytab</c>
        /// </summary>
        [JsonProperty("keyTab")]
        public IEnumerable<string>? KeyTab { get; set; }

        /// <inheritdoc cref="Components.CachePolicy"/>
        [JsonProperty("cachePolicy")]
        public IEnumerable<CachePolicy>? CachePolicy { get; set; }

        /// <summary>
        /// Update profile on first login.
        /// </summary>
        [JsonProperty("updateProfileFirstLogin")]
        public IEnumerable<bool>? UpdateProfileFirstLogin { get; set; }

        /// <summary>
        /// Name of kerberos realm. <br/>
        /// Example: <c>FOO.ORG</c>
        /// </summary>
        [JsonProperty("kerberosRealm")]
        public IEnumerable<string>? KerberosRealm { get; set; }
    }
}
