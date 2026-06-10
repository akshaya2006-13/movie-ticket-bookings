namespace MOVIETICKETBOOKINGSYSTEM.Interfaces
{
    public interface ISignInService
    {
        bool Authenticate(string email, string password);
        bool IsSignedIn(string email);

            void SignOut(string email);
    }
}
