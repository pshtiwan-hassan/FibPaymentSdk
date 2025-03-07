using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FibPaymentSdk.FIB.Dtos;
using Newtonsoft.Json;

namespace FibPaymentSdk.FIB
{
    public class FibPaymentService : IFibPaymentService
    {
        private string? _cachedToken;
        private DateTime _tokenExpiration = DateTime.MinValue;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public FibPaymentService(HttpClient httpClient, string baseUrl, string clientId, string clientSecret)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<FibAuthorizationResponse> GetAccessTokenAsync()
        {
            if (_cachedToken != null && DateTime.Now < _tokenExpiration)
                return new FibAuthorizationResponse { AccessToken = _cachedToken };

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/auth/realms/fib-online-shop/protocol/openid-connect/token")
            {
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("client_secret", _clientSecret)
                }.AsReadOnly())
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<FibAuthorizationResponse>(json);

            _cachedToken = tokenResponse?.AccessToken;
            if (tokenResponse?.ExpiresIn > 0)
            {
                _tokenExpiration = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn - 5);
            }

            return tokenResponse;
        }

        private async Task<string> MakeAuthorizedRequestAsync(HttpMethod method, string url, object? data = null)
        {
            for (int attempt = 1; attempt <= 2; attempt++)
            {
                var accessToken = await GetAccessTokenAsync();
                if (accessToken == null || string.IsNullOrEmpty(accessToken.AccessToken))
                    throw new UnauthorizedAccessException("Unable to acquire access token");

                var request = new HttpRequestMessage(method, url)
                {
                    Content = data is null
                        ? null
                        : new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && attempt == 1)
                {
                    Console.WriteLine("Access token expired. Regenerating token...");
                    _cachedToken = null; // Clear cached token
                    continue;
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

            throw new UnauthorizedAccessException("Unable to acquire a valid access token after retrying.");
        }

        public async Task<FibCreatePaymentResponse?> CreatePaymentAsync(FibCreatePaymentRequest request)
        {
            var response = await MakeAuthorizedRequestAsync(HttpMethod.Post, $"{_baseUrl}/protected/v1/payments", request);
            return JsonConvert.DeserializeObject<FibCreatePaymentResponse>(response);
        }

        public async Task<FibPaymentStatusResponse?> CheckPaymentStatusAsync(string paymentId)
        {
            var response = await MakeAuthorizedRequestAsync(HttpMethod.Get, $"{_baseUrl}/protected/v1/payments/{paymentId}/status");
            return JsonConvert.DeserializeObject<FibPaymentStatusResponse>(response);
        }

        public async Task CancelPaymentAsync(string? paymentId)
        {
            await MakeAuthorizedRequestAsync(HttpMethod.Post, $"{_baseUrl}/protected/v1/payments/{paymentId}/cancel");
        }

        public async Task RefundPaymentAsync(string? paymentId)
        {
            await MakeAuthorizedRequestAsync(HttpMethod.Post, $"{_baseUrl}/protected/v1/payments/{paymentId}/refund");
        }

        public async Task PollPaymentStatusAsync(string paymentId, int intervalInSeconds, int timeoutInSeconds, Func<FibPaymentStatusResponse, Task> onStatusUpdate)
        {
            var timeout = DateTime.UtcNow.AddSeconds(timeoutInSeconds);

            while (DateTime.UtcNow < timeout)
            {
                var status = await CheckPaymentStatusAsync(paymentId);

                Console.WriteLine($"PaymentId: {paymentId} - Status: {status?.Status}");

                if (status?.Status == "PAID" || status?.Status == "DECLINED")
                {
                    await onStatusUpdate(status); // Callback to update the database
                    return;
                }

                await Task.Delay(TimeSpan.FromSeconds(intervalInSeconds));
            }

            Console.WriteLine($"PaymentId: {paymentId} - Timeout reached without final status.");
        }


        private void HandlePaymentStatus(string paymentId, FibPaymentStatusResponse? status)
        {
            switch (status?.Status)
            {
                case "PAID":
                    Console.WriteLine($"PaymentId: {paymentId} has been paid successfully.");
                    // TODO: Update database or notify user
                    break;

                case "DECLINED":
                    Console.WriteLine($"PaymentId: {paymentId} was declined.");
                    // TODO: Update database or notify user with declining reason
                    break;

                default:
                    Console.WriteLine($"PaymentId: {paymentId} is in an unexpected state: {status?.Status}");
                    break;
            }
        }
    }
}
