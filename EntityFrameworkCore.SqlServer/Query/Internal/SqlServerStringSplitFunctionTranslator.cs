using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ITSwarm.EntityFrameworkCore.Query.Internal;

public class SqlServerStringSplitFunctionTranslator : IMethodCallTranslator
{
	private static readonly MethodInfo MethodInfo = typeof(SqlServerDbFunctionsExtensions)
		.GetMethod(nameof(SqlServerDbFunctionsExtensions.StringSplit));
	public SqlExpression? Translate(SqlExpression? instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
	{
		if (MethodInfo.Equals(method))
		{
			// var con = Expression.Constant(2, typeof(int));
			// var num = SqlExpression.Constant(2);
			// return _sql.Function("ABS", new[] { num }, typeof(int));
			var number = new SqlConstantExpression(Expression.Constant("123"), new IntTypeMapping("int", DbType.Int32));
			return number;
		}
		else
		{
			return null;
		}
	}
}

public class SqlServerMethodCallTranslatorPlugin : IMethodCallTranslatorPlugin
{
	public IEnumerable<IMethodCallTranslator> Translators { get; }
	public SqlServerMethodCallTranslatorPlugin()
	{
		Translators = new List<IMethodCallTranslator>
		{
			new SqlServerStringSplitFunctionTranslator()
		};
	}
}
