using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        private readonly Dictionary<string, (string Name, string Phone)> _customers =
            new Dictionary<string, (string, string)>();

        public string RegisterCustomer(string name, string email, string phoneNumber)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            // Validate email format
            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format.");

            // Validate phone number format (10 digits only)
            if (!IsValidPhone(phoneNumber))
                throw new ArgumentException("Invalid phone number. Must be 10 digits.");

            if (CustomerExists(email, phoneNumber))
                throw new InvalidOperationException("Customer already exists.");

            _customers[email] = (name, phoneNumber);
            return $"Customer {name} registered successfully with email {email}.";
        }

        public bool CustomerExists(string email, string phoneNumber)
        {
            return _customers.ContainsKey(email) ||
                   _customers.Values.Any(c => c.Phone == phoneNumber);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            // Simple regex for email validation
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }

        private bool IsValidPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return false;

            // Ensure only digits and length = 10
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
    }
}
