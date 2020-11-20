using System;
using static System.Console;
using System.Security.Cryptography;
using CryptoLib;

namespace CryptoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using aes
            // Write("Enter a messas to encrypt : ");
            // string message = ReadLine();
            // Write("Enter a password : ");
            // string password = ReadLine();

            // string cryptoText = Protector.Ecrypt(message, password);

            // WriteLine($"Encrypted text is : {cryptoText}");
            // Write("Enter a password : ");
            // string password2 = ReadLine();
            // try
            // {
            //     string clearText = Protector.Decrypt(cryptoText, password2);
            //     WriteLine($"Decrypted text : {clearText} ");
            // }
            // catch (CryptographicException ex)
            // {
            //     WriteLine($"You entered the wrong password. \n More details : {ex.Message}");
            // }
            // catch (Exception ex)
            // {
            //     WriteLine($"Something went wrong  : {ex.GetType().Name} {ex.Message}");
            // }
            #endregion

            #region Using sha 256
                WriteLine("Registering Brunito with Pa$$w0rd");
                var brunito = Protector.Register("BrunitoSuavecito03", "Pa$$w0rd");
                WriteLine($"Name :{brunito.Name}");
                WriteLine($"Salt :{brunito.Salt}");
                WriteLine($"Password : {brunito.SaltedHashedPassword}");

                Write("Enter a user to register : ");
                string username = ReadLine();
                Write("Enter password for (username)");
                string password = ReadLine();
                var user = Protector.Register(username, password);
                WriteLine($"Name :{user.Name}");
                WriteLine($"Salt :{user.Salt}");
                WriteLine($"Password : {user.SaltedHashedPassword}");
                WriteLine();

                bool correctPassword = false;
                while(!correctPassword)
                {
                    Write("Enter a username to Log in: ");
                    string loginUsername = ReadLine();
                    Write("Enter a password to log in: ");
                    string loginPassword = ReadLine();
                    correctPassword = Protector.CheckPassword(loginUsername, loginPassword);
                    if(correctPassword)
                    {
                        WriteLine("Login succesful");
                    }
                    else
                    {
                        WriteLine("Invalid Username or password");
                    }
                }
            #endregion
        }
    }
}
