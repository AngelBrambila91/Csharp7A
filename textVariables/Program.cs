using System;
using static System.Console;

namespace textVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Literal Values
            char letter = 'A';
            char digit = '1';
            char symbol = '^';
            char custom = symbol;    
            #endregion
            
            #region String
            string firstName = "Andres";
            string lastName = "Smith";
            string phone = "(+52) 33-12-34-90-88";    
            #endregion
            
            //verbatims
            #region Verbatims
                /*
                \n
                \t
                \r
                \a
                \c
                */
                string filePath = @"C:\Users\time\nony.txt";
                WriteLine(filePath);
            #endregion

        }
    }
}
