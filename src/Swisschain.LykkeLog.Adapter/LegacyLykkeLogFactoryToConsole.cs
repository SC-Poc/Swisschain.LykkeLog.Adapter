namespace Swisschain.LykkeLog.Adapter
{
    public class LegacyLykkeLogFactoryToConsole : Lykke.Common.Log.ILogFactory
    {
        public static Lykke.Common.Log.ILogFactory Instance
        {
            get
            {
                return new LegacyLykkeLogFactoryToConsole();
            }
        }

        public void Dispose()
        {

        }

        public Common.Log.ILog CreateLog<TComponent>(TComponent component, string componentNameSuffix)
        {
            return new LegacyLykkeLogToConsole();
        }

        public Common.Log.ILog CreateLog<TComponent>(TComponent component)
        {
            return new LegacyLykkeLogToConsole();
        }

        public void AddProvider(Microsoft.Extensions.Logging.ILoggerProvider provider)
        {

        }
    }
}
