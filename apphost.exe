using System;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class UpiPaymentService : IPaymentService
    {
        private readonly string _upiId;

        public UpiPaymentService(string upiId)
        {
            _upiId = upiId;
        }

        public void ProcessPayment(decimal amount)
        {
            if (string.IsNullOrWhiteSpace(_upiId) || !_upiId.Contains("@"))
            {
                Console.WriteLine("Invalid UPI ID. Payment failed.");
                return;
            }

            Console.WriteLine($"UPI ID {_upiId} accepted.");
            Console.WriteLine($"Payment of ₹{amount} successful.");
        }
    }
}
