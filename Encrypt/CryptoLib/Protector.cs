 using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Security.Cryptography;
 using System.Security.Principal;
 using System.Text;
 using System.Xml.Linq;
 using static System.Convert;

namespace CryptoLib
{
    public static class Protector
    {
        /*
        Encryption and Decryption : Two way process.
        Key : The key to decrypt a message
        Hashes : One way process, generate secure info.
        Signatures: Technique that is used to ensure the data is coming from a trusty source.
        Authentication : 
        Salt : 
        */
        private static readonly byte [] salt = Encoding.Unicode.GetBytes("KDA71");

        // iterations must be at least 1000 
        private static readonly int iterations = 2000;

        public static string Ecrypt(string plainText, string password)
        {
            byte [] encryptedBytes;
            byte [] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var settings = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = settings.GetBytes(32); // set a 256 bit key
            aes.IV = settings.GetBytes(16);
            
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte [] plainBytes;
            byte [] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var settings = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = settings.GetBytes(32); // set a 256 bit key
            aes.IV = settings.GetBytes(16);
            
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }
            return Encoding.Unicode.GetString(plainBytes);
        }

    }
}
