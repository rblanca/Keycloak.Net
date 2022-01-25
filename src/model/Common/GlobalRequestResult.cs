using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Common
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_globalrequestresult
    /// </summary>
    public class GlobalRequestResult
    {
        [JsonProperty("failedRequests")]
        public IEnumerable<string>? FailedRequests { get; set; }

        [JsonProperty("successRequests")]
        public IEnumerable<string>? SuccessRequests { get; set; }
    }
}
