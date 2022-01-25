using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.Json;

namespace Keycloak.Net.Model.Converters
{
    public class NodeTypeConverter : JsonEnumConverter<NodeType>
    {
        private static readonly Dictionary<NodeType, string> SPairs = new()
        {
            [NodeType.Array] = "ARRAY",
            [NodeType.Binary] = "BINARY",
            [NodeType.Boolean] = "BOOLEAN",
            [NodeType.Missing] = "MISSING",
            [NodeType.Null] = "NULL",
            [NodeType.Number] = "NUMBER",
            [NodeType.Object] = "OBJECT",
            [NodeType.Pojo] = "POJO",
            [NodeType.String] = "STRING"
        };

        protected override string EntityString { get; } = "nodeType";

        protected override string ConvertToString(NodeType value) => SPairs[value];

        protected override NodeType ConvertFromString(string s)
        {
            if (SPairs.Values.Contains(s.ToUpper()))
            {
                return SPairs.First(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Key;
            }

            throw new ArgumentException($"Unknown {EntityString}: {s}");
        }
    }
}