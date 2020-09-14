using System;
using static System.Console;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TryParse    
            Write("Ho many Pigs are there?");
            int count = 0;
            string input = ReadLine();

            if(int.TryParse(input, out count))
            {
                WriteLine($"There are {count} pigs.");
            }
            else
            {
                WriteLine("Couln't parse the input");
            }
            #endregion

            #region Try Catch
                Write("How old are you? : ");
                input = ReadLine();
                try
                {
                int age = int.Parse(input);
                }
                catch (FormatException)
                {
                    WriteLine($"The age you entered is not a valid number format. I.E 90");
                }
                catch (OverflowException)
                {
                    WriteLine($"Your age is valid but is either too big or too small");
                }
                catch(Exception ex)
                {
                    WriteLine($"{ex.GetType()} says {ex.Message}");
                }
            #endregion

            #region checked
            int x = 0;
            try
            {
            checked
            {
                x = int.MaxValue - 1;
                WriteLine($"Incrementing x {x}");
                x++;
                WriteLine($"Incrementing x {x}");
                x++;
                WriteLine($"Incrementing x {x}");
                x++;
                WriteLine($"Incrementing x {x}");
                x++;
                WriteLine($"Incrementing x {x}");
                x++;
            }
            }
            catch (OverflowException)
            {
                WriteLine(x);
                WriteLine("algo");
            }
            #endregion
        }
    }
}
