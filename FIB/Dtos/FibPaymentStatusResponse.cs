using System;
using Newtonsoft.Json;

namespace FibPaymentSdk.FIB.Dtos
{
    public class FibPaymentStatusResponse
    {
        [JsonProperty(PropertyName = "paymentId")]
        public string? PaymentId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string? Status { get; set; } 

        [JsonProperty(PropertyName = "amount")]
        public FibMonetaryValue? Amount { get; set; }

        [JsonProperty(PropertyName = "paidBy")]
        public FibPayer? PaidBy { get; set; }
        [JsonProperty(PropertyName = "decliningReason")]
        public string? DecliningReason { get; set; }

        [JsonProperty(PropertyName = "declinedAt")]
        public DateTime? DeclinedAt { get; set; }
        [JsonProperty(PropertyName = "paidAt")]
        public DateTime? PaidAt { get; set; }
    }
    public class FibPayer
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "iban")]
        public string? Iban { get; set; }
    }
}
