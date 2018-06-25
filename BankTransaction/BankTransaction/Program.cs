using System;
using System.Collections.Generic;
using TransactionLibrary.BusinessLogic;
using TransactionLibrary.Model;

namespace BankTransaction
{
    class Program
    {
        private static void CreateAccount(string accountDetails)
        {
            ManageAccount manageAccount = new ManageAccount();
            manageAccount.ManageAccountDetails(accountDetails);
        }

        private static void ManageTransactions(string sourceAccNo, string destinationAccNo, double amount)
        {
            ManageTransactions _manageTransactions = new ManageTransactions();
            _manageTransactions.ManageTransactionDetails(sourceAccNo, destinationAccNo, amount);
        }

        private static void DisplayAccountDetails()
        {
            ManageAccount manageAccount = new ManageAccount();
            List<AccountDetails> _accountDetails = manageAccount.getAcountDetails();
            foreach (AccountDetails ad in _accountDetails)
            {
                Console.WriteLine("Account details for Account #" + ad.AccountNumber + "\n" +
                                    "Name :" + ad.Name + "\n" +
                                    "Amount:" + ad.Amount + "\n");
            }
        }



        private static void PerformInputOperations(string option)
        {
            string sourceAccNumber, destAccNumber;
            double amount;
            switch (option)
            {
                case "1":
                    Console.WriteLine("Please enter AccountNumber with Name . Ex(1234_name)");
                    CreateAccount(Console.ReadLine());
                    PerformInputOperations(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Please enter source account number");
                    sourceAccNumber = Console.ReadLine();
                    Console.WriteLine("Please enter destination account number");
                    destAccNumber = Console.ReadLine();
                    Console.WriteLine("Please enter amount");
                    amount = Convert.ToDouble(Console.ReadLine());
                    ManageTransactions(sourceAccNumber, destAccNumber, amount);
                    PerformInputOperations(Console.ReadLine());
                    break;
                case "3":
                    DisplayAccountDetails();
                    PerformInputOperations(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Please select appropriate option");
                    break;

            }
        }



        /*
         * ManageTransactions class : ITransaction
         * Validation Class will have CheckAccountNumber,CheckAccountBalance,CheckTransactionCount,CheckTransactionLimit
         * ITransaction will have CreditAmountTo--> -ve soure amount and + destination amount,          
         * Class
         *  Account Number and Name-- save it in List<AccountDetails>
         *  ManageTransaction--> sourceDestination , date , transactionCount , transactionAmount
         *  Create account --> enter source account number-->Validate this
         *                 --> enter destination acount number-->validate this
         *                 --> enter amount to transfer
         *                 --> Call Manage transaction method and validate
         *                 --> After successfull transaction call insert sourceDestination,amount,date,transactionCount 
         *                     to LIst<transactionHistory>
         *                 -->for next trasaction check transactionHistory list and 
         *  
         * */
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter 1 for Adding account And" +
                                "2 for transaction"+
                                "3 for Account details");
            PerformInputOperations(Console.ReadLine());



        }

    }
}
