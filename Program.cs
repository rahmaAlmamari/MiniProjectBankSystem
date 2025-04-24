using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MiniProjectBankSystem
{
    internal class Program
    {
        //============================== 1. Globle varaibles ===================
        //1.1. MinimumBalance Constant ...
        const double MinimumBalance = 100.0;
        //1.2. Account number generator
        static int LastAccountNumber;
        //1.3. createAccountRequests queue ...
        static Queue<string> createAccountRequests = new Queue<string>();
        //1.4. lists to store user data (parallel)
        static List<int> accountNumbers = new List<int>();
        static List<string> accountUserNames = new List<string>();
        static List<string> nationalID = new List<string>();
        static List<double> balances = new List<double>();
        //1.5. reviewsStack stack ...
        static Stack<string> reviewsStack = new Stack<string>();

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
                        HoldScreen();//to hold the screen ...
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
                        HoldScreen();//to hold the screen ...
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
                Console.WriteLine("1. Approve reguests accounts opening");
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
                        ApproveReguestsAccountsOpening();
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
                        HoldScreen();//to hold the screen ...
                        break;
                }

            }
        }

        //============================== 5. EndUser use case ===================
        //5.1. Reguest account opening ...
        public static void ReguestAccountOpening()
        {
            //to get the input from the user ...
            string UserName = StringNamingValidation("name");//to get and validate UserName input ...
            string UserNationalID = StringValidation("national ID");//to get and validate UserNationalID input ...
            bool BalanceIsValide;
            double InitialBalance;
            do
            {
                InitialBalance = DoubleValidation("initial balance");//to get and validate InitialBalance input ...
                BalanceIsValide = CheckBalanceEqualsMinimumBalance(InitialBalance);//to check if InitialBalance > MinimumBalance or not ...
            } while (!BalanceIsValide);
            //to combain all the input together and store it in createAccountRequests queue ...
            string request = UserName + "|" + UserNationalID+"|"+ InitialBalance;
            createAccountRequests.Enqueue(request);
            int num = createAccountRequests.Count();
            Console.WriteLine("Your request submited successfully");
            Console.WriteLine("Their is "+ num +" request");
            HoldScreen();//to hold the screen ...


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
            //to get the review input from the user ...
            string review = StringValidation("review");//to validate the review ...
            //to store the review in the reviewsStack ...
            reviewsStack.Push(review);
            Console.WriteLine("Your review submited successfully");
            HoldScreen();//to hold the screen ...
        }

        //============================ 6. Admain use case =======================
        //6.1. Approve reguests accounts opening ...
        public static void ApproveReguestsAccountsOpening()
        {
            //to check if there are request or not ...
            if(createAccountRequests.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to get first request submited to createAccountRequests queue ...
            string request = createAccountRequests.Dequeue();
            string[] RequestDteials = request.Split('|').ToArray();
            //to display the first request in the queue ...
            Console.WriteLine("The first request in queue:");
            Console.WriteLine($"User Name: {RequestDteials[0]}\n" +
                              $"User National ID: {RequestDteials[1]}\n" +
                              $"Initial Balance: {RequestDteials[2]}");
            bool action = ConfirmAction("approved this request");
            if (action)
            {
                //to set newAccountNumber ...
                int newAccountNumber = LastAccountNumber + 1;
                accountNumbers.Add(newAccountNumber);
                LastAccountNumber = newAccountNumber;

                accountUserNames.Add(RequestDteials[0]);
                nationalID.Add(RequestDteials[1]);
                balances.Add(Convert.ToDouble(RequestDteials[2]));//to convert RequestDteials from string to double ...

                Console.WriteLine($"Account created successfully for: {RequestDteials[0]}\n" +
                    $" with Account Number: {newAccountNumber}");
                HoldScreen();//to hold the screen ...

            }

        }
        //6.2. View opinging accounts ...
        public static void ViewOpingingAccounts()
        {
            //to check if there is opened accounts or not ...
            if(accountNumbers.Count == 0)
            {
                Console.WriteLine("There is no opened accounts yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to display all opened accounts ...
            Console.WriteLine("Accounts information:");
            Console.WriteLine("Account No \t|\t User Name \t|\t National ID \t|\t Balance");
            for(int i = 0; i < accountNumbers.Count; i++)
            {
                Console.WriteLine($"{accountNumbers[i]} \t|\t {accountUserNames[i]} " +
                                  $"\t|\t {nationalID[i]} \t|\t {balances[i]}");
            }
            HoldScreen();//to hold the screen ...
        }
        //6.3. View all review ...
        public static void ViewAllReview()
        {
           //to check if there is review submited or not ...
           if(reviewsStack.Count == 0)
            {
                Console.WriteLine("There is no review submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method .
            }
            //to display all the review submited to the reviewsStack ...
            foreach(string review in reviewsStack)
            {
                Console.WriteLine($"{review}");
                Console.WriteLine("----------------------");
            }
            HoldScreen();//to hold the screen ...
        }
        //6.4. Process requests ...
        public static void ProcessRequests()
        {
            Console.WriteLine("ProcessRequests");
            Console.ReadLine();
        }

        //============================ 7. Validation =============================
        //7.1. CharValidation method ...
        public static char CharValidation(string message)
        {
            bool CharFlag;//to handle user char error input ...
            char CharInput = '0';
            do
            {
                try
                {
                    CharFlag = false;
                    Console.WriteLine($"Enter your {message}:");
                    CharInput = char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Your {message} not accepted due to: " + e.Message);
                    CharFlag = true;
                }

            } while (CharFlag);

            //to return tne char input ...
            return CharInput;
        }
        //7.2. StringNamingValidation method ...
        public static string StringNamingValidation(string message)
        {
            bool StringNamingFlag;//to handle user StringNaming error input ...
            string StringNamingInput = "null";
            do
            {
                StringNamingFlag = false;
                Console.WriteLine($"Enter your {message}:");
                StringNamingInput = Console.ReadLine();
                //to check if StringNamingInput has number or not ...
                bool check_StringNaming = IsAlpha(StringNamingInput);
                if (check_StringNaming == false)
                {
                    Console.WriteLine($"{message} can not contains number and con not be null ..." +
                                      "please prass enter key to try again");
                    Console.ReadLine();//just to hoad second ...
                    StringNamingFlag = true;
                }

            } while (StringNamingFlag);

            //to return tne char input ...
            return StringNamingInput;
        }
        //7.3. StringValidation method ...
        public static string StringValidation(string message)
        {
            bool StringFlag;//to handle user StringNaming error input ...
            string StringInput = "null";
            do
            {
                StringFlag = false;
                Console.WriteLine($"Enter your {message}:");
                StringInput = Console.ReadLine();
                // Check if StringInput null or empty
                if (string.IsNullOrWhiteSpace(StringInput))
                {
                    Console.WriteLine($"{message} cannot be empty. Please prass enter key to try again");
                    Console.ReadLine();//just to hoad second ...
                    StringFlag = true;
                }

            } while (StringFlag);

            //to return tne char input ...
            return StringInput;
        }
        //7.4. DoubleValidation method ...
        public static double DoubleValidation(string message)
        {
            bool DoubleFlag;//to handle user StringNaming error input ...
            double DoubleInput = 0;
            do
            {
                DoubleFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message}:");
                    DoubleInput = double.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to " + e.Message);
                    Console.WriteLine("please prass enter key to try again");
                    Console.ReadLine();
                    DoubleFlag = true;
                }
         
            } while (DoubleFlag);
            //to return tne char input ...
            return DoubleInput;
        }

        //============================ 8. Addtional methods ======================
        //8.1. WelcomeMessage method ...
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Codeline Bank System\nWe hope you have a pleasant time using our services " +
                              "(^0^)\nPress enter key to go to the menu screen");
            HoldScreen();//to hold the screen ...
        }
        //8.2. To check of the string contains something other than letters like number and empty space(this methos return true or false)....
        static bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
        //8.3. Check if balance == MinimumBalance ...
        public static bool CheckBalanceEqualsMinimumBalance(double value)
        {
            bool IsValide;
            if(value < MinimumBalance)
            {
                IsValide = false;
                Console.WriteLine($"Your {value} amount is lass then minimum balance: {MinimumBalance}" +
                    $"\n please prass enter key to try again");
                HoldScreen();//to hold the screen ...

            }
            else
            {
                IsValide = true;
            }
            return IsValide;
        }
        //8.4. ConfirmAction method ...
        public static bool ConfirmAction(string action)
        {
            //confirm process ...
            bool flag_action;//to know if the user enter choice or not
            char actionChoice = 'y';
            bool actionStatus;//to set the confirm action status true/false ...
            do
            {
                flag_action = false;
                try
                {
                    Console.WriteLine($"“Are you sure to {action} ? Y/N");
                    actionChoice = char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please confirm your action");
                    flag_action = true;
                }
            } while (flag_action);

            if (actionChoice == 'Y' || actionChoice == 'y')
            {
                actionStatus = true;
            }
            else
            {
                actionStatus = false;
            }

            return actionStatus;
        }
        //8.5. To hoad the screen ...
        public static void HoldScreen()
        {
            Console.WriteLine("Press (Enter Kay) to continue");
            Console.ReadLine();
        }




    }
}
