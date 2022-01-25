namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// The policy enforcement mode dictates how authorization requests are handled by the server.<br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/PolicyEnforcementMode.html
    /// </summary>
    public enum PolicyEnforcementMode
    {
        /// <summary>
        /// Completely disables the evaluation of policies and allow access to any resource.
        /// </summary>
        Disabled,

        /// <summary>
        /// Requests are denied by default even when there is no policy associated with a given resource.
        /// </summary>
        Enforcing,

        /// <summary>
        /// Requests are allowed even when there is no policy associated with a given resource.
        /// </summary>
        Permissive
    }
}
