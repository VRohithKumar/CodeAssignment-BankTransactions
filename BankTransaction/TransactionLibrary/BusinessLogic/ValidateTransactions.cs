using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TransactionLibrary.Model;
using TransactionLibrary.BusinessObjects;

namespace TransactionLibrary.BusinessLogic
{
    public static class ValidateTransactions
    {
        
        public static List<AccountDetails> _accountDetailList;
        public static List<Transaction> _transactionHistoryList;
        public static string errorMessage = "";

        public static void InitializeTransactionDetails(List<Transaction> transactionHistory)
        {
            _transactionHistoryList = transactionHistory;

        }

        public static void InitializeAccountDetails(List<AccountDetails> accountList)
        {
            _accountDetailList = accountList;

        }

        public static bool ValidateAccount(string accountNumber)
        {       
            
            return !_accountDetailList.Exists(item => item.AccountNumber == accountNumber);
        }

        public static bool ValidateAccountBanalnce(string accountNo, double amount)
        {
            return _accountDetailList.Find(item => item.AccountNumber.Contains(accountNo)).Amount >= amount;
        }

        public static bool ValidateTransactionLimit(string sourceDestinationAccnt)
        {
            IEnumerable<Transaction> _transactionDetails = getTransactionHistoryByAccNo(sourceDestinationAccnt);
            double amount = 0.0;
            foreach (Transaction tran in _transactionDetails)
            {
                amount += tran.Amount;
            }
            if (amount < 5000)
            {
                return false;
            }
            return true;

        }

        public static IEnumerable<Transaction> getTransactionHistoryByAccNo(string sourceDestinationAccnt)
        {
            var _transactionDetails = from details in _transactionHistoryList
                                      where details.SourceDestinationAccount == sourceDestinationAccnt
                                      where details.TransactionDate ==DateTime.Now.ToString("yyyy-MM-dd")
                                      select details;
            return _transactionDetails;
        }

        public static bool ValidateTransactionCount(string sourceDestinationAccnt)
        {
            IEnumerable<Transaction> _transactionDetails = getTransactionHistoryByAccNo(sourceDestinationAccnt);
            if(_transactionDetails.Count() > 3)
            {
                return false;
            }
            return true;
        }
    }
}
