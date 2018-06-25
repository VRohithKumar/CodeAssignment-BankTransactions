using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionLibrary.Model
{
    public class AccountDetails
    {
        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; } = 0;
    }
}
