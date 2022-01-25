namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Signed SAML documents contain identification of signing key in KeyName element.
    /// </summary>
    public enum SamlSignatureKeyName
    {
        /// <summary>
        /// For others check and use <c>NONE</c> if no other option works.
        /// </summary>
        None,

        /// <summary>
        /// For Keycloak / RH-SSO counterparty, use <c>KEY_ID</c>.
        /// </summary>
        KeyId,

        /// <summary>
        /// For MS AD FS, use <c>CERT_SUBJECT</c>.
        /// </summary>
        CertSub
    }
}
