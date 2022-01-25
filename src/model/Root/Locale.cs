using Keycloak.Net.Model.Converters;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(LocaleConverter))]
    public enum Locale
    {
        En
    }
}