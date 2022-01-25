using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(ConfigTypeConverter))]
    public enum ConfigType
    {
        Int, 
        String
    }
}