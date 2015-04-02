using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonsHouse.FantasyGolf.SportsDataApi.Field
{

	public class Fields
	{
		public string id { get; set; }
		public string name { get; set; }
		public float purse { get; set; }
		public float winning_share { get; set; }
		public int points { get; set; }
		public string event_type { get; set; }
		public string start_date { get; set; }
		public string end_date { get; set; }
		public Season[] seasons { get; set; }
		public string coverage { get; set; }
		public string status { get; set; }
		public Venue venue { get; set; }
		public Round[] rounds { get; set; }
		public Field[] field { get; set; }
	}

	public class Venue
	{
		public string id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string state { get; set; }
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
	}

	public class Season
	{
		public string id { get; set; }
		public int year { get; set; }
		public Tour tour { get; set; }
	}

	public class Tour
	{
		public string id { get; set; }
		public string name { get; set; }
		public string alias { get; set; }
	}

	public class Round
	{
		public string id { get; set; }
		public string status { get; set; }
		public int number { get; set; }
		public Weather weather { get; set; }
	}

	public class Weather
	{
		public int temp { get; set; }
		public string condition { get; set; }
		public Wind wind { get; set; }
	}

	public class Wind
	{
		public int speed { get; set; }
		public string direction { get; set; }
	}

	public class Field
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string country { get; set; }
		public string id { get; set; }
	}

}
