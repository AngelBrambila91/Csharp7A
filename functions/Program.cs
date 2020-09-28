using System;
using static System.Console;

namespace functions
{
    class Program
    {
        // regime , optional: modifier, return type, name, (), optional : parameters
        /// <summary>
        /// This function is for printing the result of times table in console
        /// </summary>
        /// <param name="number">Number is a byte type, so it only can work between 0 and 255</param>
        static void TimesTable (byte number)
        {
            WriteLine($"This is the {number} times table");
            for (int row = 1; row <= 10; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            WriteLine();
            }
        }

        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
                Write("Enter a number bewteen 0 and 255 : ");
                isNumber = byte.TryParse(ReadLine(), out byte number);
                if(isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("Not a valid number");
                }
            } while (!isNumber);
        }

        static int ReturnInteger ()
        {
            return 'A';
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if(number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        static void RunFactorial()
        {
            bool isNumber;
            do
            {
                Write("Enter a number : ");
                isNumber = int.TryParse(ReadLine(), out int number);
                if(isNumber)
                {
                    WriteLine($"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    WriteLine("Not a valid number");
                }
            } while (!isNumber);
        }
        static void Main(string[] args)
        {
            RunTimesTable();
            RunFactorial();
        }
    }
}
