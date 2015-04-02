using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonsHouse.FantasyGolf.SportsDataApi.Tournament
{
	public class Tournaments
	{
		public Tour tour { get; set; }
		public Season season { get; set; }
		public Tournament[] tournaments { get; set; }
	}

	public class Tour
	{
		public string id { get; set; }
		public string alias { get; set; }
		public string name { get; set; }
	}

	public class Season
	{
		public string id { get; set; }
		public int year { get; set; }
	}

	public class Tournament
	{
		public string id { get; set; }
		public string name { get; set; }
		public string event_type { get; set; }
		public float purse { get; set; }
		public float winning_share { get; set; }
		public int points { get; set; }
		public string start_date { get; set; }
		public string end_date { get; set; }
		public Venue venue { get; set; }
	}

	public class Venue
	{
		public string id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipcode { get; set; }
		public string country { get; set; }
		public Cours[] courses { get; set; }
	}

	public class Cours
	{
		public string name { get; set; }
		public int yardage { get; set; }
		public int par { get; set; }
		public string id { get; set; }
		public Hole[] holes { get; set; }
	}

	public class Hole
	{
		public int number { get; set; }
		public int par { get; set; }
		public int yardage { get; set; }
		public string description { get; set; }
	}
}
