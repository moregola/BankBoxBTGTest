using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.ExceptionClass
{

    public class NotBalanceException : Exception
    {
        public NotBalanceException(string? message) : base(message)
        {
        }
    }
}
