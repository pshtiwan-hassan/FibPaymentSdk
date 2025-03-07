#if NET48
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibAuthorizationResponse
    {
#if NET48
        [JsonProperty(PropertyName = "access_token")]
#else
        [JsonPropertyName("access_token")]
#endif
        public string? AccessToken { get; set; }

#if NET48
        [JsonProperty(PropertyName = "expires_in")]
#else
        [JsonPropertyName("expires_in")]
#endif
        public int ExpiresIn { get; set; }

#if NET48
        [JsonProperty(PropertyName = "refresh_expires_in")]
#else
        [JsonPropertyName("refresh_expires_in")]
#endif
        public int RefreshExpiresIn { get; set; }

#if NET48
        [JsonProperty(PropertyName = "refresh_token")]
#else
        [JsonPropertyName("refresh_token")]
#endif
        public string? RefreshToken { get; set; }

#if NET48
        [JsonProperty(PropertyName = "token_type")]
#else
        [JsonPropertyName("token_type")]
#endif
        public string? TokenType { get; set; }

#if NET48
        [JsonProperty(PropertyName = "not-before-policy")]
#else
        [JsonPropertyName("not-before-policy")]
#endif
        public int NotBeforePolicy { get; set; }

#if NET48
        [JsonProperty(PropertyName = "session_state")]
#else
        [JsonPropertyName("session_state")]
#endif
        public string? SessionState { get; set; }

#if NET48
        [JsonProperty(PropertyName = "scope")]
#else
        [JsonPropertyName("scope")]
#endif
        public string? Scope { get; set; }
    }
}