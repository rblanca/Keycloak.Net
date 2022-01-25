namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Specifies if the client needs to provide a request object with their authorization requests, and what method they can use for this.
    /// </summary>
    public enum RequestObjectRequired
    {
        /// <summary>
        /// Providing a request object is optional. In all other cases, providing a request object is mandatory.
        /// </summary>
        NotRequired,

        /// <summary>
        /// The request object must be provided by value.
        /// </summary>
        Request,

        /// <summary>
        /// The request object must be provided by reference.
        /// </summary>
        RequestUri,

        /// <summary>
        /// Either method can be used.
        /// </summary>
        RequestOrRequestUri
    }
}
