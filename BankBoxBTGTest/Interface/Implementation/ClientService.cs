using BankBoxBTGTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.Interface.Implementation
{
    public class ClientService : IClientService
    {
        Client Client { get; set; }

        public ClientService(Client client)
        {
            Client = client;
        }

        public decimal GetBalance(Client data)
        {
            //Connect to a dataBase to get the information
            return Client.Balance;
        }

        public Client GetClient(int id, string password)
        {
            //Connect to a dataBase to get the information
            //Validate information using ValidateClient
            return Client;
        }

        public Client GetClient(string userName, string password)
        {
            //Connect to a dataBase to get the information
            //Validate information using ValidateClient
            return Client;
        }

        public Client GetClient(int id, string username, string password)
        {
            return Client;
        }

        public bool ValidateClient(Client data)
        {
            //this method should validate the information provided with database information 
            return true;
        }
    }
}
