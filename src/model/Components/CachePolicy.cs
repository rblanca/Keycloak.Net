using System.ComponentModel;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Components
{
    /// <summary>
    /// Cache Policy for this storage provider.
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<CachePolicy>))]
    public enum CachePolicy
    {
        /// <summary>
        /// 'DEFAULT' is whatever the default settings are for the global cache.
        /// </summary>
        [Description("DEFAULT")]
        Default,

        /// <summary>
        /// 'EVICT_DAILY' is a time of day every day that the cache will be invalidated.
        /// </summary>
        [Description("EVICT_DAILY")]
        EvictDaily,

        /// <summary>
        /// 'EVICT_WEEKLY' is a day of the week and time the cache will be invalidated.
        /// </summary>
        [Description("EVICT_WEEKLY")]
        EvictWeekly,

        /// <summary>
        /// 'MAX_LIFESPAN' is the time in milliseconds that will be the lifespan of a cache entry.
        /// </summary>
        [Description("MAX_LIFESPAN")]
        MaxLifespan,

        /// <summary>
        /// 'NO_CACHE' means that no cache is stored.
        /// </summary>
        [Description("NO_CACHE")]
        NoCache
    }
}
