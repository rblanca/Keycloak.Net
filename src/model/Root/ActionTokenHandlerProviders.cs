using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ActionTokenHandlerProviders
    {
        [JsonProperty("verify-email")]
        public HasOrder VerifyEmail { get; set; } = null!;

        [JsonProperty("execute-actions")]
        public HasOrder ExecuteActions { get; set; } = null!;

        [JsonProperty("reset-credentials")]
        public HasOrder ResetCredentials { get; set; } = null!;

        [JsonProperty("idp-verify-account-via-email")]
        public HasOrder IdpVerifyAccountViaEmail { get; set; } = null!;
    }
}