using System;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class CardPaymentService : IPaymentService
    {
        private readonly string _cardNumber;
        private readonly string _expiryDate;
        private readonly string _cvv;

        public CardPaymentService(string cardNumber, string expiryDate, string cvv)
        {
            _cardNumber = cardNumber;
            _expiryDate = expiryDate;
            _cvv = cvv;
        }

        public void ProcessPayment(decimal amount)
        {
            if (_cardNumber.Length != 16 || _cvv.Length != 3)
            {
                Console.WriteLine("Invalid card details. Payment failed.");
                return;
            }

            Console.WriteLine($"Card ending with {_cardNumber.Substring(_cardNumber.Length - 4)} accepted.");
            Console.WriteLine($"Payment of ₹{amount} successful.");
        }
    }
}
