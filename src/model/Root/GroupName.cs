using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(GroupNameConverter))]
    public enum GroupName
    {
        Social, 
        UserDefined
    }
}