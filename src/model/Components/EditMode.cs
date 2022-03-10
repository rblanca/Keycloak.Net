using System.ComponentModel;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    [JsonConverter(typeof(JsonEnumConverter<EditMode>))]
    public enum EditMode
    {
        [Description("READ_ONLY")]
        ReadOnly,

        [Description("UNSYNCED")]
        Unsynced
    }
}
