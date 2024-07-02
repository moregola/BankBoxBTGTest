namespace BankBoxBTGTest.ExceptionClass
{
    public class InsufficientMoneyNotesException : Exception
    {
        public InsufficientMoneyNotesException(string? message) : base(message)
        {
        }
    }
}
