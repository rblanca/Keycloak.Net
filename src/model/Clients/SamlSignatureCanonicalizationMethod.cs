namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Canonicalization Method for XML signatures.
    /// </summary>
    public enum SamlSignatureCanonicalizationMethod
    {
        None,
        Exclusive,
        ExclusiveWithComments,
        Inclusive,
        InclusiveWithComments,
    }
}