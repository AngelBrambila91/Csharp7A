using System;
using static System.Console;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            #region object
            object height = 1.88;
            object name = "Ayon";

            WriteLine($"{name} is {height} neters tall");
            //int lenght = name.Lenght; // error
            int lenght2 = ((string)name).Length;
            #endregion

            #region dynamic
                dynamic name2 = "0BuronSuave3";
                int lenght3 = name2.Length;
            #endregion

            #region Var
                var fruit = "Apples";
                var population = 6_000_000_000;
                int length3 = fruit.Length;
            #endregion

            #region DefaultValues
                WriteLine($"default(int) = {default(int)}");
                WriteLine($"default(bool) = {default(bool)}");
                WriteLine($"default(Datetime) = {default(DateTime)}");
                WriteLine($"default(string) = {default(string)}");
            #endregion
            

        }
    }
}
