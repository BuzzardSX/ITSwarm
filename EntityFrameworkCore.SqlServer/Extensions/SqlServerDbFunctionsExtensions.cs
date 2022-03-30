using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ITSwarm.EntityFrameworkCore;

public static class SqlServerDbFunctionsExtensions
{
	public static string StringSplit(this DbFunctions _) => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StringSplit)));
}
