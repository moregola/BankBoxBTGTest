using BankBoxBTGTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.Interface
{
    public interface IBankBoxService
    {
        List<MoneyNote> Withdrawn(decimal value, Client client);
        void RegisterMoneyNotes(MoneyNote note);
        decimal GetTotalBankBoxBalance();
    }
}
