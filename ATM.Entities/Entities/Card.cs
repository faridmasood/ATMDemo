using ATM.DataObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ATM.DataObjects.Entities
{
    public class Card : BaseEntity
    {
        #region Compute a Hash Value
        private string sSourceData;
        private byte[] tmpSource;
        private byte[] tmpHash;
        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        #endregion

        public string CardNumber { get; set; }
        public string PinCode
        {
            get
            {
                tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                return (ByteArrayToString(tmpHash));
            }
            set
            {
                sSourceData = value;
            }
        }

        public CardType Type { get; set; }
        public CardService ServiceType { get; set; }
        public int CSV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Balance { get; set; }
        public decimal Limit { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
