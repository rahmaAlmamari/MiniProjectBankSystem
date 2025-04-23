namespace MiniProjectBankSystem
{
    internal class Program
    {
        //============================== 1. Globle varaibles ===================

        //============================== 2. Main method ========================
        static void Main(string[] args)
        {
            //to call WelcomeMessage method ...
            WelcomeMessage();
            //to keep the system runs until user choose to closed the system ...
            bool MainRun = true;//to stop main method ...
            while (MainRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. User menu");
                Console.WriteLine("2. Admain menu");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                char MainOption = CharValidation("option");
                //to run the option user want ...
                switch (MainOption)
                {
                    case '1'://to call User menu method ...
                        EndUserMenu();
                        break;

                    case '2'://to call Admain menu method ...
                        AdmainMenu();
                        break;

                    case '0'://to exsit Main ...
                        Console.WriteLine("Have a nice day (^0^)");
                        MainRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();//just to hoad second ...
                        break;
                }
                
            }

        }

        //============================== 3. EndUser menu =======================
        public static void EndUserMenu()
        {
            //to keep the EndUserMenu method runs until user choose to closed it ...
            bool EndUserMenuRun = true;//to stop the EndUserMenu method ...
            while (EndUserMenuRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. Reguest account opening");
                Console.WriteLine("2. Deposite money");//to put money to your account ...
                Console.WriteLine("3. Withdraw money");//to take money from your account ...
                Console.WriteLine("4. Check balance");//to know how much in your account ...
                Console.WriteLine("5. Submit review");//to submit message with what you like and what not to the admin ...
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                char EndUserMenuOption = CharValidation("option");
                //to run the option user want ...
                switch (EndUserMenuOption)
                {
                    case '1'://to call ReguestAccountOpening method ...
                        ReguestAccountOpening();
                        break;

                    case '2'://to call DepositeMoney method ...
                        DepositeMoney();
                        break;

                    case '3'://to call WithdrawMoney method ...
                        WithdrawMoney();
                        break;

                    case '4'://to call CheckBalance method ...
                        CheckBalance();
                        break;

                    case '5'://to call SubmitReview method ...
                        SubmitReview();
                        break;

                    case '0'://to exsit EndUserMenu ...
                        EndUserMenuRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();//just to hoad second ...
                        break;
                }

            }
        }

        //============================== 4. Admain menu ========================
        public static void AdmainMenu()
        {
            //to keep the AdmainMenu method runs until user choose to closed it ...
            bool AdmainMenuRun = true;//to stop the AdmainMenu method ...
            while (AdmainMenuRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. View reguests accounts opening");
                Console.WriteLine("2. View opinging accounts in the system");
                Console.WriteLine("3. View all review in the system");
                Console.WriteLine("4. Process requests");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                char AdmainMenuRunOption = CharValidation("option");
                //to run the option user want ...
                switch (AdmainMenuRunOption)
                {
                    case '1'://to call ViewReguestsAccountsOpening method ...
                        ViewReguestsAccountsOpening();
                        break;

                    case '2'://to call ViewOpingingAccounts method ...
                        ViewOpingingAccounts();
                        break;

                    case '3'://to call ViewAllReview method ...
                        ViewAllReview();
                        break;

                    case '4'://to call ProcessRequests method ...
                        ProcessRequests();
                        break;

                    case '0'://to exsit AdmainMenuRun ...
                        AdmainMenuRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();//just to hoad second ...
                        break;
                }

            }
        }

        //============================== 5. EndUser use case ===================
        //5.1. Reguest account opening ...
        public static void ReguestAccountOpening()
        {
            Console.WriteLine("ReguestAccountOpening");
            Console.ReadLine();
        }
        //5.2. Deposite money ...
        public static void DepositeMoney()
        {
            Console.WriteLine("DepositeMoney");
            Console.ReadLine();
        }
        //5.3. Withdraw money ...
        public static void WithdrawMoney()
        {
            Console.WriteLine("WithdrawMoney");
            Console.ReadLine();
        }
        //5.4. Check balance ...
        public static void CheckBalance()
        {
            Console.WriteLine("CheckBalance");
            Console.ReadLine();
        }
        //5.5. Submit review ...
        public static void SubmitReview()
        {
            Console.WriteLine("SubmitReview");
            Console.ReadLine();
        }

        //============================ 6. Admain use case =======================
        //6.1. View reguests accounts opening ...
        public static void ViewReguestsAccountsOpening()
        {
            Console.WriteLine("ViewReguestsAccountsOpening");
            Console.ReadLine();
        }
        //6.2. View opinging accounts ...
        public static void ViewOpingingAccounts()
        {
            Console.WriteLine("ViewOpingingAccounts");
            Console.ReadLine();
        }
        //6.3. View all review ...
        public static void ViewAllReview()
        {
            Console.WriteLine("ViewAllReview");
            Console.ReadLine();
        }
        //6.4. Process requests ...
        public static void ProcessRequests()
        {
            Console.WriteLine("ProcessRequests");
            Console.ReadLine();
        }

        //============================ 7. Addtional methods ======================
        //7.1. WelcomeMessage method ...
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Codeline Bank System\nWe hope you have a pleasant time using our services " +
                              "(^0^)\nPress enter key to go to the menu screen");
            //just to hold a second ...
            Console.ReadLine();
        }
        //7.2. CharValidation method ...
        public static char CharValidation(string message)
        {
            bool CharFlag;//to handle user char error input ...
            char CharInput = '0';
            do
            {
                try
                {
                    CharFlag = false;
                    Console.WriteLine($"Please enter your {message}:");
                    CharInput = char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your option not accepted due to: " + e.Message);
                    CharFlag = true;
                }

            } while (CharFlag);

            //to return tne char input ...
            return CharInput;
        }

    }
}
