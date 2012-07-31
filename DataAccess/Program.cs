
namespace BreakAwayConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			App_Start.EntityFrameworkProfilerBootstrapper.PreStart();

			//Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

			//Query.Query.PrintAllDestination();
			//Query.Query.PrintAllDestinationTwise();
			//Query.Query.PrintAllDestinationSorted();
			//Query.Query.PrintAllDestinationSortedInList();
			//Query.Query.PrintAustralianDestination();
			Query.Query.GetLocalDestinationCount();

			System.Console.ReadLine();

		}
	}
}

