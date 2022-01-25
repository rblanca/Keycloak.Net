using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net.Model.Converters
{
    public class RequestObjectRequiredConverter : JsonEnumConverter<RequestObjectRequired>
    {
        private static readonly Dictionary<RequestObjectRequired, string> s_pairs = new Dictionary<RequestObjectRequired, string>
        {
            [RequestObjectRequired.NotRequired] = "not required",
            [RequestObjectRequired.Request] = "request only", 
            [RequestObjectRequired.RequestUri] = "request_uri only", 
            [RequestObjectRequired.RequestOrRequestUri] = "request or request_uri"
        };

        protected override string EntityString => nameof(RequestObjectRequired);

        protected override string ConvertToString(RequestObjectRequired value) => s_pairs[value];

        protected override RequestObjectRequired ConvertFromString(string s)
        {
            var pair = s_pairs.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<RequestObjectRequired, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown {EntityString}: {s}");
            }

            return pair.Key;
        }
    }
}
