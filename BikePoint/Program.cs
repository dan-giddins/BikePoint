using RestHelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePoint
{
	class Program
	{
		static async Task Main()
		{
			var restHelper = new RestHelper("https://api.tfl.gov.uk/BikePoint");
			Console.WriteLine("Getting data...");
			var bikePoints = await restHelper.Get<List<BikePoint>>("");
			Console.WriteLine("Got data...");
			var brokenBikePoints = bikePoints.Select(x => (x, NumberOfBrokenDocks(x)))
				.Where(x => x.Item2 > 0)
				.ToList()
				.OrderByDescending(x => x.Item2);
			foreach (var brokenBikePoint in brokenBikePoints)
			{
				Console.WriteLine($"{brokenBikePoint.x.Id,-20}{brokenBikePoint.x.CommonName,-50}{brokenBikePoint.Item2}");
			}
		}

		private static int NumberOfBrokenDocks(BikePoint bikePoint) =>
			GetIntValueByKey(bikePoint, Key.NbDocks)
			- GetIntValueByKey(bikePoint, Key.NbBikes)
			- GetIntValueByKey(bikePoint, Key.NbEmptyDocks);

		private static int GetIntValueByKey(BikePoint bikePoint, Key key) =>
			int.Parse(bikePoint.AdditionalProperties.Single(x => x.Key == key).Value);
	}
}
