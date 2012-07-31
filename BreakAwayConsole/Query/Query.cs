using System;
using System.Collections.Generic;
using System.Data.Entity;
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
				List<string> query = context.Destinations.Where(d => d.Country == "Australia").Select(x => x.Name).ToList();

				foreach (string name in query)
				{
					Console.WriteLine(name);
				}
			}
			//            SELECT [Extent1].[LocationName] AS [LocationName]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Australia' = [Extent1].[Country]
		}

		public static void FindDestination()
		{
			Console.Write("Enetr Id Destination to find: ");
			int id = int.Parse(Console.ReadLine());
			using (var context = new BreakAwayContext())
			{
				Destination Destination = context.Destinations.Find(id);
				Console.Write(Destination == null ? "Destination not found" : Destination.Name);
			}
			//            SELECT TOP (2) [Extent1].[LocationID]     AS [LocationID],
			//               [Extent1].[LocationName]   AS [LocationName],
			//               [Extent1].[Country]        AS [Country],
			//               [Extent1].[Description]    AS [Description],
			//               [Extent1].[Photo]          AS [Photo],
			//               [Extent1].[TravelWarnings] AS [TravelWarnings],
			//               [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  [Extent1].[LocationID] = 1 /* @p0 */
		}
		public static void FindGreatBarrierReef()
		{
			using (var context = new BreakAwayContext())
			{
				var query = context.Destinations.
					Where(x => x.Name == "Grea t   Barrier Reef");
				var reef = query.SingleOrDefault();
				Console.WriteLine(reef == null ? "Not found Destinations" : reef.Description);
			}
			//            SELECT TOP (2) [Extent1].[LocationID]     AS [LocationID],
			//               [Extent1].[LocationName]   AS [LocationName],
			//               [Extent1].[Country]        AS [Country],
			//               [Extent1].[Description]    AS [Description],
			//               [Extent1].[Photo]          AS [Photo],
			//               [Extent1].[TravelWarnings] AS [TravelWarnings],
			//               [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Great Barrier Reef' = [Extent1].[LocationName]
		}

		public static void GetLocalDestinationCount()
		{
			using (var context = new BreakAwayContext())
			{
				foreach (var VARIABLE in context.Destinations)
				{
				}
				var count = context.Destinations.Local.Count;
				Console.WriteLine("destination in memory :{0}", count);
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
		}
		public static void GetLocalDestinationCountWithLoad()
		{
			using (var context = new BreakAwayContext())
			{
				context.Destinations.Load();
				var count = context.Destinations.Local.Count;
				Console.WriteLine("destination in memory :{0}", count);
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
		}
		public static void LoadAustralianDestination()
		{
			using (var context = new BreakAwayContext())
			{
				var query = context.Destinations.
			Where(x => x.Country == "Australia");
				query.Load();
				var count = context.Destinations.Local.Count;
				Console.WriteLine("Aussie destination in memory :{0}", count);
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Australia' = [Extent1].[Country]
		}
		public static void LoadAustralianAndUSADestination()
		{
			using (var context = new BreakAwayContext())
			{
				var australia = context.Destinations.
			Where(x => x.Country == "Australia");

				var USA = context.Destinations.
			Where(x => x.Country == "USA");

				australia.Load();

				USA.Load();

				var count = context.Destinations.Local.Count;
				Console.WriteLine("Aussie destination in memory :{0}", count);
			}
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'Australia' = [Extent1].[Country]
			//            SELECT [Extent1].[LocationID]     AS [LocationID],
			//       [Extent1].[LocationName]   AS [LocationName],
			//       [Extent1].[Country]        AS [Country],
			//       [Extent1].[Description]    AS [Description],
			//       [Extent1].[Photo]          AS [Photo],
			//       [Extent1].[TravelWarnings] AS [TravelWarnings],
			//       [Extent1].[ClimateInfo]    AS [ClimateInfo]
			//FROM   [baga].[Locations] AS [Extent1]
			//WHERE  N'USA' = [Extent1].[Country]
			//Write 4
		}
	}
}