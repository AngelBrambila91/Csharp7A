using System;
using static System.Console;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ints
            // uint = unsigned int, ONLY positive numbers including 0
            uint unsignedInteger = 11;
            // int Positive and negative numbers including 0
            int integerVariables = -100;

            //float = single-precision floating point
            float realNumer = 2.3F;

            // double = double-precision floating point
            double doubleNumber = 2.3;
            #endregion

            #region Binary an HexadecimalNotation on Int
            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;

            WriteLine($"{decimalNotation == binaryNotation}");
            WriteLine($"{decimalNotation == hexadecimalNotation}");
            #endregion

            #region Size of Variables
                WriteLine($"int uses {sizeof(int)} bytes and can store from {int.MinValue:N0} to {int.MaxValue:N0}");
                WriteLine($"double uses {sizeof(double)} bytes and can store from {double.MinValue:N0} to {double.MaxValue:N0}");
                WriteLine($"decimal uses {sizeof(decimal)} bytes and can store from {decimal.MinValue:N0} to {decimal.MaxValue:N0}");
            #endregion

            #region decimalVsDouble
                double a = 0.1;
                double b = 0.2;
                if(a + b == 0.3)
                {
                    WriteLine($"{a} + {b} = {a + b} equals 0.3");
                }
                else
                {
                    WriteLine($"{a} + {b} = {a + b} NOT equals 0.3");
                }
                decimal c = 0.1M;
                decimal d = 0.2M;
                if(c + d == 0.3M)
                {
                    WriteLine($"{c} + {d} = {c + d} equals 0.3");
                }
                else
                {
                    WriteLine($"{c} + {d} = {c + d} NOT equals 0.3");
                }
            #endregion

            #region booleans
                bool happy = true;
                bool sad = false;
            #endregion

        }
    }
}
