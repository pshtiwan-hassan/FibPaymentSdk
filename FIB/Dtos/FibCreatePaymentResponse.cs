using System;

#if NET48
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentResponse
    {
#if NET48
        [JsonProperty(PropertyName = "paymentId")]
#else
        [JsonPropertyName("paymentId")]
#endif
        public string? PaymentId { get; set; }

#if NET48
        [JsonProperty(PropertyName = "readableCode")]
#else
        [JsonPropertyName("readableCode")]
#endif
        public string? ReadableCode { get; set; }

#if NET48
        [JsonProperty(PropertyName = "qrCode")]
#else
        [JsonPropertyName("qrCode")]
#endif
        public string? QrCode { get; set; }

#if NET48
        [JsonProperty(PropertyName = "validUntil")]
#else
        [JsonPropertyName("validUntil")]
#endif
        public DateTime? ValidUntil { get; set; }

#if NET48
        [JsonProperty(PropertyName = "personalAppLink")]
#else
        [JsonPropertyName("personalAppLink")]
#endif
        public string? PersonalAppLink { get; set; }

#if NET48
        [JsonProperty(PropertyName = "businessAppLink")]
#else
        [JsonPropertyName("businessAppLink")]
#endif
        public string? BusinessAppLink { get; set; }

#if NET48
        [JsonProperty(PropertyName = "corporateAppLink")]
#else
        [JsonPropertyName("corporateAppLink")]
#endif
        public string? CorporateAppLink { get; set; }
    }
}