using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ATM.Core.Framework.Encryption
{
    class HashProvider : IHashProvider
    {
        private byte[] tmpSource;
        private byte[] tmpHash;
        public string GetHash(string value)
        {
            tmpSource = ASCIIEncoding.ASCII.GetBytes(value);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return (ByteArrayToString(tmpHash));
        }
        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
