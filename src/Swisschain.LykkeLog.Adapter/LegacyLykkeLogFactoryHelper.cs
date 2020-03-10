using Microsoft.Extensions.Logging;

namespace Swisschain.LykkeLog.Adapter
{
    public static class LegacyLykkeLogFactoryHelper
    {
        public static Lykke.Common.Log.ILogFactory ToLykke(this ILoggerFactory loggerFactory)
        {
            return LegacyLykkeLogFactory.Create(loggerFactory);
        }

        public static Common.Log.ILog ToLykke(this ILogger logger, string component = default)
        {
            return new LegacyLykkeLog(logger, component);
        }
    }
}