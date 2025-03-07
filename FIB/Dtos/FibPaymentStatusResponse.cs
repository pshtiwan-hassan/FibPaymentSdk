using System;

#if NET48
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibPaymentStatusResponse
    {
#if NET48
        [JsonProperty(PropertyName = "paymentId")]
#else
        [JsonPropertyName("paymentId")]
#endif
        public string? PaymentId { get; set; }

#if NET48
        [JsonProperty(PropertyName = "status")]
#else
        [JsonPropertyName("status")]
#endif
        public string? Status { get; set; }

#if NET48
        [JsonProperty(PropertyName = "amount")]
#else
        [JsonPropertyName("amount")]
#endif
        public FibMonetaryValue? Amount { get; set; }

#if NET48
        [JsonProperty(PropertyName = "paidBy")]
#else
        [JsonPropertyName("paidBy")]
#endif
        public FibPayer? PaidBy { get; set; }

#if NET48
        [JsonProperty(PropertyName = "decliningReason")]
#else
        [JsonPropertyName("decliningReason")]
#endif
        public string? DecliningReason { get; set; }

#if NET48
        [JsonProperty(PropertyName = "declinedAt")]
#else
        [JsonPropertyName("declinedAt")]
#endif
        public DateTime? DeclinedAt { get; set; }

#if NET48
        [JsonProperty(PropertyName = "paidAt")]
#else
        [JsonPropertyName("paidAt")]
#endif
        public DateTime? PaidAt { get; set; }
    }

    public class FibPayer
    {
#if NET48
        [JsonProperty(PropertyName = "name")]
#else
        [JsonPropertyName("name")]
#endif
        public string? Name { get; set; }

#if NET48
        [JsonProperty(PropertyName = "iban")]
#else
        [JsonPropertyName("iban")]
#endif
        public string? Iban { get; set; }
    }
}