using BankBoxBTGTest.ExceptionClass;
using BankBoxBTGTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.Interface.Implementation
{
    public class BankBoxService : IBankBoxService
    {
        private List<MoneyNote> BankBoxMoneyReserve;

        public BankBoxService(List<MoneyNote> bankBoxMoneyReserve)
        {
            BankBoxMoneyReserve = bankBoxMoneyReserve;
        }

        public decimal GetTotalBankBoxBalance()
        {
            decimal bankBoxBalance = 0;
            BankBoxMoneyReserve.ForEach(money => bankBoxBalance += money.Value * money.Quantity);
            return bankBoxBalance;
        }

        public void RegisterMoneyNotes(MoneyNote note)
        {
            var money = BankBoxMoneyReserve.FirstOrDefault(m => m.Value == note.Value);
            if (money != null)
            {
                BankBoxMoneyReserve.Remove(money);
                money.Quantity += note.Quantity;
                BankBoxMoneyReserve.Add(money);
            }
        }

        public List<MoneyNote> Withdrawn(decimal value, Client client)
        {
            if (client.Balance < value) throw new InsufficientMoneyNotesException("Insufficient balance");

            if (!ValidateValue(value)) throw new InsufficientMoneyNotesException("Value Not Valid: should be more than $10 and less than Bank Box Limit");
            
            decimal partialValue = value;
            List<MoneyNote> withdrawnPackage = new List<MoneyNote>();

            foreach (var moneyNotes in BankBoxMoneyReserve.OrderByDescending(m=>m.Value))
            {
                if (partialValue != 0.0M
                    && moneyNotes.Value <= partialValue)
                    
                {
                    var notesQuantity = (int)(partialValue / moneyNotes.Value);
                    var clientMoney = new MoneyNote(moneyNotes.Value, notesQuantity);
                    if (clientMoney.Quantity <= moneyNotes.Quantity)
                    {
                        partialValue -= (clientMoney.Value * clientMoney.Quantity);
                        withdrawnPackage.Add(clientMoney);
                    }
                }
                if (partialValue == 0.0M) break;
            }
           
            if (withdrawnPackage.Count() == 0) throw new InsufficientMoneyNotesException("We don’t have enough notes to your request");

            Console.WriteLine("here is your money");
            Console.WriteLine();

            withdrawnPackage.ForEach(moneyNote =>
            {
                Console.WriteLine();
                Console.WriteLine($"Value: ${moneyNote.Value}");
                Console.WriteLine($"NotesQuantity: {moneyNote.Quantity}");
                Console.WriteLine();
                RegisterMoneyNotes(new MoneyNote(moneyNote.Value, moneyNote.Quantity * -1));
            });

            return withdrawnPackage;
        }
        private bool ValidateValue(decimal value)
        {
            bool validationResult = false;
            decimal totalBankBoxMoney = GetTotalBankBoxBalance();
            
            if (totalBankBoxMoney == 0) throw new NotBalanceException("Not enough money");

            foreach (var moneyNotes in BankBoxMoneyReserve)
            {
                validationResult = (value % moneyNotes.Value == 0);
                if (validationResult) break;
            }
            return validationResult && (totalBankBoxMoney >= value);
        }
      
    }
}
