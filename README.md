# Swisschain.LykkeLog.Adapter
Adapter for legacy lykke logs system to Swisschain logs system

![.NET Core](https://github.com/SC-Poc/Swisschain.LykkeLog.Adapter/workflows/Deploy%20packet/badge.svg)

[![NuGet Status](https://img.shields.io/nuget/v/Swisschain.LykkeLog.Adapter?color=green&label=Nuget%3A%20Swisschain.LykkeLog.Adapter&logo=blue&logoColor=blue)](https://www.nuget.org/packages/Swisschain.LykkeLog.Adapter/)


## How to use

If you have a legacy class with a dependency on `Lykke.Common.Log.ILogFactory`:

```cs
public class LegacyClass
{
	public LegacyClass(Lykke.Common.Log.ILogFactory logFactory)
	{
		// ...
	}

	// ...
}
```

You can adapt this class to use `Microsoft.Extensions.Logging.ILoggerFactory` and use serilog as result.
For it you need to have an instance of logFactory:

```cs
private Microsoft.Extensions.Logging.ILoggerFactory _logFactory
```

To create instance of `LegacyClass` you can use next sintaxis:

```cs
var instance = new LegacyClass(_logFactory.ToLykke())
```
