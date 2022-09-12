using System.Text;
using System.Threading.Channels;

class cardHolder
{
    public string cardNum { get; set; }
    public int pin { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public double balance { get; set; }

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    string requestPIN()
    {
        StringBuilder sb = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        int i = 0;
        do
        {
            keyInfo = Console.ReadKey(true);
            
            if(!char.IsControl(keyInfo.KeyChar))
            {
                sb.Append(keyInfo.KeyChar);
                Console.Write("*");
                i++;
                
            }
        }while(keyInfo.Key != ConsoleKey.Enter);
        Console.WriteLine("\n");
        {
                return sb.ToString();
        }
    }

    int printOptions()
    {
        int choice;
        do
        {
            choice = 0;
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose an option: \n1. Deposit\n2. Withdraw\n3. Show balance\n4. Exit");
                Console.ForegroundColor = ConsoleColor.Green;
                choice = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4) { break; }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Choise. choose a number from 1 to 4."); }
            }
            catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Choise. choose a number from 1 to 4."); }

        } while (true);
        return choice;
    }
    static cardHolder cardNumVer(List<cardHolder> cardHolders)
    {
        cardHolder currentUser;
        string cardEntered = "";
        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your card number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                cardEntered = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(p => p.cardNum == cardEntered);
                if (currentUser != null) { break; }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Card Number!, try again."); }
            }
            catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Card Number!, try again."); }
        } while (true);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Card Number Verified.");
        return currentUser;
    }
    void pinVer(cardHolder currentUser)
    {
        int pin = 0;
        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your Pin number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                pin = int.Parse(requestPIN());
                if (pin == currentUser.pin) { break; }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Pin!, try again."); }
            }
            catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Pin!, try again."); }
        } while (true);
    }
    void deposit(cardHolder currentUser)
    {
        double moneyEntered;
        
        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How much do you want to deposit?");
                Console.ForegroundColor = ConsoleColor.Green;
                moneyEntered = double.Parse(Console.ReadLine());
                if (moneyEntered > 0) 
                { 
                    currentUser.balance += moneyEntered;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("The operation succeded!,thanks a lot"); 
                    break; 
                }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Try again, Invalid input!"); }
            }
            catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Try again, Invalid input!"); }

        } while (true);

    }
    void withdraw(cardHolder currentUser)
    {
        double withdrawal = 0;
        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How much you want to withdraw :");
                Console.ForegroundColor = ConsoleColor.Green;
                withdrawal = double.Parse(Console.ReadLine());
                if (withdrawal < currentUser.balance) 
                { 
                    currentUser.balance -= Math.Abs(withdrawal);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Operation succeded!, Thanks a lot."); 
                    break;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Your money is not enough!, please try again."); }
            }
            catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Input!, please try again."); }
        } while (true);

    }
    void showBalance(cardHolder currentUser)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Your balance is: {0:C}", currentUser.balance);
    }
    private static int Main(string[] args)
    {
        List<cardHolder> cardHolders = new List<cardHolder>()
        {
                new cardHolder("5197149864619736", 6189, "Mildred", "Barnhardt", 525.34),
                new cardHolder("4052617275803096", 2561, "Eddie", "Edwards", 986.4),
                new cardHolder("5192142996284532", 1234, "Wade", "Abney", 466.787),
                new cardHolder("4099215499130126", 7385, "Allen", "Rivera", 235.26),
                new cardHolder("4074588175011474", 9124, "Casey", "Donovan", 353.6),
                new cardHolder("377384157170963", 6242,  "Laverne", "Martin" ,532.53),
                new cardHolder("4567019349086188", 1436, "Cecelia", "Bucholz", 55.6)
        };
        //Sets the title of the console
        Console.Title = "    .......* ATM Machine *.......";
        //Sets the text color of the console also known as the foreground color 
        Console.ForegroundColor = ConsoleColor.White;

            cardHolder currentUser = cardNumVer(cardHolders);
            currentUser.pinVer(currentUser);

            Console.WriteLine("Welcome {0}!", currentUser.firstName);
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            int userChoice = currentUser.printOptions();
            if (userChoice == 4)
            {
                Console.WriteLine("Thank you for your time.");
                Console.ReadKey();
                return 0;
            }
            else if (userChoice == 1)
            {
                currentUser.deposit(currentUser);
            }
            else if (userChoice == 2)
            {
                currentUser.withdraw(currentUser);
            }
            else if (userChoice == 3)
            {
                currentUser.showBalance(currentUser);
            }
        Console.ReadKey();
        }
    }
}