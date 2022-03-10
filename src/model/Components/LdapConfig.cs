using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    public class LdapConfig : ComponentConfig
    {
        [JsonProperty("fullSyncPeriod")]
        public IEnumerable<int>? FullSyncPeriod { get; set; }

        [JsonProperty("pagination")] 
        public IEnumerable<bool>? Pagination { get; set; }

        [JsonProperty("usersDn")]
        public IEnumerable<string>? UsersDn { get; set; }

        [JsonProperty("connectionPooling")]
        public IEnumerable<bool>? ConnectionPooling { get; set; }

        /// <inheritdoc cref="CachePolicy"/>
        [JsonProperty("cachePolicy")]
        public IEnumerable<CachePolicy>? CachePolicy { get; set; }

        [JsonProperty("useKerberosForPasswordAuthentication")]
        public IEnumerable<bool>? UseKerberosForPasswordAuthentication { get; set; }

        [JsonProperty("importEnabled")]
        public IEnumerable<bool>? ImportEnabled { get; set; }

        [JsonProperty("bindDn")]
        public IEnumerable<string>? BindDn { get; set; }

        [JsonProperty("usernameLDAPAttribute")]
        public IEnumerable<string>? UsernameLdapAttribute { get; set; }

        [JsonProperty("changedSyncPeriod")]
        public IEnumerable<int>? ChangedSyncPeriod { get; set; }

        [JsonProperty("bindCredential")]
        public IEnumerable<string>? BindCredential { get; set; }

        [JsonProperty("vendor")]
        public IEnumerable<string>? Vendor { get; set; }

        [JsonProperty("uuidLDAPAttribute")]
        public IEnumerable<string>? UuidLdapAttribute { get; set; }

        [JsonProperty("connectionUrl")]
        public IEnumerable<string>? ConnectionUrl { get; set; }

        [JsonProperty("allowKerberosAuthentication")]
        public IEnumerable<bool>? AllowKerberosAuthentication { get; set; }

        [JsonProperty("syncRegistrations")]
        public IEnumerable<bool>? SyncRegistrations { get; set; }

        [JsonProperty("authType")]
        public IEnumerable<string>? AuthType { get; set; }

        [JsonProperty("searchScope")]
        public IEnumerable<int>? SearchScope { get; set; }

        [JsonProperty("useTruststoreSpi")]
        public IEnumerable<string>? UseTruststoreSpi { get; set; }

        [JsonProperty("trustEmail")]
        public IEnumerable<bool>? TrustEmail { get; set; }

        [JsonProperty("userObjectClasses")]
        public IEnumerable<string>? UserObjectClasses { get; set; }

        [JsonProperty("rdnLDAPAttribute")]
        public IEnumerable<string>? RdnLdapAttribute { get; set; }

        /// <inheritdoc cref="Components.EditMode"/>
        [JsonProperty("editMode")]
        public IEnumerable<EditMode> EditMode { get; set; }

        [JsonProperty("validatePasswordPolicy")]
        public IEnumerable<bool>? ValidatePasswordPolicy { get; set; }

        [JsonProperty("batchSizeForSync")]
        public IEnumerable<int>? BatchSizeForSync { get; set; }

    }
}
