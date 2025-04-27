using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;//to deal with list, stack and queue ...
using System.IO;//to import Input output backage to deal with files ...

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
        //1.6. AccountsFilePath to store accounts.txt path
        //where we will store account information 
        const string AccountsFilePath = "accounts.txt";
        //1.7. ReviewsFilePath to store reviews.txt path
        //where we will store review details 
        const string ReviewsFilePath = "reviews.txt";
        //1.8. RequestsFilePath to store requests.txt path
        //where we will store request details 
        const string RequestsFilePath = "requests.txt";
        //1.9. EndUsersFilePath to store users.txt path
        //where we will store users info 
        const string EndUsersFilePath = "users.txt";
        //1.8. AdminsFilePath to store admin.txt path
        //where we will store admin info 
        const string AdminsFilePath = "admin.txt";
        //1.10. LoginUserNationalID list to store users info
        static List<string> LoginUserNationalID = new List<string>();
        //1.11. LoginAdminNationalID list to store users info
        static List<string> LoginAdminNationalID = new List<string>();

        //============================== 2. Main method ========================
        static void Main(string[] args)
        {
            //to call WelcomeMessage method ...
            WelcomeMessage();
            //to load the accounts information from the file and store it into the lists ...
            LoadAccountsInformationFromFile();
            //to load the review details from the file and store it into the stack ...
            LoadReviews();
            //to load the request account opening
            //details from the file and store it into the queue ...
            LoadSaveRequestAccountOpening();
            //to load the login info for end users to LoginUserNationalID list ...
            LoadLoginUserNationalIDFromFile();
            //to load the login info for admin to LoginAdminNationalID list ...
            LoadLoginAdminNationalIDFromFile();
            //to keep the system runs until user choose to closed the system ...
            bool MainRun = true;//to stop main method ...
            while (MainRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. Sing in");
                Console.WriteLine("2. Log in");
                Console.WriteLine("0. Log out");
                //to call CharValidation to get and validate user input ...
                char MainOption = CharValidation("option");
                //to run the option user want ...
                switch (MainOption)
                {
                    case '1'://to call SingIn method ...
                        SingIn();
                        break;

                    case '2'://to call LogIn method ...
                        LogIn();
                        break;

                    case '0'://to log out Main ...
                        //to save end user data to the file ...
                        SaveAccountsInformationToFile();
                        //to save reviews details to the file ...
                        SaveReviews();
                        //to save requests account opening to the file ...
                        SaveRequestAccountOpening();
                        //to save login info for end user to the file ...
                        SaveLoginUserNationalIDToFile();
                        //to save login info for admin to the file ...
                        SaveLoginAdminNationalIDToFile();
                        Console.WriteLine("Have a nice day (^0^)");
                        MainRun = false;//to stop the while loop ...
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        HoldScreen();//to hold the screen ...
                        break;
                }
                
            }

        }

        //============================== 3. EndUser menu =======================
        public static void EndUserMenu(string nationalId)
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
                        ReguestAccountOpening(nationalId);
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
        public static void AdmainMenu(string nationalId)
        {
            //to keep the AdmainMenu method runs until user choose to closed it ...
            bool AdmainMenuRun = true;//to stop the AdmainMenu method ...
            while (AdmainMenuRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. View requests");
                Console.WriteLine("2. Approve reguests accounts opening");
                Console.WriteLine("3. View opinging accounts in the system");
                Console.WriteLine("4. View all review in the system");
                Console.WriteLine("5. Add new admin");
                Console.WriteLine("6. Delete Account");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                char AdmainMenuRunOption = CharValidation("option");
                //to run the option user want ...
                switch (AdmainMenuRunOption)
                {
                    case '1'://to call ViewRequests method ...
                        ViewRequests();
                        break;

                    case '2'://to call ViewReguestsAccountsOpening method ...
                        ApproveReguestsAccountsOpening();
                        break;

                    case '3'://to call ViewOpingingAccounts method ...
                        ViewOpingingAccounts();
                        break;

                    case '4'://to call ViewAllReview method ...
                        ViewAllReview();
                        break;

                    case '5'://to call AddNewAdmin method ...
                        AddNewAdmin();
                        break;

                    case '6'://to call DeleteAccount method ...
                        DeleteAccount();
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
        public static void ReguestAccountOpening(string nationalID_user)
        {
            //to get the input from the user ...
            string UserName = StringNamingValidation("name");//to get and validate UserName input ...
            //string UserNationalID = StringValidation("national ID");//to get and validate UserNationalID input ...
            string UserNationalID = nationalID_user;
            bool NationalIDIsExist = CheckDuplicateAccountRequests(UserNationalID);
            if (NationalIDIsExist)
            {
                Console.WriteLine("Sorry ... there is request submited with this national id!");
                HoldScreen();//just to hold a second ...
                return;//to stop the method ...
            }
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
        public static void DepositeMoney()//to put money to your account ...
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to do the process of deposite money ...
                double DepositeMoney = DoubleValidation("money amount to deposite");
                //get account money amount using check balance ... do it after login ...
                //to get money amount in the account ... it will be in the balance leater ...
                double AccountMoney = 0;
                int index = 0;
                for(int i = 0; i < accountNumbers.Count; i++)
                {
                    if (accountNumbers[i] == AccountNumber)
                    {
                        AccountMoney = balances[i];
                        index = i;
                        break;//to stop the loop and save the time ...
                    }
                }
                double Deposite = AccountMoney + DepositeMoney;
                balances[index] = Deposite;
                Console.WriteLine($"Your deposite process done successfully.\n" +
                                  $"Your new balance is: {Deposite}");
                HoldScreen();//just to hold the screen ...
            }
        }
        //5.3. Withdraw money ...
        public static void WithdrawMoney()
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to do the process of withdraw money ...
                double WithdrawMoney = DoubleValidation("money amount to deposite");
                //get account money amount using check balance ... do it after login ...
                //to get money amount in the account ... it will be in the balance leater ...
                double AccountMoney = 0;
                int index = 0;
                for (int i = 0; i < accountNumbers.Count; i++)
                {
                    if (accountNumbers[i] == AccountNumber)
                    {
                        AccountMoney = balances[i];
                        index = i;
                        break;//to stop the loop and save the time ...
                    }
                }
                double Withdraw = AccountMoney - WithdrawMoney;
                bool IsValid = CheckBalanceEqualsMinimumBalance(Withdraw);
                if (!IsValid)
                {
                    Console.WriteLine("Sorry your withdraw process is not complete");
                    HoldScreen();//just to hold the screen ...
                }
                else
                {
                    balances[index] = Withdraw;
                    Console.WriteLine($"Your withdraw process done successfully.\n" +
                                      $"Your new balance is: {Withdraw}");
                    HoldScreen();//just to hold the screen ...
                }
            }
        }//to take money from your account ...
        //5.4. Check balance ...
        public static void CheckBalance()
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            { 
                for(int i = 0; i < accountNumbers.Count; i++)
                {
                    if(AccountNumber == accountNumbers[i])
                    {
                        Console.WriteLine($"Your account balance is: {balances[i]}");
                        HoldScreen();
                        return;//to stop the method ...
                    }
                }
            }
            }//to know how much in your account ...
        //5.5. Submit review ...
        public static void SubmitReview()
        {
            //to get the review input from the user ...
            string review = StringValidation("review");//to validate the review ...
            //to store the review in the reviewsStack ...
            reviewsStack.Push(review);
            Console.WriteLine("Your review submited successfully");
            HoldScreen();//to hold the screen ...
        }//to submit message with what you like and what not to the admin ...

        //============================ 6. Admain use case =======================
        //6.1. Process requests ...
        public static void ViewRequests()
        {
            //to check if there are request or not ...
            if (createAccountRequests.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to display all the request submited ...
            foreach (string request in createAccountRequests)
            {
                Console.WriteLine($"{request}");
                Console.WriteLine("----------------------");
            }
            HoldScreen();//to hold the screen ...
        }
        //6.2. Approve reguests accounts opening ...
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
        //6.3. View opinging accounts ...
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
        //6.4. View all review ...
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
        //6.5. Add new admin ...
        public static void AddNewAdmin()
        {
            //to get NationalID from the admin ...
            string AdminNationalID;
            bool IsExist;
            do
            {
                IsExist = false;
                //to get and validate AdminNationalID input ...
                AdminNationalID = StringValidation("national ID");
                bool UserNationalIDIsExsit = NationalIDIsUnique(AdminNationalID, LoginAdminNationalID);
                if (!UserNationalIDIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to store the new UserNationalID to LoginUserNationalID list ...
            LoginAdminNationalID.Add(AdminNationalID);
            Console.WriteLine("Adding new admin process done successfully");
            HoldScreen();//just to hold a second ...
        }
        //6.6. Delete account ...
        public static void DeleteAccount()
        {
            //to call ViewOpingingAccounts ...
            ViewOpingingAccounts();
            //delete account process start here ...
            bool DeleteFlag;
            int AcountNumber;
            do
            {
                DeleteFlag = false;
                AcountNumber = IntValidation("account number you want to delete");
                bool AccountNoExist = CheckAccountNumberExist(AcountNumber);
                if (!AccountNoExist)
                {
                    Console.WriteLine("Sorry ... Account number you entered is not exist");
                    HoldScreen();//just to hold a second ...
                    DeleteFlag = true;
                }
            } while (DeleteFlag);
            //to get AcountNumber index ...
            int index = accountNumbers.IndexOf(AcountNumber);
            accountNumbers.Remove(AcountNumber);
            accountUserNames.Remove(accountUserNames[index]);
            nationalID.Remove(nationalID[index]);
            balances.Remove(balances[index]);
            Console.WriteLine($"Account number {AcountNumber} deleted successfully");
            HoldScreen();
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
                    Console.WriteLine($"{message} cannot be empty.");
                    HoldScreen();//just to hoad second ...
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
        //7.5. IntValidation method ...
        public static int IntValidation(string message)
        {
            bool IntFlag;//to handle user StringNaming error input ...
            int IntInput = 0;
            do
            {
                IntFlag = false;
                try
                {
                    Console.WriteLine($"Enter {message}:");
                    IntInput = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to " + e.Message);
                    HoldScreen();//just to hold a second ...
                    IntFlag = true;
                }

            } while (IntFlag);
            //to return tne char input ...
            return IntInput;
        }
        //7.6. Check if balance == MinimumBalance ...
        public static bool CheckBalanceEqualsMinimumBalance(double value)
        {
            bool IsValide;
            if (value < MinimumBalance)
            {
                IsValide = false;
                Console.WriteLine($"Your {value} amount is lass then minimum balance: {MinimumBalance}");
                HoldScreen();//to hold the screen ...

            }
            else
            {
                IsValide = true;
            }
            return IsValide;
        }
        //7.7. Check if the account number exist or not ...
        public static bool CheckAccountNumberExist(int accountNum)
        {
            bool result = false;
            for(int i = 0; i < accountNumbers.Count; i++)
            {
                if (accountNumbers[i] == accountNum)
                {
                    result = true;
                    break;//to step the loop and save the time ...
                }
            }
            return result;
        }
        //7.8. Check if the NationalID unique or not ...
        public static bool NationalIDIsUnique(string id, List<string> list)
        {
            bool IsUnique = true;//it is unique (not exsit in the system) ...
            //to check if NationalID is exist or not (NationalID should be unique) ...
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i])
                {
                    Console.WriteLine("National ID is exist in the system.");
                    HoldScreen();//just to hoad second ...
                    IsUnique = false;
                    break; //to stop the loop ...
                }
            }

            //to return if exist or not ... 
            return IsUnique;
        }
        //7.9. Check  Duplicate Account Requests ...
        public static bool CheckDuplicateAccountRequests(string id)
        {
            bool result = false;
            foreach(string request in createAccountRequests)
            {
                string[] RequestDteials = request.Split('|').ToArray();
                if(id == RequestDteials[1])
                {
                    result = true;
                    break;
                }  
            }
            return result;
        }
        //============================ 8. Addtional methods ======================
        //8.1. Sing in method (just to sing in the end users) ...
        public static void SingIn()
        {
            //to get NationalID from the user ...
            string UserNationalID;
            bool IsExist;
            do
            {
                IsExist = false;
                //to get and validate UserNationalID input ...
                UserNationalID = StringValidation("national ID");
                bool UserNationalIDIsExsit = NationalIDIsUnique(UserNationalID, LoginUserNationalID);
                if (!UserNationalIDIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to store the new UserNationalID to LoginUserNationalID list ...
            LoginUserNationalID.Add(UserNationalID);
            Console.WriteLine("Your sing in process done successfully");
            HoldScreen();//just to hold a second ...

        }
        //8.2. Log in method ...
        public static void LogIn()
        {
            //to get NationalID from the user ...
            string UserNationalID;
            //to get and validate UserNationalID input ...
            UserNationalID = StringValidation("national ID");
            if (!NationalIDIsUnique(UserNationalID, LoginUserNationalID))
            {
                //to call EndUserMenu method ...
                EndUserMenu(UserNationalID);
            }
            else if (!NationalIDIsUnique(UserNationalID, LoginAdminNationalID))
            {
                //to call AdmainMenu method ...
                AdmainMenu(UserNationalID);
            }
            else
            {
                Console.WriteLine("Sorry ... this national id is " +
                                  "not a sing in the system.");
                HoldScreen();
            }
        }
        //8.3. WelcomeMessage method ...
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Codeline Bank System\nWe hope you have a pleasant time using our services " +
                              "(^0^)");
            HoldScreen();//to hold the screen ...
        }
        //8.4. To check of the string contains something other than letters like number and empty space(this methos return true or false)....
        static bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
        //8.5. ConfirmAction method ...
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
        //8.6. To hoad the screen ...
        public static void HoldScreen()
        {
            Console.WriteLine("Press (Enter Kay) to continue");
            Console.ReadLine();
        }
        //8.7. SaveAccountsInformationToFile method ..
        public static void SaveAccountsInformationToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(AccountsFilePath))
                {
                    for (int i = 0; i < accountNumbers.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{accountNumbers[i]},{accountUserNames[i]}," +
                                          $"{nationalID[i]},{balances[i]}";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine("Accounts saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving accounts data into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.8. SaveReviews method ...
        public static void SaveReviews()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(ReviewsFilePath))
                {
                    foreach (var review in reviewsStack)
                    {
                        writer.WriteLine(review);
                    }
                }
                Console.WriteLine("Reviews saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving reviews.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.9. SaveRequestAccountOpening method ...
        public static void SaveRequestAccountOpening()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(RequestsFilePath))
                {
                    foreach (var request in createAccountRequests)
                    {
                        writer.WriteLine(request);
                    }
                }
                Console.WriteLine("Request account saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving request account.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.10. SaveLoginUserNationalIDToFile method ...
        public static void SaveLoginUserNationalIDToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(EndUsersFilePath))
                {
                    for (int i = 0; i < LoginUserNationalID.Count; i++)
                    {
                        writer.WriteLine(LoginUserNationalID[i]);
                    }
                }
                Console.WriteLine("Login info for end users saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving Login info for end users into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.11. SaveLoginAdminNationalIDToFile method ...
        public static void SaveLoginAdminNationalIDToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(AdminsFilePath))
                {
                    for (int i = 0; i < LoginAdminNationalID.Count; i++)
                    {
                        writer.WriteLine(LoginAdminNationalID[i]);
                    }
                }
                Console.WriteLine("Login info for admin saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving Login info for admin into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.12. LoadAccountsInformationFromFile method ...
        public static void LoadAccountsInformationFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(AccountsFilePath))
                {
                    Console.WriteLine("Sorry ... no saved data found in accounts.txt file.");
                    HoldScreen();//to hold a second ...
                    return;//to stop the method ...
                }
                //to make sure that our lists are clear ...
                accountNumbers.Clear();
                accountUserNames.Clear();
                nationalID.Clear();
                balances.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(AccountsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int accNum = Convert.ToInt32(parts[0]);//to convert from string to int ...
                        //to add the information to the lists ...
                        accountNumbers.Add(accNum);
                        accountUserNames.Add(parts[1]);
                        nationalID.Add(parts[2]);
                        balances.Add(Convert.ToDouble(parts[3]));

                        if (accNum > LastAccountNumber)
                            LastAccountNumber = accNum;
                    }
                }
                Console.WriteLine("Accounts loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading file.");
                HoldScreen();
            }
        }
        //8.13. LoadReviews method ...
        public static void LoadReviews()
        {
            try
            {
                if (!File.Exists(ReviewsFilePath)) return;
                //to store file data temperey and then
                //store data in the right order in the createAccountRequests
                Stack<string> TempStoreReview = new Stack<string>();
                using (StreamReader reader = new StreamReader(ReviewsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        TempStoreReview.Push(line);
                    }
                }
                //to clear reviewsStack ...
                reviewsStack.Clear();
                //loop to store request from TempStore to createAccountRequests
                //in the right order
                foreach (string review in TempStoreReview)
                {
                    reviewsStack.Push(review);
                }
                Console.WriteLine("Review loaded successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error loading reviews.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.14. LoadSaveRequestAccountOpening method ...
        public static void LoadSaveRequestAccountOpening()
        {
            try
            {
                if (!File.Exists(RequestsFilePath)) return;
                //to store file data temperey and then
                //store data in the right order in the createAccountRequests
                //Queue<string> TempStoreRequests = new Queue<string>();
                using (StreamReader reader = new StreamReader(RequestsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //TempStoreRequests.Enqueue(line);
                        createAccountRequests.Enqueue(line);
                    }
                }
                //to clear createAccountRequests ...
                //createAccountRequests.Clear();
                //loop to store request from TempStore to createAccountRequests
                //in the right order
                //foreach (string request in TempStoreRequests)
                //{
                //    createAccountRequests.Enqueue(request);
                //}
                Console.WriteLine("Requests accounts opening loaded successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error loading reviews.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.15. LoadLoginUserNationalIDFromFile method ...
        public static void LoadLoginUserNationalIDFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(EndUsersFilePath))
                {
                    Console.WriteLine("Sorry ... no saved data found in users.txt file.");
                    HoldScreen();//to hold a second ...
                    return;//to stop the method ...
                }
                //to make sure that LoginUserNationalID list is clear ...
                LoginUserNationalID.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(EndUsersFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        LoginUserNationalID.Add(line);
                    }
                }
                Console.WriteLine("Login info for end users loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading file.");
                HoldScreen();
            }
        }
        //8.16. LoadLoginAdminNationalIDFromFile method ...
        public static void LoadLoginAdminNationalIDFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(AdminsFilePath))
                {
                    Console.WriteLine("Sorry ... no saved data found in admin.txt file.");
                    HoldScreen();//to hold a second ...
                    return;//to stop the method ...
                }
                //to make sure that LoginUserNationalID list is clear ...
                LoginAdminNationalID.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(AdminsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        LoginAdminNationalID.Add(line);
                    }
                }
                Console.WriteLine("Login info for admin loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading file.");
                HoldScreen();
            }
        }


    }
}
