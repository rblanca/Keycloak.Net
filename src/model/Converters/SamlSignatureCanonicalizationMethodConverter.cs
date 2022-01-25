using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Clients;

namespace Keycloak.Net.Model.Converters
{
    public class SamlSignatureCanonicalizationMethodConverter: JsonEnumConverter<SamlSignatureCanonicalizationMethod>
    {
        private static readonly Dictionary<SamlSignatureCanonicalizationMethod, string> SPairs = new Dictionary<SamlSignatureCanonicalizationMethod, string>
        {
            [SamlSignatureCanonicalizationMethod.None] = "",
            [SamlSignatureCanonicalizationMethod.Exclusive] = "http://www.w3.org/2001/10/xml-exc-c14n#",
            [SamlSignatureCanonicalizationMethod.ExclusiveWithComments] = "http://www.w3.org/2001/10/xml-exc-c14n#WithComments",
            [SamlSignatureCanonicalizationMethod.Inclusive] = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315",
            [SamlSignatureCanonicalizationMethod.InclusiveWithComments] = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments"
        };

        protected override string EntityString => nameof(SamlSignatureCanonicalizationMethod);

        protected override string ConvertToString(SamlSignatureCanonicalizationMethod value) => SPairs[value];

        protected override SamlSignatureCanonicalizationMethod ConvertFromString(string s)
        {
            if (SPairs.Values.Contains(s.ToLower()))
            {
                return SPairs.First(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Key;
            }

            throw new ArgumentException($"Unknown {EntityString}: {s}");
        }
    }
}