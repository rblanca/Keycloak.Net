﻿using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Net.Model.AuthorizationManagement;

namespace Keycloak.Net.Model.Converters
{
    public class DecisionStrategiesConverter : JsonEnumConverter<DecisionStrategy>
    {
        private static readonly Dictionary<DecisionStrategy, string> SPairs = new()
        {
            [DecisionStrategy.Affirmative] = "AFFIRMATIVE",
            [DecisionStrategy.Consensus] = "CONSENSUS",
            [DecisionStrategy.Unanimous] = "UNANIMOUS"
        };

        protected override string EntityString => nameof(DecisionStrategy);

        protected override string ConvertToString(DecisionStrategy value) => SPairs[value];

        protected override DecisionStrategy ConvertFromString(string s)
        {
            if (SPairs.Values.Contains(s.ToUpper()))
            {
                return SPairs.First(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Key;
            }

            throw new ArgumentException($"Unknown {EntityString}: {s}");
        }
    }
}