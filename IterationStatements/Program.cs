using System;
using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            #region While
            int x = 0;
                while (x < 10)
                {
                    WriteLine(x);
                    x++;
                }
            #endregion

            #region do While
            string password = string.Empty;
                do
                {
                    Write("Enter your password");
                    password = ReadLine();
                } while (password != "Pa$$w0rd");

                WriteLine("Correct");
            #endregion

            #region For
                for (int y = 1; y <= 10; y++)
                {
                    WriteLine(y);
                }
            #endregion

            #region foreach
                string [] names = {"BrunitoSuavecito03", "LuisQuenoComunica", "FlyingPig" };
                foreach (var name in names)
                {
                    WriteLine($"{name} has {name.Length} characters.");
                }
            #endregion

        }
    }
}
