using System.Text.Json.Serialization;
 

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentRequest
    {
 
        [JsonPropertyName("monetaryValue")]
 
        public FibMonetaryValue? MonetaryValue { get; set; }

 
        [JsonPropertyName("statusCallbackUrl")]
 
        public string? StatusCallbackUrl { get; set; }

 
        [JsonPropertyName("description")]
 
        public string? Description { get; set; }

 
 
        [JsonPropertyName("expiresIn")]
 
        public string? ExpiresIn { get; set; }

 
        [JsonPropertyName("category")]
 
        public string? Category { get; set; }

 
        [JsonPropertyName("refundableFor")]
 
        public string? RefundableFor { get; set; }
    }

    public class FibMonetaryValue
    {
 
        [JsonPropertyName("amount")]
 
        public string? Amount { get; set; }

 
        [JsonPropertyName("currency")]
 
        public string? Currency { get; set; }
    }
}