using System.Data.Entity;
using DataAccess;

namespace BreakAwayConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			App_Start.EntityFrameworkProfilerBootstrapper.PreStart();

			Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

			Query.Query.PrintAllDestination();
			System.Console.ReadLine();
		}
	}
}

