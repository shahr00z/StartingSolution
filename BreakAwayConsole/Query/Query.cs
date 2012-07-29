using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Model;

namespace BreakAwayConsole.Query
{
	public class Query
	{
		public static void PrintAllDestination()
		{
			using (var context = new BreakAwayContext())
			{
				foreach (Destination destination in context.Destinations)
				{
					Console.WriteLine(destination.Name);
				}
			}
		}

		/// <summary>
		/// Only once execute Query
		/// </summary>
		public static void PrintAllDestinationTwise()
		{
			using (var context = new BreakAwayContext())
			{
				List<Destination> AllDestination = context.Destinations.ToList();
				foreach (Destination destination in AllDestination)
				{
					Console.WriteLine(destination.Name);
				}
				foreach (Destination destination in AllDestination)
				{
					Console.WriteLine(destination.Name);
				}
			}

			//                SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
		}

		public static void PrintAllDestinationSorted()
		{
			using (var context = new BreakAwayContext())
			{
				IOrderedQueryable<Destination> query = context.Destinations.OrderBy(d => d.Name);
				foreach (Destination destination in query)
				{
					Console.WriteLine(destination.Name);
				}
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//ORDER  BY [Extent1].[LocationName] ASC0
		}

		/// <summary>
		/// Only once execute Query
		/// </summary>
		public static void PrintAllDestinationSortedInList()
		{
			using (var context = new BreakAwayContext())
			{
				List<Destination> query = context.Destinations.OrderBy(d => d.Name).ToList();
				foreach (Destination destination in query)
				{
					Console.WriteLine(destination.Name);
				}
				foreach (Destination destination in query)
				{
					Console.WriteLine(destination.Name);
				}
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//ORDER  BY [Extent1].[LocationName] ASC0
		}

		public static void PrintAustralianDestination()
		{
			using (var context = new BreakAwayContext())
			{
				IQueryable<Destination> query = context.Destinations.Where(d => d.Country == "Australia");
				foreach (Destination destination in query)
				{
					Console.WriteLine(destination.Name);
				}
			}
			//        SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Australia' = [Extent1].[Country]
		}
		/// <summary>
		/// Projection
		/// </summary>
		public static void PrintDestinationNameOnly()
		{
			using (var context = new BreakAwayContext())
			{
				var query = context.Destinations.Where(d => d.Country == "Australia").Select(x => x.Name).ToList();

				foreach (var name in query)
				{
					Console.WriteLine(name);
				}
			}
			//            SELECT [Extent1].[LocationName] AS [LocationName]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Australia' = [Extent1].[Country]
		}
	}

}