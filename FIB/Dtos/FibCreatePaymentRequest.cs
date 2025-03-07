#if NET48
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentRequest
    {
#if NET48
        [JsonProperty(PropertyName = "monetaryValue")]
#else
        [JsonPropertyName("monetaryValue")]
#endif
        public FibMonetaryValue? MonetaryValue { get; set; }

#if NET48
        [JsonProperty(PropertyName = "statusCallbackUrl")]
#else
        [JsonPropertyName("statusCallbackUrl")]
#endif
        public string? StatusCallbackUrl { get; set; }

#if NET48
        [JsonProperty(PropertyName = "description")]
#else
        [JsonPropertyName("description")]
#endif
        public string? Description { get; set; }

#if NET48
        [JsonProperty(PropertyName = "expiresIn")]
#else
        [JsonPropertyName("expiresIn")]
#endif
        public string? ExpiresIn { get; set; }

#if NET48
        [JsonProperty(PropertyName = "category")]
#else
        [JsonPropertyName("category")]
#endif
        public string? Category { get; set; }

#if NET48
        [JsonProperty(PropertyName = "refundableFor")]
#else
        [JsonPropertyName("refundableFor")]
#endif
        public string? RefundableFor { get; set; }
    }

    public class FibMonetaryValue
    {
#if NET48
        [JsonProperty(PropertyName = "amount")]
#else
        [JsonPropertyName("amount")]
#endif
        public string? Amount { get; set; }

#if NET48
        [JsonProperty(PropertyName = "currency")]
#else
        [JsonPropertyName("currency")]
#endif
        public string? Currency { get; set; }
    }
}