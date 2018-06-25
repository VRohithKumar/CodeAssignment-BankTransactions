using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionLibrary.Model
{
   public class AccountDetailsCacheModel
    {
        public AccountDetailsCacheModel()
        {
            AccountDetailsList = new List<AccountDetails>();
        }
       public List<AccountDetails> AccountDetailsList { get; set; }     

        

        private static AccountDetailsCacheModel _instance = null;
        /// <summary>
        /// 
        /// </summary>
        public static AccountDetailsCacheModel GetInstance()
        {
            if (_instance == null)
            {
                //typeof(PersonDataCacheModel)
                //{
                //    _instance = new PersonDataCacheModel();
                //}
                _instance = new AccountDetailsCacheModel();
            }
            return _instance;
        }
    }
}
