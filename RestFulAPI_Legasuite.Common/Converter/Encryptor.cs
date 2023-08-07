using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Common.Converter
{
    public class Encryptor
    {
        private static readonly string keyString = "840c451bfa1f4a4c96257c145c19b357";
        private readonly static string ivString = "9169b22472c44a2f";
        public static string DecryptString(string cipherText)
        {
            Aes aes = GetEncryptionAlgorithm();
            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream memoryStream = new MemoryStream(buffer);
            using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }
        private static Aes GetEncryptionAlgorithm()
        {
            byte[] iv = new byte[16];
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            aes.IV = Encoding.UTF8.GetBytes(ivString);

            return aes;
        }


        public static string EncryptString(string password)
        {
            byte[] array;
            byte[] iv = new byte[16];
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes("840c451bfa1f4a4c96257c145c19b357");
            aes.IV = Encoding.UTF8.GetBytes("9169b22472c44a2f");
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(password);
                    }

                    array = memoryStream.ToArray();
                }
            }
            //return aes;
            return Convert.ToBase64String(array);
        }

    }
}
