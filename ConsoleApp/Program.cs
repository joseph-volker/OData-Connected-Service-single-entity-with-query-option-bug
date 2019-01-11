using System;
using Microsoft.OData.Service.Sample.TrippinInMemory.Models;

namespace ConsoleApp
{
	internal static class Program
	{
		private static void Main()
		{
			var tripPinUri = new Uri("https://services.odata.org/TripPinRESTierService");
			var tripPinContainer = new Container(tripPinUri);

			try
			{
				var person = tripPinContainer.People
					.AddQueryOption("$expand", "Friends")
					.ByKey("russellwhyte")
					.GetValue(); //this throws an ArgumentException because the path generated will be "/People?$expand=Friends('russellwhyte')"

				/*
				 * this is a valid request: https://services.odata.org/TripPinRESTierService/People('russellwhyte')?$expand=Friends
				 * this is the request generated by the connected service: https://services.odata.org/TripPinRESTierService/People?$expand=Friends('russellwhyte')
				 * The query string for the query options is inserted into the wrong spot
				 */

				Console.WriteLine($"Name: {person.FirstName} {person.LastName}");

				foreach (var friend in person.Friends)
				{
					Console.WriteLine($"{friend.FirstName} {friend.LastName} is a friend of {person.FirstName} {person.LastName}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			Console.ReadKey();
		}
	}
}
