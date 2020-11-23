using Microsoft.Extensions.Logging;
using System;
using static System.Console;
namespace WorkingWithEFcore
{
    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // filter the log level
            // TINDWEC
            // Trace , Information, None, Debug, Warning, Error, Critical
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //  if(eventId == 20101)
            //  {
            // log the level and the ID
            Write($"Level : {logLevel}, Event ID : {eventId.Id}");

            if(state != null)
            {
                Write($" , State : {state}");
            }
            if(exception != null)        
            {
                Write($", Exception : {exception.Message}");
            }
            WriteLine();
            //}
        }
    }
}