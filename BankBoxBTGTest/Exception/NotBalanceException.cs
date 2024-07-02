namespace BankBoxBTGTest.ExceptionClass
{

    public class NotBalanceException : Exception
    {
        public NotBalanceException(string? message) : base(message)
        {
        }
    }
}
