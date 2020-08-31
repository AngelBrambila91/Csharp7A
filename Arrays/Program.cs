using System;
using static System.Console;
namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names;
            names = new string[4];

            names[0] = "Chewy";
            names[1] = "Flying pig";
            names[2] = "Lares";
            names[3] = "Luisrard";

            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]);
            }

            #region Check for nulls

                var address = new Address();
                address.Building = null;
                address.Street = null;
                address.City = "Mexico";
                address.Region = null;
            #endregion
        }
    }
class Address
{
public string? Building; // can be null
public string Street = string.Empty;
public string City = string.Empty;
public string Region = string.Empty;
}
}