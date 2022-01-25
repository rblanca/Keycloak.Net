using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(NameConverter))]
    public enum Name
    {
        Base, 
        Keycloak, 
        RhSso
    }
}