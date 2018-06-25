using System;
using System.Collections.Generic;
using System.Text;
using TransactionLibrary.Model;

namespace TransactionLibrary.BusinessLogic
{
    public class ManageAccount
    {

        public AccountDetailsCacheModel _accountCacheModel = AccountDetailsCacheModel.GetInstance();

        public bool CreateAccount(AccountDetails accountDetails)
        {            
            ValidateTransactions.InitializeAccountDetails(_accountCacheModel.AccountDetailsList);
            if (_accountCacheModel.AccountDetailsList.Count == 0)
            {
                _accountCacheModel.AccountDetailsList.Add(accountDetails);
                return true;
            }
            else if (ValidateTransactions.ValidateAccount(accountDetails.AccountNumber))
            {
                _accountCacheModel.AccountDetailsList.Add(accountDetails);

                return true;

            }
            return false;
        }

        public void ManageAccountDetails(string accountDetails)
        {
            AccountDetails ad = new AccountDetails();

            if (accountDetails.Split('_').Length == 2)
            {
                ad.AccountNumber = accountDetails.Split('_')[0].ToString();
                ad.Name = accountDetails.Split('_')[1].ToString();
                if (CreateAccount(ad))
                {
                    Console.WriteLine("Account Created! Please select your options");

                }
                else
                {
                    Console.WriteLine("Account Already exists");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Format");
            }
        }

        public List<AccountDetails> getAcountDetails()
        {
            return _accountCacheModel.AccountDetailsList;
        }

        public void CreditAmount(string accountNo,double amount)
        {
            AccountDetails accntDetails = _accountCacheModel.AccountDetailsList.Find(item => item.AccountNumber == accountNo);
            accntDetails.Amount += amount;
        }

        public void DebitAmount(string accountNo, double amount)
        {
            AccountDetails accntDetails = _accountCacheModel.AccountDetailsList.Find(item => item.AccountNumber == accountNo);
            accntDetails.Amount -= amount;
        }


    }
}
