using System;
using System.Text.Json.Serialization;
 

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentResponse
    {
 
        [JsonPropertyName("paymentId")]
 
        public string? PaymentId { get; set; }

 
        [JsonPropertyName("readableCode")]
 
        public string? ReadableCode { get; set; }

 
        [JsonPropertyName("qrCode")]
 
        public string? QrCode { get; set; }

 
        [JsonPropertyName("validUntil")]
 
        public DateTime? ValidUntil { get; set; }

 
        [JsonPropertyName("personalAppLink")]
 
        public string? PersonalAppLink { get; set; }

 
        [JsonPropertyName("businessAppLink")]
 
        public string? BusinessAppLink { get; set; }
 
        [JsonPropertyName("corporateAppLink")]
 
        public string? CorporateAppLink { get; set; }
    }
}