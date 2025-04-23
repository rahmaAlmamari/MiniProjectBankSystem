namespace MiniProjectBankSystem
{
    internal class Program
    {
        //========== 1. Globle varaibles =========

        //========== 2. Main method ===========
        static void Main(string[] args)
        {
            //to call WelcomeMessage method ...
            WelcomeMessage();
            //to keep the system runs until user choose to closed the system ...
            bool MainRun = true;//to get the user option ...
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

                    case '0'://to call Exsit method ...
                        Exsit();
                        MainRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();//just to hoad second ...
                        break;
                }
                
            }

        }

        //========== 3. EndUser menu ===========
        public static void EndUserMenu()
        {
            Console.WriteLine("userMenu");
            Console.ReadLine();
        }

        //========== 4. Admain menu ==========
        public static void AdmainMenu()
        {
            Console.WriteLine("adminMenu");
            Console.ReadLine();
        }

        //========== 5. EndUser use case ==========

        //========== 6. Admain use case ==========

        //========== 7. Addtional methods ===========
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
        //7.3. Exsit method ...
        public static void Exsit()
        {
            Console.WriteLine("Have a nice day (^0^)");
        }

    }
}
