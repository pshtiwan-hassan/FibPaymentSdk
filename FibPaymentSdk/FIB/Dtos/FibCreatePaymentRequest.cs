using Newtonsoft.Json;

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibCreatePaymentRequest
    {
        [JsonProperty(PropertyName = "monetaryValue")]
        public FibMonetaryValue? MonetaryValue { get; set; }

        [JsonProperty(PropertyName = "statusCallbackUrl")]
        public string? StatusCallbackUrl { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "expiresIn")]
        public string? ExpiresIn { get; set; } 

        [JsonProperty(PropertyName = "category")]
        public string? Category { get; set; }

        [JsonProperty(PropertyName = "refundableFor")]
        public string? RefundableFor { get; set; }
    }

    public class FibMonetaryValue
    {
        [JsonProperty(PropertyName = "amount")]
        public string? Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string? Currency { get; set; }
    }
}
