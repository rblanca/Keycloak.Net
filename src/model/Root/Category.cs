using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(CategoryConverter))]
    public enum Category
    {
        AttributeStatementMapper, 
        DockerAuthMapper, 
        GroupMapper, 
        RoleMapper, 
        TokenMapper
    }
}