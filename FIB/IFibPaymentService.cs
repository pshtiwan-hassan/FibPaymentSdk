
using System.Threading.Tasks;
using FibPaymentSdk.FIB.Dtos;
#if NET48
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

namespace FibPaymentSdk.FIB
{
    public interface IFibPaymentService
    {
        
        Task<FibAuthorizationResponse?> GetAccessTokenAsync();

        
        Task<FibCreatePaymentResponse?> CreatePaymentAsync(FibCreatePaymentRequest request);

         
        Task<FibPaymentStatusResponse?> CheckPaymentStatusAsync(string paymentId); 
        Task CancelPaymentAsync(string? paymentId);
        Task RefundPaymentAsync(string? paymentId);
    }
}