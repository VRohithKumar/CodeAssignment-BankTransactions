using System;
using System.Collections.Generic;
using System.Text;
using TransactionLibrary.BusinessObjects;

namespace TransactionLibrary.BusinessLogic
{
    public class ManageTransactions : IManageTransactions
    {
        public TransactionHistoryCacheModel _transactionCacheModel = TransactionHistoryCacheModel.GetInstance();
        ManageAccount _manageAccount = new ManageAccount();
        public void ManageTransactionDetails(string sourceAccNo, string destinationAccNo, double amount)
        {
            ValidateTransactions.InitializeTransactionDetails(_transactionCacheModel.TransactionList);
            /**
             * check for accounts exists or not
             * check for source balance history
             * check for transaction limit per day
             * check for transaction amount limit per day
             * credit amount
             * debit amount
             * */
            if(ValidateTransaction(sourceAccNo, destinationAccNo, amount))
            {
                Console.WriteLine("transaction successfull");
            }
            else
            {
                Console.WriteLine("Transaction Failed !!");
            }

        }

        public bool ValidateTransaction(string sourceAccNo, string destinationAccNo, double amount)
        {
            if (ValidateTransactions.ValidateAccount(sourceAccNo)
                && ValidateTransactions.ValidateAccount(destinationAccNo)
                && ValidateTransactions.ValidateAccountBanalnce(sourceAccNo, amount)
                && ValidateTransactions.ValidateTransactionLimit(sourceAccNo + "_" + destinationAccNo)
                && ValidateTransactions.ValidateTransactionCount(sourceAccNo + "_" + destinationAccNo))
            {
                CreditAmount(sourceAccNo, amount);
                DebitAmount(destinationAccNo, amount);
                ManageTransactionHistory(sourceAccNo, destinationAccNo, amount);              
                return true;
            }

            return false;
        }

        public void ManageTransactionHistory(string sourceAccNo, string destinationAccNo, double amount)
        {
            Transaction trans = new Transaction();
            trans.SourceDestinationAccount = sourceAccNo + "_" + destinationAccNo;
            trans.Amount = amount;
            trans.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd");
            _transactionCacheModel.TransactionList.Add(trans);
        }

        

        public void CreditAmount(string accountNo, double amount)
        {

            _manageAccount.CreditAmount(accountNo, amount);
        }

        public void DebitAmount(string accountNo, double amount)
        {           
            _manageAccount.DebitAmount(accountNo, amount);
        }

    }
}
