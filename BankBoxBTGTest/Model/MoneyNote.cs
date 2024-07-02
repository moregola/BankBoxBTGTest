using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.Model
{
    public class MoneyNote
    {
        public decimal Value = 0.0M;
        public int Quantity = 0;

        public MoneyNote(decimal value, int quantity)
        {
            Value = value;
            Quantity = quantity;
        }
    }
}
