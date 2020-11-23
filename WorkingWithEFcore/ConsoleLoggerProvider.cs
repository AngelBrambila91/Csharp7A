using Microsoft.Extensions.Logging;
using System;
using static System.Console;

namespace WorkingWithEFcore
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {
            
        }
    }
}