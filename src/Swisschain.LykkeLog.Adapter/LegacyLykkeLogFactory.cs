using Common.Log;
using Microsoft.Extensions.Logging;

namespace Swisschain.LykkeLog.Adapter
{
    public class LegacyLykkeLogFactory : Lykke.Common.Log.ILogFactory
    {
        private readonly ILoggerFactory _factory;

        public static Lykke.Common.Log.ILogFactory Create(ILoggerFactory factory)
        {
            return new LegacyLykkeLogFactory(factory);
        }

        public LegacyLykkeLogFactory(ILoggerFactory factory)
        {
            _factory = factory;
        }

        public void Dispose()
        {
            
        }

        public ILog CreateLog<TComponent>(TComponent component, string componentNameSuffix)
        {
            var log = _factory.CreateLogger<TComponent>();
            var logger = new LegacyLykkeLog(log, typeof(TComponent).Name);
            return logger;
        }

        public ILog CreateLog<TComponent>(TComponent component)
        {
            var log = _factory.CreateLogger<TComponent>();
            var logger = new LegacyLykkeLog(log, typeof(TComponent).Name);
            return logger;
        }

        public void AddProvider(ILoggerProvider provider)
        {
            _factory.AddProvider(provider);
        }
    }
}