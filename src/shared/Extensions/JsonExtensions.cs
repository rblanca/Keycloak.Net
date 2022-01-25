using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Keycloak.Net.Shared.Extensions
{
    /// <summary>
    /// Utility class for Json.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Default Json.Net Serializer settings
        /// </summary>
        public static JsonSerializerSettings JsonSerializerSettings => new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
            DefaultValueHandling = DefaultValueHandling.Include,
            PreserveReferencesHandling = PreserveReferencesHandling.None,
            Formatting = Formatting.None,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        /// <summary>
        /// Reads a json file and deserializes it to specified object type. 
        /// </summary>
        public static T DeserializeJsonFromFile<T>(string file, JsonSerializerSettings? options = null)
        {
            using var reader = File.OpenText(file);
            var result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd(), options ?? JsonSerializerSettings);

            return result;
        }

        /// <summary>
        /// Deserializes a json string to an object
        /// </summary>
        public static T DeserializeJson<T>(this string json, JsonSerializerSettings? options = null)
        {
            var result = JsonConvert.DeserializeObject<T>(json, options ?? JsonSerializerSettings);
            return result;
        }

        /// <inheritdoc cref="DeserializeJson{T}"/>
        public static object DeserializeJson(this string json, Type type, JsonSerializerSettings? options = null)
        {
            var result = JsonConvert.DeserializeObject(json, type, options ?? JsonSerializerSettings);
            return result;
        }

        /// <summary>
        /// Serializes an object to json string
        /// <remarks>
        /// Serialized json are not formatted by default
        /// </remarks>
        /// </summary>
        public static string SerializeJson<T>(this T obj, JsonSerializerSettings? options = null)
        {
            var result =  JsonConvert.SerializeObject(obj, options ?? JsonSerializerSettings);
            return result;
        }

        /// <inheritdoc cref="SerializeJson{T}"/>
        public static string SerializeJson(this object obj, Type type, JsonSerializerSettings? options = null)
        {
            var result = JsonConvert.SerializeObject(obj, type, options ?? JsonSerializerSettings);
            return result;
        }

        /// <summary>
        /// Checks if the json string is a valid json object.
        /// See https://stackoverflow.com/a/14977915.
        /// </summary>
        public static bool IsValidJson(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) { return false; }
            json = json.Trim();
            if ((json.StartsWith("{") && json.EndsWith("}")) || //For object
                (json.StartsWith("[") && json.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(json);
                    return obj != null;
                }
                catch (JsonReaderException ex)
                {
                    //Exception in parsing json
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
