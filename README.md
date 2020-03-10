# Swisschain.LykkeLog.Adapter
Adapter for legacy lykke logs system to Swisschain logs system

## How to use

If you have a legacy class with a dependency on `Lykke.Common.Log.ILogFactory`:

public class LegacyClass
{
	public LegacyClass(Lykke.Common.Log.ILogFactory logFactory)
	{
		// ...
	}

	// ...
}

You can adapt this class to use `Microsoft.Extensions.Logging.ILoggerFactory and use serilog as result.
For it you need to have an instance of logFactory:

`private Microsoft.Extensions.Logging.ILoggerFactory _logFactory`

To create instance of `LegacyClass` you can use next sintaxis:

`var instance = new LegacyClass(_logFactory.ToLykke())`