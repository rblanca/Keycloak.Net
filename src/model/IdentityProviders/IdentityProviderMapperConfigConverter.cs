using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keycloak.Net.Model.IdentityProviders
{
    // https://stackoverflow.com/a/41094764/3104587
    public class IdentityProviderMapperConfigConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serializer for serialization.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var mapperType = jsonObject["identityProviderMapper"].Value<string>();

            //var mapperType = test.Value<IdentityProviderMapperType>();
            //var mapperConfig = GetIdentityProviderMapperConfigType(mapperType);
            //serializer.Populate(reader, mapperConfig);

            //var test2 = serializer.Deserialize(reader, mapperConfig!.GetType());
            var test2 = serializer.Deserialize(reader, objectType);
            return test2;
        }

        public override bool CanWrite => false;

        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return typeof(IdentityProviderMapperConfig).IsAssignableFrom(objectType);
        }

        private Type? GetIdentityProviderMapperConfigType(IdentityProviderMapperType mapperType)
        {
            switch (mapperType)
            {
                case IdentityProviderMapperType.HardcodedUserSessionAttribute:
                    return typeof(HardcodedUserSessionAttribute);
                case IdentityProviderMapperType.HardcodedRole:
                    return typeof(HardcodedRole);
                case IdentityProviderMapperType.AttributeImporter:
                    return typeof(AttributeImporter);
                case IdentityProviderMapperType.HardcodedAttribute:
                    return typeof(HardcodedAttribute);
                case IdentityProviderMapperType.UsernameTemplateImporter:
                    return typeof(UsernameTemplateImporter);
                default:
                    // Cannot find correct type
                    return null;
            }
        }
    }
}
