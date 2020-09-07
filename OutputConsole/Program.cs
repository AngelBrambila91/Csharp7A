using System;
using static System.Console;
namespace OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Positional Arguments Format
                // Format by positional arguments
            int numberOfOreos = 8;
            decimal pricePerOreo = 1.35M;

            WriteLine(
                format: "{0} oreos costs {1:C} {2}",
                arg0: numberOfOreos,
                arg1: pricePerOreo * numberOfOreos,
                arg2: "Hla"
            );

            string formatted = string.Format(
                format: "{0} oreos costs {1:C}",
                arg0: numberOfOreos,
                arg1: pricePerOreo * numberOfOreos
            );
            WriteLine(formatted);

            string formatted2 = string.Format($"{numberOfOreos} Oreos cost{pricePerOreo}");
            #endregion
            
            #region Interpolated String Format
            // Format using interpolated strings
            WriteLine ($"{numberOfOreos} oreos cost {pricePerOreo * numberOfOreos:C}");
            string shokis = "Shokis";
            int shokisCount = 2345;
            string oreos = "Oreos";
            int oreosCount = 5678999;

            WriteLine(
                format: "{0, -8}{1, 7}",
                arg0: "Name",
                arg1: "Count"
            );
            WriteLine(
                format: "{0, -8}{1, 7}",
                arg0: shokis,
                arg1: shokisCount
            );
            WriteLine(
                format: "{0, -8} {1, 7}",
                arg0: oreos,
                arg1: oreosCount
            );
            
            WriteLine($"{shokis, -8}{shokisCount, 7}");
            WriteLine($"{oreos, -8}{oreosCount, 7}");
            #endregion

            #region ReadLine
            WriteLine("Type your age and press ENTER :");
            string age = ReadLine();
            WriteLine("Type your Name and press ENTER :");
            string firstName = ReadLine();

            WriteLine($"Hello {firstName}, looking good for {age} years old");
            #endregion

            #region getting Key input from user
                Write("Press any key combination : ");
                var key = ReadKey();
                WriteLine();
                WriteLine(
                    "Key {0}, Char: {1}, Modifiers {2}",
                    arg0: key.Key,
                    arg1: key.KeyChar,
                    arg2: key.Modifiers
                );
            #endregion

            #region getting args
            if(args.Length == 0)
            {
                WriteLine("You should have put some args bruhhhh (╬▔皿▔)╯");
            }
            else
            {
                WriteLine($"There are {args.Length} arguments ");
                WriteLine(args[0]);
            }
            #endregion

            #region Change color of console
                if(args.Length < 4)
                {
                WriteLine("YOu must specify two colors and two dimensions");
                WriteLine("For example : dotnet run red yellow 80 40");
                }
                ForegroundColor = (ConsoleColor)Enum.Parse(
                    enumType: typeof(ConsoleColor),
                    value: args[0],
                    ignoreCase : true
                );

                BackgroundColor = (ConsoleColor)Enum.Parse(
                    enumType: typeof(ConsoleColor),
                    value: args[1],
                    ignoreCase : true
                );

                WindowWidth = int.Parse(args[2]);
                WindowHeight = int.Parse(args[3]);
                Beep();
            #endregion

        }
    }
}
