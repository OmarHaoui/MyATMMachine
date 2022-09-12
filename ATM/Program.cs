namespace ATM

{
    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;
        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName; 
            this.lastName = lastName;
            this.balance = balance;
        }
        public string getNum() 
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getlastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setpin(int newPin)
        {
            pin = newPin;
        }
        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }


        public static void Main(string[] args)
        {
            Console.Title = "ATM Machine";
            Console.ForegroundColor = ConsoleColor.White;
            void printOptions()
            {
                Console.WriteLine("Choose from the following menu...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much $$$ do you want to deposit: ");

                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.getBalance());

                Console.WriteLine("Thank you for your $$$, your new balance is: {0:C}", currentUser.getBalance());
            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much $$$ do you want to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());
                //Check if the user balance is enough
                if(withdrawal > currentUser.getBalance())
                {
                    Console.WriteLine("Insufficient Balance!!!");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("You are good to go, thank you!");
                }

            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Your current balance is: {0:C}", currentUser.getBalance());
            }

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


            Console.WriteLine("Welcome to simple ATM");

            Console.WriteLine("Please insert yout debit card: ");
            string debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                debitCardNum = Console.ReadLine();  
                //check against our database
                currentUser = cardHolders.FirstOrDefault(p => p.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized!, please try again"); }
                }
                catch { Console.WriteLine("Card not recognized!, please try again"); }
            }

            Console.WriteLine("Please insert your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //check against our db
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect Pin!, please try again"); }
                }
                catch { Console.WriteLine("Incorrect Pin!, please try again"); }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;

            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
               if(option == 1) { deposit(currentUser); }
               else if (option == 2) { withdraw(currentUser); }
               else if (option == 3) { balance(currentUser); }
               else if (option == 4) { break; }
                else { option = 0; }
            } while (option != 4);
            Console.WriteLine("Thank you, have a nice day.");


            Console.ReadKey();
        }
    }
}