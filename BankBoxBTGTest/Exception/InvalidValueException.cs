using BankBoxBTGTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBoxBTGTest.ExceptionClass
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string? message, MoneyNote[] notes) : base(message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Notes available:");
            foreach (var item in notes)
            {
                Console.WriteLine($"Value: ${item.Value}");
                Console.WriteLine($"Quantity: ${item.Quantity}");
            }
        }
    }
}