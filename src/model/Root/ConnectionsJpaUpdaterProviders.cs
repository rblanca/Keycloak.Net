﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ConnectionsJpaUpdaterProviders
    {
        [JsonProperty("liquibase")]
        public HasOrder Liquibase { get; set; }
    }
}