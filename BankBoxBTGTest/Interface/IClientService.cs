using BankBoxBTGTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
