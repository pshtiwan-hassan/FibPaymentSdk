using Newtonsoft.Json;

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibAuthorizationResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string? TokenType { get; set; }

        [JsonProperty(PropertyName = "not-before-policy")]
        public int NotBeforePolicy { get; set; }

        [JsonProperty(PropertyName = "session_state")]
        public string? SessionState { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string? Scope { get; set; }
    }
}
