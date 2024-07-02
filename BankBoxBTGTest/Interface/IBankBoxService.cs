using BankBoxBTGTest.Model;

namespace BankBoxBTGTest.Interface
{
    public interface IBankBoxService
    {
        List<MoneyNote> Withdrawn(decimal value, Client client);
        void RegisterMoneyNotes(MoneyNote note);
        decimal GetTotalBankBoxBalance();
    }
}
