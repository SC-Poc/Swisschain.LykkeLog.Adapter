using System;
using System.Threading.Tasks;
using Lykke.Common.Log;
using Microsoft.Extensions.Logging;

namespace Swisschain.LykkeLog.Adapter
{
    public class LegacyLykkeLog : Common.Log.ILog
    {
        private readonly ILogger _logger;
        private readonly string _component;

        public LegacyLykkeLog(ILogger logger, string component)
        {
            _logger = logger;
            _component = component;
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) where TState : LogEntryParameters
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope(string scopeMessage)
        {
            return _logger.BeginScope(scopeMessage);
        }

        public Task WriteInfoAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogInformation("{message};{component};{process};{$context}", info, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteMonitorAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogInformation("{message};{component};{process};{$context}", info, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string component, string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogWarning("{message};{component};{process};{$context}", info, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string component, string process, string context, string info, Exception ex,
            DateTime? dateTime = null)
        {
            _logger.LogWarning(ex, "{message};{component};{process};{$context}", info, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteErrorAsync(string component, string process, string context, Exception exception, DateTime? dateTime = null)
        {
            _logger.LogError(exception, "{message};{component};{process};{$context}", exception.Message, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteFatalErrorAsync(string component, string process, string context, Exception exception,
            DateTime? dateTime = null)
        {
            _logger.LogCritical(exception, "{message};{component};{process};{$context}", exception.Message, component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteInfoAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogInformation("{message};{component};{process};{$context}", info, _component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteMonitorAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogInformation("{message};{component};{process};{$context}", info, _component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string process, string context, string info, DateTime? dateTime = null)
        {
            _logger.LogWarning("{message};{component};{process};{$context}", info, _component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteWarningAsync(string process, string context, string info, Exception ex, DateTime? dateTime = null)
        {
            _logger.LogWarning(ex, "{message};{component};{process};{$context}", info, _component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteErrorAsync(string process, string context, Exception exception, DateTime? dateTime = null)
        {
            _logger.LogError(exception, "{message};{component};{process};{$context}", exception.Message, _component, process, context);
            return Task.CompletedTask;
        }

        public Task WriteFatalErrorAsync(string process, string context, Exception exception, DateTime? dateTime = null)
        {
            _logger.LogCritical(exception, "{message};{component};{process};{$context}", exception.Message, _component, process, context);
            return Task.CompletedTask;
        }
    }
}