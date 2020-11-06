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
            Write("Enter a messas to encrypt : ");
            string message = ReadLine();
            Write("Enter a password : ");
            string password = ReadLine();

            string cryptoText = Protector.Ecrypt(message, password);

            WriteLine($"Encrypted text is : {cryptoText}");
            Write("Enter a password : ");
            string password2 = ReadLine();
            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text : {clearText} ");
            }
            catch (CryptographicException ex)
            {
                WriteLine($"You entered the wrong password. \n More details : {ex.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"Something went wrong  : {ex.GetType().Name} {ex.Message}");
            }
        }
    }
}
