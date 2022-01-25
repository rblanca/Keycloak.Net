using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonTypeLabelConverter))]
    public enum JsonTypeLabel
    {
        Boolean, 
        ClientList, 
        File, 
        List, 
        MultivaluedList, 
        MultivaluedString, 
        Password, 
        Role, 
        Script, 
        String, 
        Text
    }
}