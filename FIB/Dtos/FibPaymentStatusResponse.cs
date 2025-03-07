using System; 
using System.Text.Json.Serialization;
 

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibPaymentStatusResponse
    {
 
        [JsonPropertyName("paymentId")]
 
        public string? PaymentId { get; set; }

 
 
        [JsonPropertyName("status")]
 
        public string? Status { get; set; }

 
        [JsonPropertyName("amount")]
 
        public FibMonetaryValue? Amount { get; set; }

 
        [JsonPropertyName("paidBy")]
 
        public FibPayer? PaidBy { get; set; }

 
        [JsonPropertyName("decliningReason")]
 
        public string? DecliningReason { get; set; }

 
        [JsonPropertyName("declinedAt")]
 
        public DateTime? DeclinedAt { get; set; }

 
        [JsonPropertyName("paidAt")]
 
        public DateTime? PaidAt { get; set; }
    }

    public class FibPayer
    {
 
        [JsonPropertyName("name")]
 
        public string? Name { get; set; }

 
        [JsonPropertyName("iban")]
 
        public string? Iban { get; set; }
    }
}