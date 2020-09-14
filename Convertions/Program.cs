using System;
using static System.Console;
using static System.Convert;
namespace Convertions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Implicit Cast
                int a = 10;
                double b = a; // Implicit cast
                WriteLine(b);
            #endregion

            #region Explicit Cast
                double c = 14.6;
                int d = (int)c;
                WriteLine(d);
            #endregion

            #region 64 bit to 32 bit
                long e = 10;
                int f = (int) e;
                WriteLine($"e is {e:N0} and f is {f:N0}");

                e = long.MaxValue;
                f = (int)e;
                WriteLine($"e is {e:N0} and f is {f:N0}");

                e = 5_000_000_000;
                f = (int)e;
                WriteLine($"e is {e:N0} and f is {f:N0}");
            #endregion

            #region Convert
                double g = 15.9;
                int h = ToInt32(g);
                WriteLine($"g is {g} and h is {h}");
            #endregion

            #region Round
                double [] doubles = new double[]
                {
                    9.49, 9.5, 9.51, 10.49, 10.5, 10.51
                };

                foreach (var n in doubles)
                {
                    WriteLine($"ToInt({n}) is {ToInt32(n)}");
                }
            #endregion

            #region MathRounding
                foreach (var n in doubles)
                {
                    WriteLine($"MathRound({n}) is {Math.Round(n,0,MidpointRounding.AwayFromZero)}");
                }
            #endregion

            #region toString()
                int number = 12;
                WriteLine(number.ToString());

                bool boolean = true;
                WriteLine(boolean.ToString());

                DateTime now = DateTime.Now;
                WriteLine(now.ToString());

                object obj = new object();
                WriteLine(obj.ToString());
            #endregion

            #region Parse
                int age = int.Parse("29");
                DateTime birthday = DateTime.Parse("2 August 1991");
                WriteLine($"I was born {age} years ago");
                WriteLine($"My birthday is {birthday}");
                WriteLine($"My birthday is {birthday:D}");
                //int count = int.Parse("1A");
            #endregion
        }
    }
}
