using BankBoxBTGTest.Model;

namespace BankBoxBTGTest.Interface
{
    public interface IClientService
    {
        Client GetClient(int id, string username, string password);
        Client GetClient(int id, string password);
        Client GetClient(string userName, string password);
        bool ValidateClient(Client client);
        decimal GetBalance(Client client);
    }
}
