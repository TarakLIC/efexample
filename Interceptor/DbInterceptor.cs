using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace EfExample
{
	public class DbInterceptor : DbCommandInterceptor
	{
		public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			Console.WriteLine("Before Execute Reader");
			//Console.WriteLine(command.CommandText);
			if (command.CommandText.StartsWith("-- with ROBUST PLAN Hint:", StringComparison.Ordinal))
			{
				command.CommandText += " OPTION (ROBUST PLAN)";
			}
		}
	}
}
