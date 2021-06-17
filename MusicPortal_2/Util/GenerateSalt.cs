using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MusicPortal_2.Util
{
    public class GenerateSalt
    {
        public string CreateSalt(int byteForSalt)
        {
            byte[] saltbuf = new byte[byteForSalt];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(byteForSalt);
            for (int i = 0; i < byteForSalt; i++)
            {
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            }

            rng.Dispose();

            return sb.ToString();
        }
    }
}