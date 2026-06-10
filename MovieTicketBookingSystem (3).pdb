using System.Collections.Generic;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    /// <summary>
    /// Implementation of ISignInService for customer authentication.
    /// </summary>
    public class SignInService : ISignInService
    {
        // Simple in-memory store of credentials (email → password)
        private readonly Dictionary<string, string> _credentials =
            new Dictionary<string, string>();

        // Track signed-in users
        private readonly HashSet<string> _signedInUsers = new HashSet<string>();

        public SignInService()
        {
            // Example: preloaded user
            _credentials["user@example.com"] = "password123";
        }

        public bool Authenticate(string email, string password)
        {
            if (_credentials.ContainsKey(email) && _credentials[email] == password)
            {
                _signedInUsers.Add(email);
                return true;
            }
            return false;
        }

        public bool IsSignedIn(string email) => _signedInUsers.Contains(email);

        public void SignOut(string email)
        {
            if (_signedInUsers.Contains(email))
                _signedInUsers.Remove(email);
        }
    }
}
