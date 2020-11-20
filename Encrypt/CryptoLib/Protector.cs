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
    // public class User
    // {
    //     public string Name { get; set; }
    //     public string Salt { get; set; }
    //     public string SaltedHashedPassword { get; set; }
    // }
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

        #region Sha 256
            private static Dictionary<string, User> Users = new Dictionary<string, User>();

            public static User Register(string username, string password)
            {
                // generate random salt
                var rng = RandomNumberGenerator.Create();
                var saltBytes = new byte [16];
                rng.GetBytes(saltBytes);
                var saltText = Convert.ToBase64String(saltBytes);

                // hash the password
                var saltedhashedpassword = SaltAndHashPassword(password, saltText);
                var user = new User
                {
                    Name = username,
                    Salt = saltText,
                    SaltedHashedPassword = saltedhashedpassword
                };
                Users.Add(user.Name , user);
                return user;
            }

            public static bool CheckPassword(string username , string password)
            {
                if(!Users.ContainsKey(username))
                {
                    return false;
                }
                var user = Users[username];
                // re-generate hashed password
                var saltedhashedpassword = SaltAndHashPassword(password, user.Salt);
                return (saltedhashedpassword == user.SaltedHashedPassword);

            }

        private static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }
        #endregion

    }
}
