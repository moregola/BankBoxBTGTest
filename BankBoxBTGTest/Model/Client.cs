namespace BankBoxBTGTest.Model
{
    public class Client
    {
        public decimal Balance = 0.0M;
        public long Id = 0;
        private string Password = string.Empty;
        private string UserName = string.Empty;

        public Client(decimal balance, long id, string password, string userName)
        {
            Balance = balance;
            Id = id;
            Password = password;
            UserName = userName;
        }
        public Client(long id, string password)
        {
            Id = id;
            Password = password;
            //As asked in the task
            Balance = 9999999999999999999999999999.99M;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetUserName()
        {
            return UserName;
        }
    }
}
