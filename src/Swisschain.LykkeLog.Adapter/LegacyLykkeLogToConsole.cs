using System;
using System.Threading.Tasks;
using Lykke.Common.Log;

namespace Swisschain.LykkeLog.Adapter
{
    public class LegacyLykkeLogToConsole : Common.Log.ILog
    {
        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) where TState : LogEntryParameters
        {
            Console.WriteLine($"{logLevel}\t{formatter.Invoke(state, exception)}");
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope(string scopeMessage)
        {
            return new EmptyDisposable();
        }

        public Task WriteInfoAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"INFO\t{component};{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteMonitorAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"MONITOR\t{component};{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"WARNING\t{component};{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string component, string process, string context, string info, Exception ex,
            DateTime? dateTime = null)
        {
            Console.WriteLine($"WARNING\t{component};{process};{info};{context}\n\r{ex}");
            return Task.CompletedTask;
        }

        public Task WriteErrorAsync(string component, string process, string context, Exception exception, DateTime? dateTime = null)
        {
            Console.WriteLine($"ERROR\t{component};{process};{exception.Message};{context}\n\r{exception}");
            return Task.CompletedTask;
        }

        public Task WriteFatalErrorAsync(string component, string process, string context, Exception exception,
            DateTime? dateTime = null)
        {
            Console.WriteLine($"WARN\t{component};{process};{exception.Message};{context}\n\r{exception}");
            return Task.CompletedTask;
        }

        public Task WriteInfoAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"INFO\t{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteMonitorAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"MONITOR\t{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            Console.WriteLine($"WARNING\t{process};{info};{context}");
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string process, string context, string info, Exception ex, DateTime? dateTime = null)
        {
            Console.WriteLine($"WARNING\t{process};{info};{context}\n\r{ex}");
            return Task.CompletedTask;
        }

        public Task WriteErrorAsync(string process, string context, Exception exception, DateTime? dateTime = null)
        {
            Console.WriteLine($"ERROR\t{process};{exception.Message};{context}\n\r{exception}");
            return Task.CompletedTask;
        }

        public Task WriteFatalErrorAsync(string process, string context, Exception exception, DateTime? dateTime = null)
        {
            Console.WriteLine($"FATAL-ERROR\t{process};{exception.Message};{context}\n\r{exception}");
            return Task.CompletedTask;
        }

        public class EmptyDisposable : IDisposable
        {
            public void Dispose()
            {

            }
        }
    }
}