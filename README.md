# FibPaymentSDK 🚀

**FibPaymentSDK** is a .NET 9 SDK that simplifies integrating with Fib Payment API.  
It handles authentication, payment creation, status checks, cancellations, and refunds.

---

## 📌 Features
✅ Secure & Fast Payment Processing  
✅ OAuth2 Token Management  
✅ Retry Mechanism for Token Expiration  
✅ Easy Integration with .NET 9  
✅ Async API Calls  

---

## 📥 Installation
Install the package via **NuGet**:
```sh
dotnet add package FibPaymentSDK
```
Or via **Package Manager Console**:
```sh
Install-Package FibPaymentSDK
```

---

## 🚀 Usage
### **1️⃣ Initialize the Payment Service**
```csharp
using FibPaymentSdk.FIB;
using System.Net.Http;

var httpClient = new HttpClient();
var paymentService = new FibPaymentService(httpClient, 
    "https://api.fibpayment.com", 
    "your-client-id", 
    "your-client-secret");
```

---

### **2️⃣ Authenticate & Get Access Token**
```csharp
var tokenResponse = await paymentService.GetAccessTokenAsync();
Console.WriteLine($"Access Token: {tokenResponse.AccessToken}");
```

---

### **3️⃣ Create a Payment**
```csharp
var request = new FibCreatePaymentRequest
{
    MonetaryValue = new FibMonetaryValue
    {
        Amount = "1000",
        Currency = "IQD"
    },
    StatusCallbackUrl = "https://webhook-test.com",
    Description = "Tested By Pshitiwan",
    ExpiresIn = "PT5M",
    Category = "POS",
    RefundableFor = "PT48H"
};

var response = await paymentService.CreatePaymentAsync(request);

if (response != null)
{
    Console.WriteLine($"Payment successful! Transaction ID: {response.TransactionId}");
}
else
{
    Console.WriteLine("Payment failed.");
}
```

---

### **4️⃣ Check Payment Status**
```csharp
var statusResponse = await paymentService.CheckPaymentStatusAsync("txn_123456");
Console.WriteLine($"Payment Status: {statusResponse?.Status}");
```

---

### **5️⃣ Cancel a Payment**
```csharp
await paymentService.CancelPaymentAsync("txn_123456");
Console.WriteLine("Payment cancelled successfully.");
```

---

### **6️⃣ Refund a Payment**
```csharp
await paymentService.RefundPaymentAsync("txn_123456");
Console.WriteLine("Payment refunded successfully.");
```

---

## 🛠 Configuration
You can configure **API Credentials** in `appsettings.json`:
```json
{
  "FibPaymentSDK": {
    "ApiBaseUrl": "https://api.fibpayment.com",
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret"
  }
}
```

Or set it dynamically:
```csharp
var paymentService = new FibPaymentService(httpClient, "https://api.fibpayment.com", "your-client-id", "your-client-secret");
```

---

## 🔄 Poll Payment Status
If you need to **continuously check** payment status, use the `PollPaymentStatusAsync` method:
```csharp
await paymentService.PollPaymentStatusAsync("txn_123456", 5, 60, async status =>
{
    Console.WriteLine($"Payment Status Updated: {status.Status}");
});
```
This will check the payment **every 5 seconds** for up to **60 seconds**.

---

## 📜 License
This project is licensed under the **MIT License**.

---

## 🤝 Contributing
Pull requests are welcome!  
For major changes, please open an issue first to discuss the proposed changes.

---

## 🌎 Connect With Me
📧 **Email:** pshitiwan.eng@gmail.com  
💼 **LinkedIn:** [Pshitiwan Hassan](https://www.linkedin.com/in/pshtiwan-ahmed)  
🐙 **GitHub:** [pshtiwan-hassan](https://github.com/pshtiwan-hassan)  

---

### **💡 Next Steps**
✅ **Commit & Push this README to GitHub**  
✅ **Ensure Your GitHub Repo is Public**  
✅ **Share Your Repo Link on LinkedIn & Dev Communities**  

🚀🔥 Let me know if you need any modifications!  
