using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionLibrary.BusinessObjects
{
    public class Transaction
    {
        public string SourceDestinationAccount { get; set; }

        public double Amount { get; set; } = 0;

        public  string TransactionDate { get; set; }

        public int TransactionCount { get; set; } = 0;
    }
}
