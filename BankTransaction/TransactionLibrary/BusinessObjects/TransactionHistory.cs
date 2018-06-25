using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionLibrary.BusinessObjects
{
   public class TransactionHistoryCacheModel
    {
       

        public TransactionHistoryCacheModel()
        {
            TransactionList = new List<Transaction>();
        }
        public List<Transaction> TransactionList { get; set; }



        private static TransactionHistoryCacheModel _instance = null;
        /// <summary>
        /// 
        /// </summary>
        public static TransactionHistoryCacheModel GetInstance()
        {
            if (_instance == null)
            {               
                _instance = new TransactionHistoryCacheModel();
            }
            return _instance;
        }
    }
}
