using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class FormAuthenticatorProviders
    {
        [JsonProperty("registration-page-form")]
        public HasOrder? RegistrationPageForm { get; set; }
    }
}