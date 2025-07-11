﻿using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;//to deal with list, stack and queue ...
using System.IO;//to import Input output backage to deal with files ...
//20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
using System.Security.Cryptography;
using System.Text;

namespace MiniProjectBankSystem
{
    internal class Program
    {
        //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
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
        static List<string> accountPhoneNumbers = new List<string>();
        static List<string> accountAddresses = new List<string>();
        //1.5. reviewsStack stack ...
        static Stack<string> reviewsStack = new Stack<string>();
        static List<string> reviewsNationalID = new List<string>();
        //1.6. AccountsFilePath to store accounts.txt path
        //where we will store account information 
        const string AccountsFilePath = "accounts.txt";
        //1.7. ReviewsFilePath to store reviews.txt path
        //where we will store review details 
        const string ReviewsFilePath = "reviews.txt";
        //1.8. ReviewsNationalIDFilePath to store reviewsNationalId.txt path
        //where we will store review national id 
        const string ReviewsNationalIDFilePath = "reviewsNationalId.txt";
        //1.9. RequestsFilePath to store requests.txt path
        //where we will store request details 
        const string RequestsFilePath = "requests.txt";
        //1.10. EndUsersFilePath to store users.txt path
        //where we will store users info 
        const string EndUsersFilePath = "users.txt";
        //1.11. AdminsFilePath to store admin.txt path
        //where we will store admin info 
        const string AdminsFilePath = "admin.txt";
        //1.12. LoginUserNationalID list to store users NationalID
        static List<string> LoginUserNationalID = new List<string>();
        //1.13. LoginAdminNationalID list to store admin NationalID
        static List<string> LoginAdminNationalID = new List<string>();
        //1.14. LoginUserPassword list to store user password
        static List<string> LoginUserPassword = new List<string>();
        //1.15. LoginAdminPassword list to store admin password
        static List<string> LoginAdminPassword = new List<string>();
        //1.16. LockedAccounts list to store locked accounts
        static List<string> LockedAccounts = new List<string>();
        //1.17. LockedAccountsFilePath to store lockedAccounts.txt path
        const string LockedAccountsFilePath = "lockedAccounts.txt";
        //1.18. lists to store Transaction data (parallel)
        static List<string> transactionAccountNumbers = new List<string>();
        static List<string> transactionType = new List<string>();
        static List<string> transactionAmount = new List<string>();
        static List<string> BalanceAfterTransaction = new List<string>();
        static List<string> transactionDate = new List<string>();
        //1.19. TransactionFilePath to store transactions.txt path
        const string TransactionFilePath = "transactions.txt";
        //1.20. Statement list to store monthly statement data (parallel)
        static List<string> statement = new List<string>();
        //1.21. to store ratings in Ratings list ...
        static List<int> Ratings = new List<int>();
        //1.22. RatingsFilePath to store ratings.txt path
        const string RatingsFilePath = "ratings.txt";
        //1.23. USD value (1 USD = 3.8 OMR)
        const double USD = 3.8;
        //1.24. EUR value (1EUR = 0.45 OMR)
        const double EUR = 0.45;
        //1.25. to store active loan in a list ...
        static List<string> activeLoans = new List<string>();
        //1.26. to store loan amount in a list ...
        static List<double> loanAmounts = new List<double>();
        //1.27. to store loan interest in a list ...
        static List<double> loanInterest = new List<double>();
        //1.28. to store RequestLaon in RequestLaon queue ...
        static Queue<string> RequestLoanQueue = new Queue<string>();
        //2.29. RequestLaonFilePath to store RequestLoan.txt path
        const string RequestLoanFilePath = "RequestLoan.txt";
        //2.30. ActiveLoansFilePath to store ActiveLoans.txt path
        const string ActiveLoansFilePath = "ActiveLoans.txt";
        //2.31. to store ActiveConsultation to list ...
        static List<string> ActiveConsultation = new List<string>();
        //2.32. to store RequestConsultation to queue ...
        static Queue<string> RequestConsultation = new Queue<string>();
        //2.33. RequestConsultationFilePath to store RequestConsultation.txt path
        const string RequestConsultationFilePath = "RequestConsultation.txt";
        //2.34. to store ConsultationDate to list ...
        static List<string> ConsultationDate = new List<string>();
        //2.35. ActiveConsultationFilePath to store ActiveConsultation.txt path
        const string ActiveConsultationFilePath = "ActiveConsultation.txt";

        //============================== 2. Main method ========================
        static void Main(string[] args)
        {
            //to call WelcomeMessage method ...
            WelcomeMessage();
            //to load the accounts information from the file and store it into the lists ...
            LoadAccountsInformationFromFile();
            //to load the review details from the file and store it into the stack ...
            LoadReviews();
            //to load the review national id from the file and store it into the list ...
            LoadReviewsNationalId();
            //to load the request account opening
            //details from the file and store it into the queue ...
            LoadSaveRequestAccountOpening();
            //to load the login info for end users to LoginUserNationalID and LoginUserPassword list...
            LoadLoginUserFromFile();
            //to load the login info for admin to LoginAdminNationalID list ...
            LoadLoginAdminFromFile();
            //to load the locked accounts to LockedAccounts list ...
            LoadLockedAccounts();
            //to load the transaction details from the file and store it into the lists ...
            LoadTransactionsFromFile();
            //to load the ratings from the file and store it into the Ratings list ...
            LoadRatingsFromFile();
            //to load the RequestLoan from the file and store it into the RequestLoanQueue ...
            LoadRequestLoanFromFile();
            //to load the active loans from the file and store it into the activeLoans list ...
            LoadActiveLoansFromFile();
            //to load the RequestConsultation from the file and store it into the RequestConsultation queue ...
            LoadRequestConsultationFromFile();
            //to load the active consultation from the file and store it into the ActiveConsultation list ...
            LoadActiveConsultationFromFile();
            //to keep the system runs until user choose to closed the system ...
            bool MainRun = true;//to stop main method ...
            while (MainRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. Sing up");
                Console.WriteLine("2. Log in");
                Console.WriteLine("0. Log out");
                //to call CharValidation to get and validate user input ...
                char MainOption = CharValidation("option");
                //to run the option user want ...
                switch (MainOption)
                {
                    case '1'://to call SingIn method ...
                        SingUp();
                        break;

                    case '2'://to call LogIn method ...
                        LogIn();
                        break;

                    case '0'://to log out Main ...
                        //to save end user data to the file ...
                        SaveAccountsInformationToFile();
                        //to save reviews details to the file ...
                        SaveReviews();
                        //to save reviews national id to the file ...
                        SaveReviewsNationalId();
                        //to save requests account opening to the file ...
                        SaveRequestAccountOpening();
                        //to save login info for end user to the file ...
                        SaveLoginUserToFile();
                        //to save login info for admin to the file ...
                        SaveLoginAdminToFile();
                        //to save locked accounts to the file ...
                        SaveLockedAccounts();
                        //to save transaction details to the file ...
                        SaveTransactionsToFile();
                        //to save ratings to the file ...
                        SaveRatingsToFile();
                        //to save RequestLoan to the file ...
                        SaveRequestLoanToFile();
                        //to save active loans to the file ...
                        SaveActiveLoansToFile();
                        //to save RequestConsultation to the file ...
                        SaveRequestConsultationToFile();
                        //to save active consultation to the file ...
                        SaveActiveConsultationToFile();
                        //to generate backup file for the system ...
                        GenerateDataBackupForTheSystem();
                        //to display exit message ...
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
                Console.WriteLine("6. Transfer money between accounts");
                Console.WriteLine("7. Undo last complaint submitted");
                Console.WriteLine("8. Update Account Information");
                Console.WriteLine("9. Print All Account Transactions");
                Console.WriteLine("10. Show Last N Transactions");
                Console.WriteLine("11. Show Transactions After Date X");
                Console.WriteLine("12. Monthly Statement Generator");
                Console.WriteLine("13. Booking Bank Services");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                string EndUserMenuOption = StringValidation("option");
                //to run the option user want ...
                switch (EndUserMenuOption)
                {
                    case "1"://to call ReguestAccountOpening method ...
                        ReguestAccountOpening(nationalId);
                        break;

                    case "2"://to call DepositeMoney method ...
                        DepositeMoney();
                        break;

                    case "3"://to call WithdrawMoney method ...
                        WithdrawMoney();
                        break;

                    case "4"://to call CheckBalance method ...
                        CheckBalance();
                        break;

                    case "5"://to call SubmitReview method ...
                        SubmitReview(nationalId);
                        break;

                    case "6"://to call TransferBetweenAccounts method ...
                        TransferBetweenAccounts();
                        break;

                    case "7"://to call UndoLastComplaintSubmitted method ...
                        UndoLastComplaintSubmitted(nationalId);
                        break;

                    case "8"://to call UpdateAccountInfo method ...
                        UpdateAccountInfo(nationalId);
                        break;

                    case "9": //to call PrintAllAccountTransactions method ...
                        PrintAllAccountTransactions();
                        break;

                    case "10": //to call ShowLastNTransactions method ..
                        ShowLastNTransactions();
                        break;

                    case "11": //to call ShowTransactionsAfterDateX method ..
                        ShowTransactionsAfterDateX();
                        break;

                    case "12": //to call MonthlyStatementGenerator method ..
                        MonthlyStatementGenerator();
                        break;

                    case "13"://to call BookingBankServices method ...
                        BookingBankServices(nationalId);
                        break;

                    case "0"://to exsit EndUserMenu ...
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
                Console.WriteLine("7. Search for account");
                Console.WriteLine("8. Show total bank balance");
                Console.WriteLine("9. Show Top 3 Richest Customers");
                Console.WriteLine("10. Export All Account Info to a New File");
                Console.WriteLine("11. Unlock Locked Accounts");
                Console.WriteLine("12. Print All Transactions");
                Console.WriteLine("13. View Average Feedback Score");
                Console.WriteLine("14. Approve reguests for loan");
                Console.WriteLine("15. Approve reguests for account consultation");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                string AdmainMenuRunOption = StringValidation("option");
                //to run the option user want ...
                switch (AdmainMenuRunOption)
                {
                    case "1"://to call ViewRequests method ...
                        ViewRequests();
                        break;

                    case "2"://to call ViewReguestsAccountsOpening method ...
                        ApproveReguestsAccountsOpening();
                        break;

                    case "3"://to call ViewOpingingAccounts method ...
                        ViewOpingingAccounts();
                        break;

                    case "4"://to call ViewAllReview method ...
                        ViewAllReview();
                        break;

                    case "5"://to call AddNewAdmin method ...
                        AddNewAdmin();
                        break;

                    case "6"://to call DeleteAccount method ...
                        DeleteAccount();
                        break;

                    case "7"://to call SearchAccount method ...
                        SearchAccount();
                        break;

                    case "8"://to call ShowTotalBankBalance method ...
                        ShowTotalBankBalance();
                        break;

                    case "9"://to call ShowTop3RichestCustomers method ...
                        ShowTop3RichestCustomers();
                        break;

                    case "10"://to call ExportAllAccountInfoToNewFile method ...
                        ExportAllAccountInfoToNewFile();
                        break;

                    case "11"://to call UnlockLockedAccounts method ...
                        UnlockLockedAccounts();
                        break;

                    case "12"://to call PrintAllTransactions method ...
                        PrintAllTransactions();
                        break;

                    case "13"://to call ViewAverageFeedbackScore method ...
                        ViewAverageFeedbackScore();
                        break;

                    case "14"://to call ApproveReguestsForLoan method ...
                        ApproveReguestsForLoan();
                        break;

                    case "15"://to call ApproveReguestsForAccountConsultation method ...
                        ApproveReguestsForAccountConsultation();
                        break;

                    case "0"://to exsit AdmainMenuRun ...
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
            //to get and validate UserNationalID input ...
            string UserNationalID = nationalID_user;
            bool NationalIDIsExist = CheckDuplicateAccountRequests(UserNationalID);
            if (NationalIDIsExist)
            {
                Console.WriteLine("Sorry ... there is request submited with this national id!");
                HoldScreen();//just to hold a second ...
                return;//to stop the method ...
            }
            //to get and validate InitialBalance input ...
            bool BalanceIsValide;
            double InitialBalance;
            do
            {
                InitialBalance = DoubleValidation("initial balance");//to get and validate InitialBalance input ...
                BalanceIsValide = CheckBalanceEqualsMinimumBalance(InitialBalance);//to check if InitialBalance > MinimumBalance or not ...
            } while (!BalanceIsValide);
            //to get and validate UserPhoneNumber input ...
            string UserPhoneNumber;
            bool PhoneNumberIsExist = false;
            do
            {
                UserPhoneNumber = GetAndCheckPhoneNumberIsValid("phone number");
                //to check if the phone number is exist in the accountPhoneNumbers list or not ...
                PhoneNumberIsExist = PhoneNumberIsUnique(UserPhoneNumber, accountPhoneNumbers);
            } while (!PhoneNumberIsExist);
            //to get and validate UserAddress input ...
            string UserAddress = StringValidation("address");//to get and validate UserAddress input ...

            //to combain all the input together and store it in createAccountRequests queue ...
            string request = UserName + "|" + UserNationalID + "|" + InitialBalance + "|" + UserPhoneNumber + "|" + UserAddress;
            createAccountRequests.Enqueue(request);
            int num = createAccountRequests.Count();
            Console.WriteLine("Your request submited successfully");
            Console.WriteLine("Their is " + num + " request");
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
                //to get currencies (OMR,USD, EUR) from the user ...
                char currency;
                Console.WriteLine("Available currencies:");
                Console.WriteLine("1. OMR");
                Console.WriteLine("2. USD");
                Console.WriteLine("3. EUR");
                //to call CharValidation to get and validate user input ...
                currency = CharValidation("currency (1,2,3)");
                //to deposite money in the account based on the currency selected by the user ...
                switch (currency)
                {
                    case '1': //to deposite OMR ...
                        ToGetDepositeMoney(1, AccountNumber, "Deposite (OMR)");
                        break;
                    case '2': //to deposite USD ...
                        ToGetDepositeMoney(USD, AccountNumber, "Deposite (USD)");
                        break;
                    case '3': //to deposite EUR ...
                        ToGetDepositeMoney(EUR, AccountNumber, "Deposite (EUR)");
                        break;
                    default:
                        Console.WriteLine("Invalid currency choice.");
                        HoldScreen();//to hold the screen ...
                        break;
                }
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
                    //to store the transaction details in the lists ...
                    StoreTransactions(AccountNumber.ToString(), "Withdraw", WithdrawMoney.ToString(),
                                      Withdraw.ToString());
                    //to get user rate on service ...
                    RateService("withdraw");
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
                for (int i = 0; i < accountNumbers.Count; i++)
                {
                    if (AccountNumber == accountNumbers[i])
                    {
                        Console.WriteLine($"Your account balance is: {balances[i]}");
                        HoldScreen();
                        return;//to stop the method ...
                    }
                }
            }
        }//to know how much in your account ...
        //5.5. Submit review ...
        public static void SubmitReview(string id)
        {
            //to get the review input from the user ...
            string review = StringValidation("review");//to validate the review ...
            //to store the review in the reviewsStack ...
            reviewsStack.Push(review);
            //to store the review national id in the reviewsNationalID ...
            reviewsNationalID.Add(id);
            Console.WriteLine("Your review submited successfully");
            HoldScreen();//to hold the screen ...
        }//to submit message with what you like and what not to the admin ...
        //5.6. Transfer money between accounts ...
        public static void TransferBetweenAccounts()
        {
            //to enter ToAccountNumber from the user ...
            int ToAccountNumber;
            ToAccountNumber = IntValidation("account number you want to send money to");
            //to check if the account exist ...
            bool ToAccountNumberIsExist = CheckAccountNumberExist(ToAccountNumber);
            if (!ToAccountNumberIsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            //to enter the user account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("your account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry your account number is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to do the process of transfer money ...
                double TransferMoney = DoubleValidation("money amount to transfer");
                //get account money amount using check balance ... do it after login ...
                //to get money amount in the account ... it will be in the balance leater ...
                double AccountMoney = 0;
                int index = 0;
                //to get accountNumber index ...
                for (int i = 0; i < accountNumbers.Count; i++)
                {
                    if (accountNumbers[i] == AccountNumber)
                    {
                        AccountMoney = balances[i];
                        index = i;
                        break;//to stop the loop and save the time ...
                    }
                }
                double Transfer = AccountMoney - TransferMoney;
                bool IsValid = CheckBalanceEqualsMinimumBalance(Transfer);
                if (!IsValid)
                {
                    Console.WriteLine("Sorry your transfer process is not complete");
                    HoldScreen();//just to hold the screen ...
                }
                else
                {
                    balances[index] = Transfer;
                    //to get the ToAccountNumber index ...
                    int ToAccountNumberIndex = Array.IndexOf(accountNumbers.ToArray(), ToAccountNumber);
                    //to add the TransferMoney to the ToAccountNumber index ...
                    balances[ToAccountNumberIndex] += TransferMoney;
                    Console.WriteLine($"Your transfer process done successfully.\n" +
                                      $"Your new balance is: {Transfer}");
                    //to store the transaction details in the lists ...
                    StoreTransactions(AccountNumber.ToString(), "TransferTo", TransferMoney.ToString(),
                                          Transfer.ToString());
                    StoreTransactions(ToAccountNumber.ToString(), "TransferFrom", TransferMoney.ToString(),
                                          balances[ToAccountNumberIndex].ToString());
                    //to get user rate on service ...
                    RateService("transfer between accounts");
                }
            }
        }
        //5.7. Undo last complaint submitted ...
        public static void UndoLastComplaintSubmitted(string id)
        {
            //to check if there is review submited or not ...
            if (reviewsStack.Count == 0)
            {
                Console.WriteLine("There is no review submited yet");
                //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to store reviews in a list ...
            List<string> reviews = new List<string>(reviewsStack);
            reviews.Reverse();
            //to find the last review submited by the user using his national id ...
            for (int i = reviewsNationalID.Count - 1; i >= 0; i--)
            {
                if (reviewsNationalID[i] == id)
                {
                    //to display the last review submited by the user ...
                    Console.WriteLine($"Your last review submited is: {reviews[i]}");
                    //to confirm the user action to remove the review ...
                    bool action = ConfirmAction("remove this review");
                    if (action)
                    {
                        //to remove the review from the list of review ...
                        reviews.Remove(reviews[i]);
                        //to remove the national id from the list ...
                        reviewsNationalID.RemoveAt(i);
                        //to clear the reviewsStack ...
                        reviewsStack.Clear();
                        //to push the reviews to the reviewsStack ...
                        foreach (string review in reviews)
                        {
                            reviewsStack.Push(review);
                        }
                        Console.WriteLine("Your last complaint submitted is removed successfully");
                        HoldScreen();//to hold the screen ...
                        return;//to stop the method ...
                    }
                    else
                    {
                        Console.WriteLine("Your last complaint submitted is not removed");
                        HoldScreen();//to hold the screen ...
                        return;//to stop the method ...
                    }

                }
            }
        }
        //5.8. Update Account Info ...
        public static void UpdateAccountInfo(string id)
        {
            //to check if the national id exist ...
            bool IsExist = NationalIDIsUnique(id, nationalID);
            if (IsExist)
            {
                Console.WriteLine("Sorry the national id you entered is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to get user index ...
                int index = nationalID.IndexOf(id);
                //to display user info ...
                Console.WriteLine("Your account info:");
                Console.WriteLine($"User Name: {accountUserNames[index]}\n" +
                                  $"User Phone Number: {accountPhoneNumbers[index]}\n" +
                                  $"User Address:{accountAddresses[index]}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Please enter the new info:");
                //to get the new user name from the user ...
                string NewUserName = StringNamingValidation("new user name");
                //to get the new phone number from the user ...
                string NewPhoneNumber = GetAndCheckPhoneNumberIsValid("new phone number");
                //to get the new address from the user ...
                string NewAddress = StringValidation("new address");
                //to confirm user action ...
                bool action = ConfirmAction("update your account info");
                if (action)
                {
                    //to update the account info in the lists ...
                    accountUserNames[index] = NewUserName;
                    accountPhoneNumbers[index] = NewPhoneNumber;
                    accountAddresses[index] = NewAddress;
                    Console.WriteLine("Your account info updated successfully");
                    HoldScreen();//just to hold a second ...
                }
            }
        }
        //5.9.  PrintAllAccountTransactions method ...
        public static void PrintAllAccountTransactions()
        {
            if (transactionAccountNumbers.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                HoldScreen();//just to hold second ...
                return;
            }
            //to enter the user account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("your account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry your account number is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                Console.WriteLine("All Transactions Founded For Your Account Number:");
                Console.WriteLine("Account Number \t\t Type \t\t Amount \t\t Balance After Transaction \t\t Date");
                for (int i = 0; i < transactionAccountNumbers.Count; i++)
                {
                    if (transactionAccountNumbers[i] == AccountNumber.ToString())
                    {
                        Console.WriteLine($"{transactionAccountNumbers[i]} \t\t" +
                                    $"{transactionType[i]} \t\t" +
                                    $"{transactionAmount[i]}\t\t" +
                                    $"{BalanceAfterTransaction[i]} \t\t" +
                                    $"{transactionDate[i]}");
                        Console.WriteLine("--------------------------------------------------");
                    }


                }
                HoldScreen();//just to hold second ...}

            }
        }
        //5.10. ShowLastNTransactions method ...
        public static void ShowLastNTransactions()
        {
            if (transactionAccountNumbers.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                HoldScreen();//just to hold second ...
                return;
            }
            //to get N (number of transction to be display) ...
            int N = IntValidation("number of transction you want to see");
            int counter = 0;
            //to get the user account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("your account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry your account number is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                Console.WriteLine("All Transactions Founded For Your Account Number:");
                Console.WriteLine("Account Number \t\t Type \t\t Amount \t\t Balance After Transaction \t\t Date");
                for (int i = transactionAccountNumbers.Count - 1; i >= 0; i--)
                {
                    if (transactionAccountNumbers[i] == AccountNumber.ToString() && counter < N)
                    {
                        Console.WriteLine($"{transactionAccountNumbers[i]} \t\t" +
                                    $"{transactionType[i]} \t\t" +
                                    $"{transactionAmount[i]}\t\t" +
                                    $"{BalanceAfterTransaction[i]} \t\t" +
                                    $"{transactionDate[i]}");
                        Console.WriteLine("--------------------------------------------------");
                        counter++;
                    }


                }
                HoldScreen();//just to hold second ...}

            }
        }
        //5.11. ShowTransactionsAfterDateX method ...
        public static void ShowTransactionsAfterDateX()
        {
            if (transactionAccountNumbers.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                HoldScreen();//just to hold second ...
                return;
            }
            //to get X (Date to display all transction after it) ...
            DateTime X = DateTimeValidation("date");
            //to get the user account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("your account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry your account number is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to now if transction found or not ...
                bool NoTransctionFound = true;
                Console.WriteLine("All Transactions Founded For Your Account Number:");
                Console.WriteLine("Account Number \t\t Type \t\t Amount \t\t Balance After Transaction \t\t Date");
                for (int i = 0; i < transactionAccountNumbers.Count; i++)
                {
                    //to convert transactionDate[i] from string to DateTime dataType ...
                    DateTime transctionDate = DateTime.Parse(transactionDate[i]);
                    if (transactionAccountNumbers[i] == AccountNumber.ToString() && transctionDate > X)
                    {
                        NoTransctionFound = false;
                        Console.WriteLine($"{transactionAccountNumbers[i]} \t\t" +
                                    $"{transactionType[i]} \t\t" +
                                    $"{transactionAmount[i]}\t\t" +
                                    $"{BalanceAfterTransaction[i]} \t\t" +
                                    $"{transactionDate[i]}");
                        Console.WriteLine("--------------------------------------------------");
                    }


                }
                if (NoTransctionFound)
                {
                    Console.WriteLine("Their is no transction found after" + X);
                }
                HoldScreen();//just to hold second ...}

            }
        }
        //5.12. MonthlyStatementGenerator method ...
        public static void MonthlyStatementGenerator()
        {
            if (transactionAccountNumbers.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                HoldScreen();//just to hold second ...
                return;
            }
            //to get FromDate (Date to display all transction after it) ...
            DateTime FromDate = DateTimeValidation("from date");
            //to get ToDate (Date to display all transction before it) ...
            DateTime ToDate = DateTimeValidation("to date");
            //to get the user account number from the user ...
            int AccountNumber;
            AccountNumber = IntValidation("your account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry your account number is not exist!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to make sure Statement list is clear ...
                statement.Clear();
                //to store founded transactions in the statement list ...
                string dateLine = "null";
                //to now if transction found or not ...
                bool NoTransctionFound = true;
                Console.WriteLine("All Transactions Founded For Your Account Number:");
                Console.WriteLine("Account Number \t\t Type \t\t Amount \t\t Balance After Transaction \t\t Date");
                for (int i = 0; i < transactionAccountNumbers.Count; i++)
                {
                    //to convert transactionDate[i] from string to DateTime dataType ...
                    DateTime transctionDate = DateTime.Parse(transactionDate[i]);
                    if (transactionAccountNumbers[i] == AccountNumber.ToString() && transctionDate > FromDate && transctionDate < ToDate)
                    {
                        NoTransctionFound = false;
                        Console.WriteLine($"{transactionAccountNumbers[i]} \t\t" +
                                    $"{transactionType[i]} \t\t" +
                                    $"{transactionAmount[i]}\t\t" +
                                    $"{BalanceAfterTransaction[i]} \t\t" +
                                    $"{transactionDate[i]}");
                        Console.WriteLine("--------------------------------------------------");
                        //to combine the transaction details in dateLine variable ...
                        dateLine = $"{transactionAccountNumbers[i]},{transactionType[i]},{transactionAmount[i]}," +
                                    $"{BalanceAfterTransaction[i]},{transactionDate[i]}";
                    }
                    //to save transaction details stored in dateLine one by one in the statement list ...
                    statement.Add(dateLine);
                }
                if (NoTransctionFound)
                {
                    Console.WriteLine($"Their is no transction found between {FromDate} and {ToDate}");
                }
                else
                {
                    //to save the statement to a file ...
                    try
                    {
                        //we do not check if the file exist or not becouse 
                        //StreamWriter will create the file in the same path we put 
                        //if he do not found it 

                        //to create bath name ...
                        string fileName = $"Statement_{AccountNumber}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            for (int i = 0; i < statement.Count; i++)
                            {
                                writer.WriteLine(statement[i]);
                            }
                        }
                        Console.WriteLine("Monthly Statement Generated Successfully.");
                        HoldScreen();//just to hold second ...
                    }
                    catch
                    {
                        Console.WriteLine("Error in generating monthy statement into the file.");
                        HoldScreen();//just to hold second ...
                    }
                }
                HoldScreen();//just to hold second ...}

            }
        }
        //5.13 BookingBankServices method ...
        public static void BookingBankServices(string id)
        {
            char service;
            Console.WriteLine("Available Bank Services:");
            Console.WriteLine("1. Request a Loan");
            Console.WriteLine("2. Check Loan Status");
            Console.WriteLine("3. Account Consultation");
            Console.WriteLine("4. Check Account Consultation Status");
            //to get and validate user input ...
            service = CharValidation("service (1,2,3)");
            switch (service)
            {
                case '1': //to call RequestLoan method ...
                    RequestLoan(id);
                    break;
                case '2': //to call CheckLoanStatus method ...
                    //CheckLoanStatus(id);
                    break;
                case '3': //to call AccountConsultation method ...
                    AccountConsultation(id);
                    break;
                case '4': //to call CheckAccountConsultationStatus method ...
                    //CheckAccountConsultationStatus(id);
                    break;
                default:
                    Console.WriteLine("Invalid service choice.");
                    HoldScreen();//to hold the screen ...
                    break;
            }
        }

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
            if (createAccountRequests.Count == 0)
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
                              $"Initial Balance: {RequestDteials[2]}\n" +
                              $"User Phone Number: {RequestDteials[3]}\n" +
                              $"User Address:{RequestDteials[4]}");
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
                accountPhoneNumbers.Add(RequestDteials[3]);
                accountAddresses.Add(RequestDteials[4]);

                Console.WriteLine($"Account created successfully for: {RequestDteials[0]}\n" +
                    $" with Account Number: {newAccountNumber}");
                HoldScreen();//to hold the screen ...

            }

        }
        //6.3. View opinging accounts ...
        public static void ViewOpingingAccounts()
        {
            //to check if there is opened accounts or not ...
            if (accountNumbers.Count == 0)
            {
                Console.WriteLine("There is no opened accounts yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to display all opened accounts ...
            Console.WriteLine("Accounts information:");
            Console.WriteLine("Account No \t|\t User Name \t|\t National ID \t|\t Balance");
            for (int i = 0; i < accountNumbers.Count; i++)
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
            if (reviewsStack.Count == 0)
            {
                Console.WriteLine("There is no review submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
                //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
            }
            //to display all the review submited to the reviewsStack ...
            foreach (string review in reviewsStack)
            {
                Console.WriteLine($"{review}");
                Console.WriteLine("----------------------");
            }
            HoldScreen();//to hold the screen ...
        }
        //6.5. Add new admin ...
        public static void AddNewAdmin()
        {
            bool IsExist;
            //to get NationalID from the admin ...
            string AdminNationalID;
            do
            {
                IsExist = false;
                //to get and validate AdminNationalID input ...
                AdminNationalID = StringValidation("national ID");
                bool UserNationalIDIsExsit = NationalIDIsUnique(AdminNationalID, LoginUserNationalID);
                bool AdminNationalIDIsExsit = NationalIDIsUnique(AdminNationalID, LoginAdminNationalID);
                if (!UserNationalIDIsExsit || !AdminNationalIDIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to get password from the admin ...
            string AdminPassword;
            string AdminPasswordHashed;
            do
            {
                IsExist = false;
                //to get and validate UserPassword input ...
                AdminPassword = ReadPassword("Password");
                //to hash the password ...
                AdminPasswordHashed = HashPasswordPBKDF2(AdminPassword);
                bool UserPasswordIsExsit = PasswordIsUnique(AdminPasswordHashed, LoginUserPassword);
                bool AdminPasswordIsExsit = PasswordIsUnique(AdminPasswordHashed, LoginAdminPassword);
                if (!UserPasswordIsExsit || !UserPasswordIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to store the new UserNationalID to LoginUserNationalID list ...
            LoginAdminNationalID.Add(AdminNationalID);
            //to store admin password to LoginAdminPassword list ...
            LoginAdminPassword.Add(AdminPasswordHashed);
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
            bool ConfirmDelete = ConfirmAction("delete this account");
            if (ConfirmDelete)
            {
                //to get AcountNumber index ...
                int index = accountNumbers.IndexOf(AcountNumber);
                accountNumbers.Remove(AcountNumber);
                accountUserNames.Remove(accountUserNames[index]);
                nationalID.Remove(nationalID[index]);
                balances.Remove(balances[index]);
                Console.WriteLine($"Account number {AcountNumber} deleted successfully");
                HoldScreen();
            }
            else
            {
                Console.WriteLine("Delete process stoped");
                HoldScreen();//just to hold a second ...
            }

        }
        //6.7. Search for account ...
        public static void SearchAccount()
        {
            //to get the user selected option for search method ...
            char SerachOption;
            Console.WriteLine("1. Search by national ID");
            Console.WriteLine("2. Search by name");
            SerachOption = CharValidation("option");
            switch (SerachOption)
            {
                case '1':
                    SearchAccountByNationalID();
                    break;

                case '2':
                    SearchAccountByName();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    HoldScreen();//to hold the screen ...
                    break;
            }
        }
        //6.8. Show total bank balance ...
        public static void ShowTotalBankBalance()
        {
            //to check if there is a balance store or not ...
            if (balances.Count == 0)
            {
                Console.WriteLine("There is no balance stored yet!");
                HoldScreen();//just to hold a second ...
                return; //to stop the function ...
            }
            //variable to store the sum of all balance ... 
            double TotalBalance = 0;
            //to loop on all balance ...
            for (int i = 0; i < balances.Count; i++)
            {
                TotalBalance = TotalBalance + balances[i];
            }
            //to display the total balance ...
            Console.WriteLine($"The total balance is: {TotalBalance}");
            HoldScreen();//just to hold a second ...
        }
        //6.9. Show Top 3 Richest Customers ...
        public static void ShowTop3RichestCustomers()
        {
            //to check if there is a balance store or not ...
            if (balances.Count == 0)
            {
                Console.WriteLine("There is no balance stored yet!");
                HoldScreen();//just to hold a second ...
                return; //to stop the function ...
            }
            //to store and sort the balances in descending order ...
            List<double> sortedBalances = new List<double>(balances);
            sortedBalances.Sort();
            sortedBalances.Reverse();
            //to display the top 3 richest customers ...
            Console.WriteLine("Top 3 Richest Customers:");
            for (int i = 0; i < 3; i++)
            {
                int index = balances.IndexOf(sortedBalances[i]);
                Console.WriteLine($"Account Number: {accountNumbers[index]}, " +
                                  $"User Name: {accountUserNames[index]}, " +
                                  $"Balance: {sortedBalances[i]}");
            }
            HoldScreen();//just to hold a second ...
        }
        //6.10. Export All Account Info to a New File ...
        public static void ExportAllAccountInfoToNewFile()
        {
            //to check if there is a account store or not ...
            if (accountNumbers.Count == 0)
            {
                Console.WriteLine("There is no account stored yet!");
                HoldScreen();//just to hold a second ...
                return; //to stop the function ...
            }
            try
            {
                //to export all account info to a new file ...
                string filePath = "AllAccountsInfo.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < accountNumbers.Count; i++)
                    {
                        writer.WriteLine($"Account Number: {accountNumbers[i]}, " +
                                         $"User Name: {accountUserNames[i]}, " +
                                         $"National ID: {nationalID[i]}, " +
                                         $"Balance: {balances[i]}" +
                                         $"\n----------------------");
                    }
                }
                Console.WriteLine("All account info exported successfully to AllAccountsInfo.txt");
                HoldScreen();//just to hold a second ...
            }
            catch (Exception e)
            {
                Console.WriteLine("Error exporting account info: " + e.Message);
                HoldScreen();//just to hold a second ...

            }
        }
        //6.11. Unlock Locked Accounts ...
        public static void UnlockLockedAccounts()
        {
            //to check if there is locked accounts or not ...
            if (LockedAccounts.Count == 0)
            {
                Console.WriteLine("There is no locked accounts yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to display all locked accounts ...
            Console.WriteLine("National ID For Locked Accounts:");
            foreach (string account in LockedAccounts)
            {
                Console.WriteLine(account);
            }
            //to get the account number to unlock it ...
            string NationalID = StringValidation("national id number you want to unlock");
            //to check if the NationalID exist in the locked accounts or not ...
            bool IsExist = LockedAccounts.Contains(NationalID);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the national id number you entered is not exist in the locked accounts!");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to confirm the user action to unlock the account ...
                bool action = ConfirmAction("unlock this account");
                if (action)
                {
                    LockedAccounts.Remove(NationalID);
                    Console.WriteLine($"Account number with national id: '{NationalID}' is unlocked successfully");
                    HoldScreen();//to hold the screen ...
                }
                else
                {
                    Console.WriteLine("Unlock process stoped");
                    HoldScreen();//just to hold a second ...
                }
            }
        }
        //6.12.  PrintAllTransactions method ...
        public static void PrintAllTransactions()
        {
            if (transactionAccountNumbers.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                HoldScreen();//just to hold second ...
                return;
            }
            Console.WriteLine("All Transactions:");
            Console.WriteLine("Account Number \t\t Type \t\t Amount \t\t Balance After Transaction \t\t Date");
            for (int i = 0; i < transactionAccountNumbers.Count; i++)
            {
                Console.WriteLine($"{transactionAccountNumbers[i]} \t\t" +
                                  $"{transactionType[i]} \t\t" +
                                  $"{transactionAmount[i]}\t\t" +
                                  $"{BalanceAfterTransaction[i]} \t\t" +
                                  $"{transactionDate[i]}");
                Console.WriteLine("--------------------------------------------------");
            }
            HoldScreen();//just to hold second ...
        }
        //6.13. ViewAverageFeedbackScore method ...
        public static void ViewAverageFeedbackScore()
        {
            //to check if there is review submited or not ...
            if (Ratings.Count == 0)
            {
                Console.WriteLine("There is no rating submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to calculate the average feedback score ...
            double totalScore = 0;
            int count = Ratings.Count;
            for (int i = 0; i < count; i++)
            {
                totalScore += Ratings[i];
            }
            double averageScore = totalScore / count;
            Console.WriteLine($"Average Feedback Score: {averageScore}");
            HoldScreen();//to hold the screen ...
        }
        //6.14. ApproveReguestsForLoan method ...
        public static void ApproveReguestsForLoan()
        {
            //to check if there are request or not ...
            if (RequestLoanQueue.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to get first request submited to RequestLoanQueue queue ...
            string request = RequestLoanQueue.Dequeue();
            string[] RequestDteials = request.Split('|').ToArray();
            //to get user index using nationalID ...
            int userIndex = nationalID.IndexOf(RequestDteials[0]);
            //to display the first request in the queue ...
            Console.WriteLine("The first request in queue:");
            Console.WriteLine($"User Name: {accountUserNames[userIndex]}\n" +
                              $"User National ID: {RequestDteials[0]}\n" +
                              $"Initial Balance: {balances[userIndex]}\n" +
                              $"User Phone Number: {accountPhoneNumbers[userIndex]}\n" +
                              $"User Address:{accountAddresses[userIndex]}\n" +
                              $"User Loan Amount:{RequestDteials[0]}");
            bool action = ConfirmAction("approved this loan request");
            if (action)
            {
                //to set interest rate ...
                double interestRate = DoubleValidation("interest rate");

                //to store loan details in the lists ...
                activeLoans.Add(RequestDteials[0]);
                loanInterest.Add(interestRate);
                loanAmounts.Add(Convert.ToDouble(RequestDteials[1]));//to convert RequestDteials from string to double ...
                //to add the loan into user balance ...
                balances[userIndex] += Convert.ToDouble(RequestDteials[1]);//to convert RequestDteials from string to double ...
                Console.WriteLine($"Loan created successfully for: {RequestDteials[0]}\n");
                HoldScreen();//to hold the screen ...
            }
            else
            {
                Console.WriteLine("Loan request not approved.");
                //to delete the request from the queue ...
                RequestLoanQueue.Dequeue();
                HoldScreen();//to hold the screen ...
            }
        }
        //6.15. ApproveReguestsForAccountConsultation method ...
        public static void ApproveReguestsForAccountConsultation()
        {
            //to check if there are request or not ...
            if (RequestConsultation.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to get first request submited to RequestAccountConsultationQueue queue ...
            string request = RequestConsultation.Dequeue();
            string[] RequestDteials = request.Split('|').ToArray();
            //to get user index using nationalID ...
            int userIndex = nationalID.IndexOf(RequestDteials[0]);
            //to display the first request in the queue ...
            Console.WriteLine("The first request in queue:");
            Console.WriteLine($"User Name: {accountUserNames[userIndex]}\n" +
                              $"User National ID: {RequestDteials[0]}\n" +
                              $"Initial Balance: {balances[userIndex]}\n" +
                              $"User Phone Number: {accountPhoneNumbers[userIndex]}\n" +
                              $"User Address:{accountAddresses[userIndex]}\n +" +
                              $"Consultation Date:{RequestDteials[1]}");
            bool action = ConfirmAction("approved this account consultation request");
            if (action)
            {
                Console.WriteLine($"Account consultation approved for: {RequestDteials[0]}\n");
                //to store the consultation details in the lists ...
                ActiveConsultation.Add(RequestDteials[0]);
                ConsultationDate.Add(RequestDteials[1]);
                HoldScreen();//to hold the screen ...
            }
            else
            {
                Console.WriteLine("Account consultation request not approved.");
                //to delete the request from the queue ...
                RequestConsultation.Dequeue();
                HoldScreen();//to hold the screen ...
            }
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
                }
                catch (Exception e)
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
        //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
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
            //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
            bool result = false;
            for (int i = 0; i < accountNumbers.Count; i++)
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
        static bool CheckDuplicateAccountRequests(string id)
        {
            foreach (string request in createAccountRequests)
            {
                if (string.IsNullOrWhiteSpace(request))
                    continue;

                string[] requestDetails = request.Split('|');

                // Check that the request has at least 1 element
                if (requestDetails.Length > 0 && requestDetails[1] == id)
                {
                    return true; // Duplicate found
                }
            }

            return false; // No duplicates
        }


        //7.10. To read password from the user and validate it ...
        public static string ReadPassword(string message)
        {
            //StringBuilder -> to improve performance when building strings character by character.
            //password -> to store the password input from the user ...
            StringBuilder password = new StringBuilder();
            //ConsoleKeyInfo -> is a structure that stores information
            //about a key press: the key, character, and modifiers (like Shift or Ctrl).
            ConsoleKeyInfo key;

            //To show message to the user to enter password ...
            Console.WriteLine($"Enter your {message} (press Enter when done):");
            do
            {
                //(intercept: true) -> reads a key press without showing it on the screen.
                key = Console.ReadKey(intercept: true);
                //To checks if the user pressed the Backspace key and remove it if so 
                //from the password and delete * from the console.
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
                //This filters out non-printable characters, like Ctrl or Alt.
                //If the key is normal characters (letters, digits, etc.)
                //it will enter the (if) and add the key to the password
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            //The loop continues until the user presses Enter.
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }

        //7.11. Check if the Password unique or not ...
        public static bool PasswordIsUnique(string password, List<string> list)
        {
            bool IsUnique = true;//it is unique (not exsit in the system) ...
            //to check if password is exist or not (password should be unique) ...
            foreach (var storedHashpassword in list)
            {
                //to call VerifyPasswordPBKDF2 which will hash the password and
                //compare it with the stored hash password ...
                if (VerifyPasswordPBKDF2(password, storedHashpassword))
                {
                    Console.WriteLine("Password is exist in the system.");
                    HoldScreen();//just to hoad second ...
                    IsUnique = false;
                    return false; // Match found
                }
            }
            return IsUnique; // No match
        }

        //7.12. To hashed Password ...
        public static string HashPasswordPBKDF2(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            // RNGCryptoServiceProvider -> is used to generate a cryptographically strong random number.
            {
                byte[] salt = new byte[16];//to get a random value that makes each hash unique.
                // GetBytes -> fills the specified array with a cryptographically strong random sequence of values.
                rng.GetBytes(salt);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);//to creates a secure hash using the PBKDF2 algorithm.
                byte[] hash = pbkdf2.GetBytes(20);//to gets the first 20 bytes (160 bits) of the hash.

                byte[] hashBytes = new byte[36];//to creates a final array to store salt + hash.
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                //to Copies salt (first 16 bytes) and hash (next 20 bytes) into one array.

                return Convert.ToBase64String(hashBytes);
                //to converts the whole 36-byte array to a Base64 string so
                //it can be stored in a database or file easily.
            }
        }
        //HashPasswordPBKDF2 -> this method hashes the user’s password securely using the
        //PBKDF2 algorithm with a random salt, and returns the result as a Base64 string.

        //what is salt -> a random value added to a password before hashing it.
        //It’s used to make each password hash unique, even if two users have the same password.

        //7.13. Verify password by comparing hashes
        public static bool VerifyPasswordPBKDF2(string password, string savedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(savedHash);
            //to converts the stored string back into the original 36-byte array
            //(16 bytes salt + 20 bytes hash).

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);//to extracts the first 16 bytes (the salt).

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            //to recreates the hash for the input password using the same salt and iteration count.
            byte[] hash = pbkdf2.GetBytes(20);//to gets the expected hash (20 bytes).

            for (int i = 0; i < 20; i++)//to compares each byte of the newly generated
                                        //hash with the one stored after the salt.
            {
                if (hashBytes[i + 16] != hash[i])//to check if any byte is different
                                                 //the password is incorrect.
                    return false;
            }
            return true;//If all bytes match, the password is correct.
        }
        //VerifyPasswordPBKDF2 -> this method verifies a user’s password by:
        // 1. Extracting the original salt from the stored hash
        // 2. Re-hashing the input password using the same salt
        // 3. Comparing both hashes

        //7.14. To check singIn counter ...
        public static bool CheckSignInCounter(string nationalID, int count)
        {
            bool isNotLocked = true; //to continue the loop ...
            //to check if the user countre is more than 3 or not ...
            if (count >= 3)
            {
                Console.WriteLine("Your account is locked due to multiple failed login attempts.");
                //to add the user national id to the LockedAccounts list ...
                LockedAccounts.Add(nationalID);
                HoldScreen();
                return isNotLocked = false; //to stop the loop ...

            }
            else
            {
                return isNotLocked = true; //to continue the loop ...
            }
        }

        //7.15. To check and validate the phone number input from the user ...
        public static string GetAndCheckPhoneNumberIsValid(string message)
        {
            bool PhoneFlag = false;//to handle user phone error input ...
            string PhoneInput = "null";
            do
            {
                Console.WriteLine($"Enter your {message}:");
                PhoneInput = Console.ReadLine();
                //to check if PhoneInput has number or not ...
                if (string.IsNullOrWhiteSpace(PhoneInput) || !Regex.IsMatch(PhoneInput, @"^\d{8}$"))
                {
                    Console.WriteLine($"{message} must be 8 digits and can not be null ..." +
                                      "please prass enter key to try again");
                    Console.ReadLine();//just to hoad second ...
                    PhoneFlag = true;
                }
            } while (PhoneFlag);
            //to return tne char input ...
            return PhoneInput;
        }
        //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
        //7.16. To check if user phone number is unique or not ...
        public static bool PhoneNumberIsUnique(string phone, List<string> list)
        {
            bool IsUnique = true;//it is unique (not exsit in the system) ...
            //to check if phone is exist or not (phone should be unique) ...
            foreach (var storedPhone in list)
            {
                if (phone == storedPhone)
                {
                    Console.WriteLine("Phone number is exist in the system.");
                    HoldScreen();//just to hoad second ...
                    IsUnique = false;
                    return false; // Match found
                }
            }
            return IsUnique; // No match
        }

        //7.17. DateTimeValidation method ...
        public static DateTime DateTimeValidation(string message)
        {
            bool DateTimeFlag; // to handle user DateTime error input
            DateTime DateTimeInput = DateTime.Now;

            do
            {
                DateTimeFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message} (format: MM/dd/yyyy):");
                    DateTimeInput = DateTime.Parse(Console.ReadLine());

                    //// Check if the date is in the future or today
                    //if (DateTimeInput.Date > DateTime.Now.Date)
                    //{
                    //    Console.WriteLine($"{message} should be a date valid.");
                    //    HoldScreen(); // just to hold a second
                    //    DateTimeFlag = true; // ask user again
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to: " + e.Message);
                    HoldScreen(); // just to hold a second
                    DateTimeFlag = true; // ask user again
                }
            } while (DateTimeFlag);

            return DateTimeInput; // Return the validated input
        }


        //============================ 8. Addtional methods ======================
        //8.1. Sing in method (just to sing in the end users) ...
        public static void SingUp()
        {
            bool IsExist;
            //to get NationalID from the user ...
            string UserNationalID;
            do
            {
                IsExist = false;
                //to get and validate UserNationalID input ...
                UserNationalID = StringValidation("national ID");
                bool UserNationalIDIsExsit = NationalIDIsUnique(UserNationalID, LoginUserNationalID);
                bool AdminNationalIDIsExsit = NationalIDIsUnique(UserNationalID, LoginAdminNationalID);
                if (!UserNationalIDIsExsit || !AdminNationalIDIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to get Password from the user ...
            string UserPassword;
            string UserPasswordHashed;
            do
            {
                IsExist = false;
                //to get and validate UserPassword input ...
                UserPassword = ReadPassword("Password");
                //to hash the password ...
                UserPasswordHashed = HashPasswordPBKDF2(UserPassword);
                bool UserPasswordIsExsit = PasswordIsUnique(UserPasswordHashed, LoginUserPassword);
                bool AdminPasswordIsExsit = PasswordIsUnique(UserPasswordHashed, LoginAdminPassword);
                if (!UserPasswordIsExsit || !UserPasswordIsExsit)
                {
                    IsExist = true;
                }
            } while (IsExist);
            //to store the new UserNationalID to LoginUserNationalID list ...
            LoginUserNationalID.Add(UserNationalID);
            //to store the new UserPassword to LoginUserPassword list ...
            LoginUserPassword.Add(UserPasswordHashed);
            //Console.WriteLine(UserPasswordHashed);
            Console.WriteLine("Your sing in process done successfully");
            HoldScreen();//just to hold a second ...

        }
        //8.2. Log in method ...
        public static void LogIn()
        {
            //to redirct the user to the correct menu based on his national id and password ...
            bool isNotLocked = true;
            int UserCountre = 0; // to count the number of attempts ...
            int AdminCountre = 0; // to count the number of attempts ...
            do
            {
                //to get NationalID from the user ...
                string UserNationalID = StringValidation("national ID");
                //to get Password from the user ...
                string UserPassword = ReadPassword("Password");
                //to get UserType from the user ...
                char UserType = CharValidation("user type (U for user, A for admin)");
                //to check if the user account is locked or not ...
                for (int i = 0; i < LockedAccounts.Count; i++)
                {
                    if (LockedAccounts[i] == UserNationalID)
                    {
                        Console.WriteLine("Your account is locked, please contact support.");
                        HoldScreen();
                        return; //to stop the method ...
                    }
                }
                if (UserType == 'U' || UserType == 'u')
                {
                    //to check if the user national id and password is exist in the user list ...
                    for (int i = 0; i < LoginUserNationalID.Count; i++)
                    {
                        if (LoginUserNationalID[i] == UserNationalID &&
                            VerifyPasswordPBKDF2(UserPassword, LoginUserPassword[i]))
                        {
                            //to call EndUserMenu method ...
                            EndUserMenu(UserNationalID);
                            return; //to stop the method ...
                        }
                    }
                    Console.WriteLine("Sorry ... your national id or password is " +
                                      "not a exist in the system.");
                    UserCountre++;
                    isNotLocked = CheckSignInCounter(UserNationalID, UserCountre);
                    HoldScreen();


                }
                else if (UserType == 'A' || UserType == 'a')
                {
                    //to check if the user national id and password is exist in the admin list ...
                    for (int i = 0; i < LoginAdminNationalID.Count; i++)
                    {
                        if (LoginAdminNationalID[i] == UserNationalID &&
                            VerifyPasswordPBKDF2(UserPassword, LoginAdminPassword[i]))
                        {
                            //to call AdmainMenu method ...
                            AdmainMenu(UserNationalID);
                            return; //to stop the method ...
                        }
                    }
                    Console.WriteLine("Accusse stop ... Sory you are not a admin");
                    AdminCountre++;
                    isNotLocked = CheckSignInCounter(UserNationalID, AdminCountre);
                    HoldScreen();
                }
                else
                {
                    Console.WriteLine("Invalid user type. Please enter 'U' for user or 'A' for admin.");
                    HoldScreen();
                    continue; //to continue the loop ...
                }
            } while (isNotLocked);//to loop until the user enter correct national id and password ... 
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
                                          $"{nationalID[i]},{balances[i]}," +
                                          $"{accountPhoneNumbers[i]},{accountAddresses[i]}";
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
        public static void SaveLoginUserToFile()
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
                        //to compaine user national id with password from their list to one txt file 
                        string dataLine = $"{LoginUserNationalID[i]},{LoginUserPassword[i]}";

                        writer.WriteLine(dataLine);
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
        public static void SaveLoginAdminToFile()
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
                        //to compaine user national id with password from their list to one txt file 
                        string dataLine = $"{LoginAdminNationalID[i]},{LoginAdminPassword[i]}";

                        writer.WriteLine(dataLine);
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
        //8.12. SaveReviewsNationalId method ...
        public static void SaveReviewsNationalId()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(ReviewsNationalIDFilePath))
                {
                    for (int i = 0; i < reviewsNationalID.Count; i++)
                    {
                        writer.WriteLine(reviewsNationalID[i]);
                    }
                }
                Console.WriteLine("Reviews national id saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving reviews national id into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.13. SaveLockedAccounts method ...
        public static void SaveLockedAccounts()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(LockedAccountsFilePath))
                {
                    foreach (var account in LockedAccounts)
                    {
                        writer.WriteLine(account);
                    }
                }
                Console.WriteLine("Locked accounts saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving locked accounts into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.14. SaveTransactionsToFile method ...
        public static void SaveTransactionsToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(TransactionFilePath))
                {
                    for (int i = 0; i < transactionAccountNumbers.Count; i++)
                    {
                        //to compaine all the end transcation data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in TransactionFilePath
                        string dataLine = $"{transactionAccountNumbers[i]},{transactionType[i]}," +
                                          $"{transactionAmount[i]},{BalanceAfterTransaction[i]}," +
                                          $"{transactionDate[i]}";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine("Transaction saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving transaction data into the file.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.15. LoadAccountsInformationFromFile method ...
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
                accountPhoneNumbers.Clear();
                accountAddresses.Clear();
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
                        accountPhoneNumbers.Add(parts[4]);
                        accountAddresses.Add(parts[5]);

                        if (accNum > LastAccountNumber)
                            LastAccountNumber = accNum;
                    }
                }
                Console.WriteLine("Accounts loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading account file.");
                HoldScreen();
            }
        }
        //8.16. LoadTransactionsFromFile
        public static void LoadTransactionsFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(TransactionFilePath))
                {
                    Console.WriteLine("Sorry ... no saved data found in transactions.txt file.");
                    HoldScreen();//to hold a second ...
                    return;//to stop the method ...
                }
                //to make sure that our lists are clear ...
                transactionAccountNumbers.Clear();
                transactionType.Clear();
                transactionAmount.Clear();
                BalanceAfterTransaction.Clear();
                transactionDate.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(TransactionFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        //to add the information to the lists ...
                        transactionAccountNumbers.Add(parts[0]);
                        transactionType.Add(parts[1]);
                        transactionAmount.Add(parts[2]);
                        BalanceAfterTransaction.Add(parts[3]);
                        transactionDate.Add(parts[4]);
                    }
                }
                Console.WriteLine("Transactions loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading transactions file.");
                HoldScreen();
            }
        }
        //8.16. LoadReviews method ...
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
        //8.17. LoadSaveRequestAccountOpening method ...
        public static void LoadSaveRequestAccountOpening()
        {
            try
            {
                if (!File.Exists(RequestsFilePath)) return;

                using (StreamReader reader = new StreamReader(RequestsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip empty lines
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        createAccountRequests.Enqueue(line);
                    }
                }

                Console.WriteLine("Requests accounts opening loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading requests.");
                HoldScreen();
            }
        }
        //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
        //8.18. LoadLoginUserFromFile method ...
        public static void LoadLoginUserFromFile()
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
                //to make sure that LoginUserPassword list is clear ...
                LoginUserPassword.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(EndUsersFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        //to add the information to the lists ...
                        LoginUserNationalID.Add(parts[0]);
                        LoginUserPassword.Add(parts[1]);
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
        //8.19. LoadLoginAdminNationalIDFromFile method ...
        public static void LoadLoginAdminFromFile()
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
                //to make sure that LoginAdminNationalID list is clear ...
                LoginAdminNationalID.Clear();
                //to make sure that LoginAdminPassword list is clear ...
                LoginAdminPassword.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(AdminsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        //to add the information to the lists ...
                        LoginAdminNationalID.Add(parts[0]);
                        LoginAdminPassword.Add(parts[1]);
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
        //8.20. LoadReviewsNationalId method ...
        public static void LoadReviewsNationalId()
        {
            try
            {
                if (!File.Exists(ReviewsNationalIDFilePath)) return;
                //to store file data temperey and then
                //store data in the right order in the createAccountRequests
                using (StreamReader reader = new StreamReader(ReviewsNationalIDFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        reviewsNationalID.Add(line);
                    }
                }
                Console.WriteLine("Reviews national id loaded successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error loading reviews.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.21. LoadLockedAccounts method ...
        public static void LoadLockedAccounts()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(LockedAccountsFilePath)) return;
                //to make sure that LockedAccounts list is clear ...
                LockedAccounts.Clear();
                //to store file data in the LockedAccounts list ...
                using (StreamReader reader = new StreamReader(LockedAccountsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        LockedAccounts.Add(line);
                    }
                }
                Console.WriteLine("Locked accounts loaded successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error loading locked accounts.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.22. SearchAccountByNationalID method ...
        public static void SearchAccountByNationalID()
        {
            bool FoundFlag = true;
            //to get national id from the admin ...
            string nationalIDSearch = StringValidation("national ID");
            //to loop on all nationalID list ...
            for (int i = 0; i < nationalID.Count; i++)
            {
                if (nationalIDSearch == nationalID[i])
                {
                    Console.WriteLine("Account information:");
                    Console.WriteLine($"Account number: {accountNumbers[i]}");
                    Console.WriteLine($"Account balance: {balances[i]}");
                    HoldScreen();//just to hold second ...
                    FoundFlag = false;
                    break;
                }
            }
            if (FoundFlag)
            {
                Console.WriteLine("There is no account with this national ID");
                HoldScreen();//just to hold second ...
            }
        }
        //8.23. SearchAccountByName method ...
        public static void SearchAccountByName()
        {
            bool FoundFlag = true;
            //to get name from the admin ...
            string NameSearch = StringNamingValidation("name");
            //to loop on all accountUserNames list ...
            for (int i = 0; i < accountUserNames.Count; i++)
            {
                if (NameSearch.ToLower() == accountUserNames[i].ToLower())
                {
                    Console.WriteLine("Account information:");
                    Console.WriteLine($"Account number: {accountNumbers[i]}");
                    Console.WriteLine($"Account balance: {balances[i]}");
                    HoldScreen();//just to hold second ...
                    FoundFlag = false;
                    break;
                }
            }
            if (FoundFlag)
            {
                Console.WriteLine("There is no account with this name");
                HoldScreen();//just to hold second ...
            }
        }
        //8.24.  StoreTransactions method ...
        public static void StoreTransactions(string accountNumber, string type, string amount, string balanceAfterTransaction)
        {
            //to store the transaction data in the lists ...
            transactionAccountNumbers.Add(accountNumber);
            transactionType.Add(type);
            transactionAmount.Add(amount);
            BalanceAfterTransaction.Add(balanceAfterTransaction);
            transactionDate.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Transaction details saved successfully.");
            HoldScreen();//just to hold second ...
        }
        //8.25. To rate the Service method
        public static void RateService(string ServiceName)
        {
            Console.WriteLine($"Please rate our {ServiceName} service from 1 to 5:");
            //to get the rate from the user ...
            int rating = IntValidation("rating (1 to 5)");
            //to store the rating in the Ratings list ...
            Ratings.Add(rating);
            HoldScreen();//just to hold second ...
        }
        //8.26. SaveRatingsToFile method ...
        public static void SaveRatingsToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(RatingsFilePath))
                {
                    foreach (int rating in Ratings)
                    {
                        string ratingString = rating.ToString();
                        writer.WriteLine(ratingString);
                    }
                }
                Console.WriteLine("Ratings saved successfully.");
                HoldScreen();//just to hold second ...
            }
            catch
            {
                Console.WriteLine("Error saving ratings.");
                HoldScreen();//just to hold second ...
            }
        }
        //8.27. LoadRatingsFromFile method ...
        public static void LoadRatingsFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(RatingsFilePath))
                {
                    Console.WriteLine("Sorry ... no saved data found in ratings.txt file.");
                    HoldScreen();//to hold a second ...
                    return;//to stop the method ...
                }
                //to make sure that Ratings list is clear ...
                Ratings.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(RatingsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //to add the information to the list ...
                        Ratings.Add(int.Parse(line));
                    }
                }
                Console.WriteLine("Ratings loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading ratings file.");
                HoldScreen();
            }
        }
        //8.28. ToGetDepositeMoney method ...
        public static void ToGetDepositeMoney(double CurrencyValue, int AccountNumber, string type)
        {
            //to do the process of deposite money ...
            double DepositeMoney = DoubleValidation("money amount to deposite");
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
            double Deposite = AccountMoney + (DepositeMoney * CurrencyValue);
            balances[index] = Deposite;
            Console.WriteLine($"Your deposite process done successfully.\n" +
                              $"Your new balance is: {Deposite}");
            //to store the transaction details in the lists ...
            StoreTransactions(AccountNumber.ToString(), type, (DepositeMoney * CurrencyValue).ToString(),
                                  Deposite.ToString());
            //to get user rate on service ...
            RateService("deposite");
        }
        //8.29. RequestLoan method ...
        public static void RequestLoan(string id)
        {
            //to get account balance using index of nationalID (id) ...
            int index = nationalID.IndexOf(id);
            if (balances[index] >= 5000 && activeLoans.Contains(id) == false)
            {
                double loanAmount = DoubleValidation("loan amount");
                string request = $"{id}|{loanAmount}";
                //to add laon request to the RequestLaon queue ...
                RequestLoanQueue.Enqueue(request);
                Console.WriteLine("Your request for a loan submited successfully");
                HoldScreen();//just to hold a second ...
            }
            else
            {
                Console.WriteLine("You are not eligible for a loan request." +
                                  "Your balance should be more than 5000 and you should not have an active loan.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.30. SaveRequestLoanToFile method ...
        public static void SaveRequestLoanToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(RequestLoanFilePath))
                {
                    foreach (var request in RequestLoanQueue)
                    {
                        writer.WriteLine(request);
                    }
                }
                Console.WriteLine("Request loan saved successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error saving request loan.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.31. LoadRequestLoanFromFile method ...
        public static void LoadRequestLoanFromFile()
        {
            try
            {
                if (!File.Exists(RequestLoanFilePath)) return;
                using (StreamReader reader = new StreamReader(RequestLoanFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip empty lines
                        if (string.IsNullOrWhiteSpace(line))
                            continue;
                        RequestLoanQueue.Enqueue(line);
                    }
                }
                Console.WriteLine("Requests loans loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading requests loans.");
                HoldScreen();
            }
        }
        //8.32. SaveActiveLoansToFile method ...
        public static void SaveActiveLoansToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(ActiveLoansFilePath))
                {
                    for (int i = 0; i < activeLoans.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{activeLoans[i]}," +
                                          $"{loanAmounts[i].ToString()}," +
                                          $"{loanInterest[i].ToString()},";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine("Active loans saved successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error saving active loans.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.33. LoadActiveLoansFromFile method ...
        public static void LoadActiveLoansFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(ActiveLoansFilePath)) return;
                //to make sure that activeLoans list is clear ...
                activeLoans.Clear();
                //to make sure that loanAmounts list is clear ...
                loanAmounts.Clear();
                //to make sure that loanInterest list is clear ...
                loanInterest.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(ActiveLoansFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //to add the information to the list ...
                        string[] parts = line.Split(',');
                        activeLoans.Add(parts[0]);
                        loanAmounts.Add(double.Parse(parts[1]));
                        loanInterest.Add(double.Parse(parts[2]));
                    }
                }
                Console.WriteLine("Active loans loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading active loans file.");
                HoldScreen();
            }
        }
        //8.34. AccountConsultation method ...
        public static void AccountConsultation(string id)
        {
            //to check if user has an active consultation or not ...
            if (ActiveConsultation.Contains(id))
            {
                Console.WriteLine("You already have an active consultation.");
                HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            bool DateTimeFlag;
            DateTime consultationDate;
            do
            {
                DateTimeFlag = false;
                //to get the date for the consultation from the user ...
                consultationDate = DateTimeValidation("consultation date");
                // Check if the date is in the past or not ...
                if (consultationDate.Date < DateTime.Now.Date)
                {
                    Console.WriteLine($"consultation date should be a date valid.");
                    HoldScreen(); // just to hold a second
                    DateTimeFlag = true; // ask user again
                }
            } while (DateTimeFlag);
            //to add the user national id to the RequestConsultation qeue ...
            string request = $"{id}|{consultationDate.ToString("yyyy-MM-dd HH:mm:ss")}";
            RequestConsultation.Enqueue(request);
            Console.WriteLine("Your request for a consultation has been submitted successfully.");
            HoldScreen();//just to hold a second ...

        }
        //8.35. SaveRequestActiveConsultationToFile method ...
        public static void SaveRequestConsultationToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(RequestConsultationFilePath))
                {
                    foreach (var request in RequestConsultation)
                    {
                        writer.WriteLine(request);
                    }
                }
                Console.WriteLine("Request consultation saved successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error saving request consultation.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.36. LoadRequestConsultationFromFile method ...
        public static void LoadRequestConsultationFromFile()
        {
            try
            {
                if (!File.Exists(RequestConsultationFilePath)) return;
                using (StreamReader reader = new StreamReader(RequestConsultationFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip empty lines
                        if (string.IsNullOrWhiteSpace(line))
                            continue;
                        RequestConsultation.Enqueue(line);
                    }
                }
                Console.WriteLine("Requests consultations loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading requests consultations.");
                HoldScreen();
            }

        }
        //8.37. SaveActiveConsultationToFile method ...
        public static void SaveActiveConsultationToFile()
        {
            try
            {
                //we do not check if the file exist or not becouse 
                //StreamWriter will create the file in the same path we put 
                //if he do not found it 
                using (StreamWriter writer = new StreamWriter(ActiveConsultationFilePath))
                {
                    for (int i = 0; i < ActiveConsultation.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{ActiveConsultation[i]},{ConsultationDate[i]}";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine("Active consultations saved successfully.");
                HoldScreen();//just to hold a second ...
            }
            catch
            {
                Console.WriteLine("Error saving active consultations.");
                HoldScreen();//just to hold a second ...
            }
        }
        //8.38. LoadActiveConsultationFromFile method ...
        public static void LoadActiveConsultationFromFile()
        {
            try
            {
                //to check if the file is exist or not ...
                if (!File.Exists(ActiveConsultationFilePath)) return;
                //to make sure that ActiveConsultation list is clear ...
                ActiveConsultation.Clear();
                //to make sure that ConsultationDate list is clear ...
                ConsultationDate.Clear();
                //loading process start here
                using (StreamReader reader = new StreamReader(ActiveConsultationFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //to add the information to the list ...
                        string[] parts = line.Split(',');
                        ActiveConsultation.Add(parts[0]);
                        ConsultationDate.Add(parts[1]);
                    }
                }
                Console.WriteLine("Active consultations loaded successfully.");
                HoldScreen();
            }
            catch
            {
                Console.WriteLine("Error loading active consultations file.");
                HoldScreen();
            }
        }
        //8.39. GenerateDataBackupForTheSystem method ...
        public static void GenerateDataBackupForTheSystem()
        {
            try
            {
                //to get a rundon number to create a unique backup file name ...
                Random random = new Random();
                //to create a backup file ...
                string backupFileName = $"Backup_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{random.Next(1000, 9999)}.txt";
                using (StreamWriter writer = new StreamWriter(backupFileName))
                {
                    //to write all data to the backup file ...
                    writer.WriteLine("All Account Informaton:");
                    for (int i = 0; i < accountNumbers.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{accountNumbers[i]},{accountUserNames[i]}," +
                                          $"{nationalID[i]},{balances[i]}," +
                                          $"{accountPhoneNumbers[i]},{accountAddresses[i]}";
                        writer.WriteLine(dataLine);
                    }
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("All Transactions:");
                    for (int i = 0; i < transactionAccountNumbers.Count; i++)
                    {
                        //to compaine all the end transcation data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in TransactionFilePath
                        string dataLine = $"{transactionAccountNumbers[i]},{transactionType[i]}," +
                                          $"{transactionAmount[i]},{BalanceAfterTransaction[i]}," +
                                          $"{transactionDate[i]}";
                        writer.WriteLine(dataLine);
                    }
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("All Reviews:");
                    foreach (var review in reviewsStack)
                    {
                        writer.WriteLine(review);
                    }
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("All Ratings:");
                    foreach (var rating in Ratings)
                    {
                        writer.WriteLine(rating);
                    }
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("All Active Loans:");
                    for (int i = 0; i < activeLoans.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{activeLoans[i]}," +
                                          $"{loanAmounts[i].ToString()}," +
                                          $"{loanInterest[i].ToString()},";
                        writer.WriteLine(dataLine);
                    }
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("All Active Consultations:");
                    for (int i = 0; i < ActiveConsultation.Count; i++)
                    {
                        //to compaine all the end user data which store in 4 lists
                        //together in one varible and give it to writer to wrote
                        //in AccountsFilePath
                        string dataLine = $"{ActiveConsultation[i]},{ConsultationDate[i]}";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine($"Data backup created successfully: {backupFileName}");
                HoldScreen();//just to hold a second ...
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating data backup: " + e.Message);
                HoldScreen();//just to hold a second ...
            }
        }


    }
}
