using System;
using static System.Console;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Unarios
                // 1 + 2
                // 1: operando
                // + : Operador
                int a = 3;
                int b = a++;
                WriteLine($"a is {a} and b is {b}");

                int c = 2;
                int d = ++c;
                WriteLine($"c is {c} and d is {d}");
            #endregion

            #region Aritmethic Operators
                // + - * / %
                float e = 11;
                float f = 3;

                WriteLine($"a is {e} and b is {f}");
                WriteLine($"e + f = {e + f}");
                WriteLine($"e - f = {e - f}");
                WriteLine($"e * f = {e * f}");
                WriteLine($"e / f = {e / f}");
                WriteLine($"e % f = {e % f}");
            #endregion

            #region Asignment Operators
                int p = 6;
                p += 3; // p = p + 3;
                p -= 3; // p = p - 3;
                p *= 3; // p = p * 3;
                p /= 3; // p = p / 3;
            #endregion

            #region Logical Operators
            // & AND 
            // | OR 
            //^ XOR 
            //! NOT
            bool h = true;
            bool i = false;

            WriteLine($"AND | h |   i");
            WriteLine($"h   | {h & h, -5} | {h & i, -5}");
            WriteLine($"i   | {i & h, -5} | {i & i, -5}");
            
            WriteLine($"OR | h |   i");
            WriteLine($"h   | {h | h, -5} | {h | i, -5}");
            WriteLine($"i   | {i | h, -5} | {i | i, -5}");

            WriteLine($"XOR | h |   i");
            WriteLine($"h   | {h ^ h, -5} | {h ^ i, -5}");
            WriteLine($"i   | {i ^ h, -5} | {i ^ i, -5}");
            // expresion
            #endregion

            #region Operadores Condicionales
                WriteLine($"h && DoStuff() = {h && DoStuff()}");
                WriteLine($"i && DoStuff() = {i && DoStuff()}");
            #endregion

            #region Bitwise or Binary Shift Operators
                int binaryN1 = 10; // 0000 1010
                int binaryN2 = 6; // 0000 0110

                WriteLine($"binaryN1 = {binaryN1}");
                WriteLine($"binaryN2 = {binaryN2}");
                WriteLine($"binaryN1 & binaryN2 = {binaryN1 & binaryN2}"); // 2 column bit only 0000 0010
                WriteLine($"binaryN1 | binaryN2 = {binaryN1 | binaryN2}"); // 8, 4 and 2 bit only 0000 1110
                WriteLine($"binaryN1 ^ binaryN2 = {binaryN1 ^ binaryN2}"); // 8 and 4 bit columns 0000 1100

                // 0101 0000 left shift by three bits / columns
                WriteLine($"BinaryN1 << 3 = {binaryN1 << 3}");
                WriteLine($"BinaryN1 * 8 = {binaryN1 * 8}");
                
                // 0000 0011
                WriteLine($"BinaryN2 >> 1 = {binaryN2 >> 1}");
            #endregion

            #region Miscellaneous Operators
                int age = 29;
                char firstDigit = age.ToString().ToCharArray()[0];
                // = Assignment Operator
                // . Acces Operator
                // () Invocation Operator
                // [] Indexer Acces Operator
            #endregion
        }

        private static bool DoStuff()
        {
            WriteLine("I don't know what i'm doing");
            return true;
        }
    }
}
