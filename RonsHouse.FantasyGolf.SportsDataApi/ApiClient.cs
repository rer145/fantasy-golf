using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

using RestSharp;

namespace RonsHouse.FantasyGolf.SportsDataApi
{
	public static class ApiClient
	{
		private static string API_KEY = ConfigurationManager.AppSettings["SportsDataApiKey"];

		public static RonsHouse.FantasyGolf.SportsDataApi.Tournament.Tournaments GetTournaments(string tour, int year)
		{
			var client = new RestClient("http://api.sportsdatallc.org");
			var request = new RestRequest("/golf-t1/schedule/" + tour + "/" + year.ToString() + "/tournaments/schedule.json?api_key=" + API_KEY, Method.GET);
			var tournaments = client.Execute<RonsHouse.FantasyGolf.SportsDataApi.Tournament.Tournaments>(request).Data;
			return tournaments;
		}
	}
}