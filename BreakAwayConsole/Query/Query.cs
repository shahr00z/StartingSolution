using System;
using DataAccess;

namespace BreakAwayConsole.Query
{
	public class Query
	{
		public static void PrintAllDestination()
		{
			using (var context = new BreakAwayContext())
			{
				foreach (var destination in context.Destinations)
				{
					Console.WriteLine(destination.Name);
				}
			}
		}
	}
}