// See https://aka.ms/new-Console-template for more information
using BankBoxBTGTest.ExceptionClass;
using BankBoxBTGTest.Interface.Implementation;
using BankBoxBTGTest.Model;

Console.WriteLine("Hello, World!");

bool exit = false;
//Starting the application with a default value
BankBoxService BankBoxInService = new BankBoxService(
        new List<MoneyNote>()
        {
            new MoneyNote (100,10),
            new MoneyNote (50,10),
            new MoneyNote (20,10),
            new MoneyNote (10,10),
        });

while (!exit)
{
    try
    {
        Console.WriteLine("Starting Bank Box");
        Console.WriteLine("Choose an option");
        Console.WriteLine("1 - Client");
        Console.WriteLine("2 - Reposition");
        Console.WriteLine("3 - Turn Off");

        var choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Welcome to our Bank Service");
            Console.WriteLine("Please, insert your ID");
            var clientId = Console.ReadLine();

            int.TryParse(clientId, out var parsedClientId);

            Console.WriteLine("Please, insert your password");

            var password = Console.ReadLine() ?? string.Empty;

            Client client = new Client(parsedClientId, password);

            //Will cross and validate the information
            // Here we could have method to get the client data e compare with password
            client = new ClientService(client).GetClient(parsedClientId, password);


            Console.WriteLine("Please, select the value you want to withdraw");

            var typedValue = Console.ReadLine();

            decimal.TryParse(typedValue, out var parsedTypedValue);

            var money = BankBoxInService.Withdrawn(parsedTypedValue, client);
            Console.WriteLine("here is your money");
            Console.WriteLine();

            money.ForEach(x =>
            {
                Console.WriteLine();
                Console.WriteLine($"Value: ${x.Value}");
                Console.WriteLine($"NotesQuantity: {x.Quantity}");
                Console.WriteLine();
            });

            Console.WriteLine("Please, take your money");
            Console.WriteLine("Thank you for using our service");
        }
        else if (choice == "2")
        {
            //to execute correctly we should implement a Verification to validate if the person choosing this is a bank worker
            Console.WriteLine("Starting Bank Box Reposition");
            //this will open a channel to insert the money phisicly 
            //probably each package has the same quantity of notes
            BankBoxInService = new BankBoxService(new List<MoneyNote>()
            {
                new MoneyNote (100,10),
                new MoneyNote (50,10),
                new MoneyNote (20,10),
                new MoneyNote (10,10),
            });
        }
        else if (choice == "3")
        {
            //to execute correctly we should implement a Verification to validate if the person choosing this is a bank worker
            exit=true;
        }
        else
        {
            throw new Exception("Invalid Option");
        }

    }
    catch (NotBalanceException ex)
    {
        //can implement a logger
        //can implement an alert
        //can block the screen till someone research it
        Console.WriteLine(ex.Message);
    }
    catch (InsufficientMoneyNotesException ex)
    {
        //can implement a logger
        //can implement an alert
        Console.WriteLine(ex.Message);
    }
    catch (InvalidOptionException ex)
    {
        //can implement a logger
        //can implement an alert
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        //can implement a logger
        //can implement an alert
        //this is a not mapped error and should be threat much more serious;
        Console.WriteLine("Critical Not expected exception: " + ex.Message);
    }
}

