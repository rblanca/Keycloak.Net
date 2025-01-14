﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.RealmsAdmin
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_realmeventsconfigrepresentation
    /// </summary>
    public class RealmEventsConfig
    {
        [JsonProperty("adminEventsDetailsEnabled")]
        public bool? AdminEventsDetailsEnabled { get; set; }

        [JsonProperty("adminEventsEnabled")]
        public bool? AdminEventsEnabled { get; set; }

        [JsonProperty("enabledEventsTypes")]
        public IEnumerable<string>? EnabledEventsTypes { get; set; }

        [JsonProperty("eventsEnabled")]
        public bool? EventsEnabled { get; set; }

        [JsonProperty("eventsExpiration")]
        public long? EventsExpiration { get; set; }

        [JsonProperty("eventsListeners")]
        public IEnumerable<string>? EventsListeners { get; set; }
    }
}
