using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace SuperVolt_Web_App.Utils
{
    public class EncryptUtil
    {
        public string GeneratePasswordHash(string Password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(Password); // Turn password into byte array
            tmpHash = md5.ComputeHash(tmpSource);

            StringBuilder sOutput = new StringBuilder(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));  // X2 formats to hexadecimal
            }
            return sOutput.ToString();
        }
    }
}