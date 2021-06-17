using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MusicPortal_2.Util
{
    public class Hasher
    {
        public string HashPassword(string salt, string password)
        {
            byte[] passwordByte = Encoding.Unicode.GetBytes(salt + password);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(passwordByte);

            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
            {
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            }
            CSP.Dispose();
            return hash.ToString();
        }
    }
}