using System;
using Newtonsoft.Json;

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentResponse
    {
        [JsonProperty(PropertyName = "paymentId")]
        public string? PaymentId { get; set; }

        [JsonProperty(PropertyName = "readableCode")]
        public string? ReadableCode { get; set; }

        [JsonProperty(PropertyName = "qrCode")]
        public string? QrCode { get; set; }

        [JsonProperty(PropertyName = "validUntil")]
        public DateTime? ValidUntil { get; set; }

        [JsonProperty(PropertyName = "personalAppLink")]
        public string? PersonalAppLink { get; set; }

        [JsonProperty(PropertyName = "businessAppLink")]
        public string? BusinessAppLink { get; set; }

        [JsonProperty(PropertyName = "corporateAppLink")]
        public string? CorporateAppLink { get; set; }
    }
}
