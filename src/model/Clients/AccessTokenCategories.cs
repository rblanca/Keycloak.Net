namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken
    /// </summary>
    public enum AccessTokenCategories
    {
        Internal, 
        Access, 
        Id, 
        Admin, 
        UserInfo,
        Logout,
        AuthorizationResponse
    }
}
