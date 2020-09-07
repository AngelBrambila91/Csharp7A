using System;
using static System.Console;
using System.IO;

namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            #region If Else
            if(args.Length == 0)
            {
                WriteLine("There are no arguments");
            }
            else if(args.Length == 1)
            {
                WriteLine("There are at least one argument");
            }
            else
            {
                
            }
            #endregion

            #region Pattern Matching
                object o = 3;
                int j = 4;
                if(o is int i)
                {
                    WriteLine($"{i} x {j} = {i * j}");
                }
                else
                {
                    WriteLine("o isn't int type so ... i can't multiply that");
                }
            #endregion

            #region Switch
                A_label:
                var number = (new Random()).Next(1 , 7);
                WriteLine($"My random number is {number}");

                switch (number)
                {
                    case 1:
                    WriteLine("One");
                    break;

                    case 2:
                    WriteLine("Two");
                    goto case 1;

                    case 3:
                    case 4:
                    WriteLine("Three or Four");
                    goto A_label;

                    
                    default:
                    WriteLine("Default");
                    break;
                }
            #endregion

             #region PatternMatchingSwitch
                string path = @"C:\Users\AORUS_DM\Desktop";

                Stream s = File.Open(Path.Combine(path, "test.txt"), FileMode.OpenOrCreate);

                string message = string.Empty;

                switch (s)
                {
                    case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that i can write to";
                    break;

                    case FileStream readOnlyFile:
                    message = "The stream is a read-only file.";
                    break;

                    case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;

                    default:
                    message = "The stream is some other type.";
                    break;

                    case null:
                    message = "the stream is null.";
                    break;
                }

                WriteLine(message);

            #endregion

            #region SwitchSimplified
                message = s switch
                {
                    FileStream writeableFile when s.CanWrite
                    => "The stream is a file that i can write to",
                    FileStream readOnlyFile
                    => "The stream is a read-only file.",
                    MemoryStream ms
                    => "The stream is a memory address.",
                    null => "The stream is null.",
                    _ => "The stream is some other type."
                };
            #endregion
        }
    }
}
