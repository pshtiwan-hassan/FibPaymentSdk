
using System.Threading.Tasks;
using FibPaymentSdk.FIB.Dtos;


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