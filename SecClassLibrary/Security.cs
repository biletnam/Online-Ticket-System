using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SecClassLibrary
{
    public class Security
    {
        private const String KEY = "e5d66cf8";
        private const String IV = "haisheng";

        public static String Encryption(String data)
        {
            byte[] byKey = ASCIIEncoding.ASCII.GetBytes(KEY);
            byte[] byIV = ASCIIEncoding.ASCII.GetBytes(IV);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            String res = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            return res;
        }

        public static String Decryption(String data)
        {
            byte[] byKey = ASCIIEncoding.ASCII.GetBytes(KEY);
            byte[] byIV = ASCIIEncoding.ASCII.GetBytes(IV);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch { return null; }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            String res = sr.ReadToEnd();
            return res;
        }
    }
}
