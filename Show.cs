namespace MOVIETICKETBOOKINGSYSTEM.Interfaces
{
    public interface ICustomerRegistrationService
    {
        string RegisterCustomer(string name, string email, string phoneNumber);
        bool CustomerExists(string email, string phoneNumber);
    }
}
