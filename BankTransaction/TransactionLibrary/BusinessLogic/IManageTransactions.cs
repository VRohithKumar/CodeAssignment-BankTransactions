using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionLibrary.BusinessLogic
{
    interface IManageTransactions
    {
        void CreditAmount(string accountNumber, double amount);

        void DebitAmount(string accountNumber, double amount);
    }
}
